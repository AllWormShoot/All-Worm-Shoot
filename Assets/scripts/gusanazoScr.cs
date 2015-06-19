using UnityEngine;
using System.Collections;

public class gusanazoScr : MonoBehaviour
{
    public GameObject Terreno;
    public GameObject Cuerpos;
    public GameObject Cabezon;

    private Transform gusanoTransform;
    private Transform cabezonTransform;
    private Transform cuerposTransform;
    private float tiempoMueve; // Intervalo en segundos en que se mueve el gusano
    

    void Start()
    {
        gusanoTransform = this.transform;
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
        Application.LoadLevel(Application.loadedLevel);
    }

    /** Centraliza las colisiones producidas por la cabeza del gusano y sus cuerpos */
    public void gusanoColisiona(Collision colisionador)
    {
		switch (colisionador.gameObject.tag) {
			case "manzana":
				comeManzana();
				break;
			case "booster":
				Destroy (colisionador.gameObject);
				break;
			default:
				muereBicho();
				break;
		}
    }

	// Cambia la variable tiempoMueve y por ende la velocidad a la que se mueve el guzando
	public void changeSpeed (float speed) 
	{
		tiempoMueve = speed;
	}


}
