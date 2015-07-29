using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Counters : MonoBehaviour {

    public int _points;
	public int _pointsMultiplier;
    public int _apples;
    public int _lifes;
    public int _time;

    public GameObject estados; //Es un prefab que controla los estados estáticos entre niveles

    public Text TClock;
    public Text TApplesLeft;
    public Text TPoints;
    public GameObject[] hearts;

    public int SiguienteNivel;

    // Use this for initialization
    void Start () {
        Debug.Log("Start Counters");

		_pointsMultiplier = 1;

        //txtClock = this.gameObject.transform.FindChild("GUI").FindChild("Clock").FindChild("txtClock").GetComponentInChildren<GUIText>(); //Esto no lo resuelve. Comprobar

        TClock.text = _time.ToString();
        TApplesLeft.text = _apples.ToString();
        TPoints.text = "0";
        _lifes = estados.GetComponent<staticValuesScr>().getLives();
        setInitialHeartsLife(); //Establece el número inicial de vidas

        Debug.Log("Vidas restantes: " + _lifes);

        this.StartCoroutine(this.decreaseTime1Sec());
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("GuiUpdate");
        TClock.text = _time.ToString();
        TApplesLeft.text = _apples.ToString();
        TPoints.text = _points.ToString();
	}

    void decreaseTime()
    {
        if (_time > 0)
            _time = _time - 1;
        else
        {
            decreaseLife();
            endGame(0);
        }
    }

    public void decreaseApples()
    {
        //Debug.Log("Manzanas " + _apples);
        if (_apples > 1)
            _apples = _apples - 1;
        else
            endGame(1);
    }

    public void modifyPoints(int point)
    {
		Debug.Log("incrementando puntos " + _points + " en " + point);
		
		point *= _pointsMultiplier;

        _points += point;

    }

    public void setInitialHeartsLife()
    {
        for (int i = 0; i < _lifes; i++)
			{
                hearts[i].SetActive(true);
			}
    }

    public void decreasePointsMultiplier ()
	{
		if (_pointsMultiplier > 1) {
			_pointsMultiplier--;
		}
	}

	public void increasePointsMultiplier ()
	{
		_pointsMultiplier++;
	}

    public void decreaseLife()
    {
        
        //Debug.Log("Una vida menos, quedan " + _lifes);

        if (_lifes > 0)
        {
            _lifes -= 1;
            hearts[_lifes].SetActive(false);
            estados.GetComponent<staticValuesScr>().setLives(_lifes); //Baja el contador global de vidas
            endGame(0);
        }
    }


    public void increaseLife()
    {
        //Para la suma de vidas de los boosters
        if (_lifes <= 5)
        {
            //Sumar a la matriz Hearts, asignar el objeto y mostrarlo
            _lifes += 1;
            hearts[_lifes].SetActive(true);
            estados.GetComponent<staticValuesScr>().setLives(_lifes); //Baja el contador global de vidas
        }
    }
	/** Rama Boosters */
    /*
    public void increaseLife ()
	{
		Debug.Log("Una vida extra (max. 3), tienes " + _lifes);
		
		if (_lifes < 3) {
			_lifes += 1;
		}
	}
     * */

    private IEnumerator decreaseTime1Sec()
    {
        while (true) //Lanza un Spawn cada segundo peor no es una espera activa, no bloquea el procesador. Único sitio donde se puede usar While(true)
        {
            //Debug.Log("Ienumerator");
            this.decreaseTime();
            yield return new WaitForSeconds(1f); //Cada yield es un paso de la iteración de forma automática
        }
    }

    public void endGame(int estado)
    {
        switch (estado)
        {
            case 0:
                Debug.Log("Partida perdida!");
                if (_lifes > 0) 
                    Application.LoadLevel(Application.loadedLevel);
                else
                    Application.LoadLevel(0);
               

                break;
            case 1:
                Debug.Log("Siguiente Nivel");
                estados.GetComponent<staticValuesScr>().setNewLevel(true);

                Application.LoadLevel(SiguienteNivel); //Ant: Seleccionar el nivel
                break;
            default:
                break;
        }

    }
    

	/*public void modifyPoints(int point)
	{
		
		Debug.Log("incrementando puntos " + _points + " en " + point);
		
		_points += (point * _pointsMultiplier);
		
	}
	

		
	}*/
	

}
