using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Counters : MonoBehaviour {

    public int _points;
    public int _apples;
    public int _lifes;
    public int _time;

    public Text TClock;
    public Text TApplesLeft;
    public Text TPoints;
    public GameObject[] hearts;

    public int SiguienteNivel;

    // Use this for initialization
    void Start () {
        Debug.Log("Start Counters");

        //txtClock = this.gameObject.transform.FindChild("GUI").FindChild("Clock").FindChild("txtClock").GetComponentInChildren<GUIText>(); //Esto no lo resuelve. Comprobar

        TClock.text = _time.ToString();
        TApplesLeft.text = _apples.ToString();
        TPoints.text = "0";

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
            endGame(0);
    }

    public void decreaseApples()
    {
        Debug.Log("Manzanas " + _apples);
        if (_apples > 0)
            _apples = _apples - 1;
        else
            endGame(1);
    }

    public void modifyPoints(int point)
    {

       Debug.Log("incrementando puntos " + _points + " en " + point);

        _points += point;

    }

    public void decreaseLife()
    {
        
        Debug.Log("Una vida menos, quedan " + _lifes);

        if (_lifes > 0)
        {
            Destroy(hearts[_lifes - 1]);
            _lifes -= 1;
        }
        else
        {
            endGame(0);
        }

    }

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
                Application.LoadLevel(0);
                break;
            case 1:
                Debug.Log("Siguiente Nivel");
                Application.LoadLevel(SiguienteNivel); //Ant: Seleccionar el nivel
                break;
            default:
                break;
        }

    }
    
}
