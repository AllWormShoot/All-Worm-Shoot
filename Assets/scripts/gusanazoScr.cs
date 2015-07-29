using UnityEngine;
using System.Collections;

public class gusanazoScr : MonoBehaviour
{
    public GameObject Terreno;
    public GameObject Cuerpos;
    public GameObject Cabezon;
	public int durationOfSpeedChanged = 10; // Tiempo en segundos que durara los efectos de cambio de velocidad producidos por un booster

    //private Transform gusanoTransform;
    private Transform cabezonTransform;
    private Transform cuerposTransform;
    private float tiempoMueve; // Intervalo en segundos en que se mueve el gusano
	private int counterForRestoreSpeed; // Contador de tiempo, usado en la co-rutina 'restoreSpeed ()'
	private bool restardCounterForRestoreSpeed = false; // Indica si el contador (counterForRestoreSpeed) debe ser reiniciado

    public GameObject estados;

    void Start()
    {
        //gusanoTransform = this.transform;
        cabezonTransform = Cabezon.transform;
        cuerposTransform = Cuerpos.transform;
        tiempoMueve = 0.2f;
        
        // Comienza el movimiento continuo del gusano 
        StartCoroutine(mueveWorm());

    }

    /** Recursiva!! Se encarga de mover el gusano constantemente */
    IEnumerator mueveWorm()
    {
        // Espera tiempoMueve para seguir ejecutando
        yield return new WaitForSeconds(tiempoMueve);

        // Posiciona los cuerpos gusaniles
        Cuerpos.GetComponent<cuerposScr>().Mueve(cabezonTransform.position);

        // Posiciona los cuerpos la cabeza
        Cabezon.GetComponent<cabezonScr>().Mueve();

        // Recursivo!!
        StartCoroutine(mueveWorm());
    }

    void Update()
    {
        // Simula la ingesta de una fruta
        if (Input.GetKeyDown(KeyCode.A))
        {
            comeManzana();
        }
    }

    void comeManzana()
    {
        cuerposTransform.GetComponent<cuerposScr>().Crece();
    }

    void muereBicho()
    {
        estados.GetComponent<Counters>().decreaseLife();
        
        //Application.LoadLevel(Application.loadedLevel); //Controlado por las vidas
    }

    /** Centraliza las colisiones producidas por la cabeza del gusano y sus cuerpos */
    public void gusanoColisiona(Collision colisionador)
    {
		switch (colisionador.gameObject.tag) {
			case "manzana":
				comeManzana();
				break;
			case "booster":
				string name = colisionador.gameObject.name;
				
				name = name.Replace("(Clone)", "");

				boosterApply(name);
				
				Destroy (colisionador.gameObject);
				break;
			default:
				muereBicho();
				break;
		}
    }

	private void boosterApply (string boosterName)
	{
		switch (boosterName) {
			case "hasteBuff":
				Debug.Log(boosterName);
	
				changeSpeed(0.1f);
				Debug.Log(tiempoMueve);
				break;
			case "hasteDebuff":
				Debug.Log(boosterName);
				
				changeSpeed(0.4f);
				break;
			case "lifeBuff":
				Debug.Log(boosterName);

				estados.GetComponent<Counters>().increaseLife();
				break;
			case "lifeDebuff":
				Debug.Log(boosterName);

				estados.GetComponent<Counters>().decreaseLife();
				break;
			case "pointBuff":
				Debug.Log(boosterName);

				estados.GetComponent<Counters>().increasePointsMultiplier();
				break;
			case "pointDebuff":
				Debug.Log(boosterName);

				estados.GetComponent<Counters>().decreasePointsMultiplier();
				break;
		}
	}

	// Cambia la variable tiempoMueve y por ende la velocidad a la que se mueve el guzando
	public void changeSpeed (float speed) 
	{
		if (tiempoMueve == 0.2f) { // la velocidad del guzano no se ha variado antes
			tiempoMueve = speed;
			
			StartCoroutine(restoreSpeed());
		}
		else {
			if (tiempoMueve < 0.2f) { // Si la velocida ya se habia aumentado...
				if (speed < 0.2f) { // ...y se obtiene otro hasteBuff, entonces se reinicia la co-rutina
					restardCounterForRestoreSpeed = true;
					Debug.Log("restoreSpeed");
				}
				else { // ...y se obtiene un hasteDebuff, se restaura la velocidad
					tiempoMueve = 0.2f;
				}
			}
			else { // Si la velocidad ya se habia disminuido...
				if (speed < 0.2f) { // ...y se obtiene otro hasteBuff, se restaura la velocidad
					tiempoMueve = 0.21f;
				}
				else { // ...y se obtiene un hasteDebuff, se reinicia la co-rotina
					restardCounterForRestoreSpeed = true;
				}
			}
		}

	}

	// Corutina que restaura la velocidad del guzano (por defecto 0.2f)
	private IEnumerator restoreSpeed()
	{
		counterForRestoreSpeed = 0;

		// Cada seguno se aumenta el contador (counterForRestoreSpeed) hasta que este alcanza duracion establecida (durationOfSpeedChanged)
		//    para el cambio de velocidad
		do {
			yield return new WaitForSeconds (1);

			if (restardCounterForRestoreSpeed) {
				counterForRestoreSpeed = 0;

				restardCounterForRestoreSpeed = false;
			}
			else {
				counterForRestoreSpeed ++;
			}

			Debug.Log(counterForRestoreSpeed);
		} while (counterForRestoreSpeed < durationOfSpeedChanged);

		tiempoMueve = 0.2f; // Restaura la velocidad

		yield return null; // terminar co-routina
	}
}
