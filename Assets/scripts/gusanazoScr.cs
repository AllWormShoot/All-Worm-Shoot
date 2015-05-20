using UnityEngine;
using System.Collections;

public class gusanazoScr : MonoBehaviour
{

    public GameObject terrenoLocal;
    public GameObject cuerposLocal;

    private Transform cuerposLocalTransform;
    private Transform terrenoLocalTransform;
    public Transform estadosTransform;

    public float tiempoMueve;
    public int posX;
    public int posZ;
    public int maxPosX;
    public int maxPosZ;
    public int manzanasQuedan;

    public string direcc = "der"; // izq, der, abj, arr


    void Start()
    {
        cuerposLocalTransform = cuerposLocal.transform;
        terrenoLocalTransform = terrenoLocal.transform;
        maxPosX = terrenoLocal.GetComponent<fieldScr>().Ancho;
        maxPosZ = terrenoLocal.GetComponent<fieldScr>().Alto;
        posX = 9;
        posZ = 3;
        maxPosX = 30;
        maxPosZ = 20;
        manzanasQuedan = 2;
        tiempoMueve = 0.2f;

        var pos = getPosTablero();
        this.transform.position = pos;
        Invoke("mueveWorm", tiempoMueve);
    }


    void mueveWorm()
    {
        // Direccion del movimiento
        if (direcc == "arr" && posZ < maxPosZ - 1)
        {
            posZ++;
            transform.right = Vector3.forward;
        }
        else if (direcc == "abj" && posZ > 0)
        {
            posZ--;
            transform.right = -Vector3.forward;
        }
        else if (direcc == "izq" && posX > 0)
        {
            posX--;
            transform.right = -Vector3.right;
        }
        else if (direcc == "der" && posX < maxPosX - 1)
        {
            posX++;
            transform.right = -Vector3.left;
        }

        // Extrae la nueva posicion desde las baldosas y posiciona
        var pos = getPosTablero();
        var posAnt = this.transform.position;
        this.transform.position = pos;

        // Posiciona los cuerpos gusaniles
        if (posAnt != pos)
        {
            cuerposLocal.GetComponent<cuerposScr>().Mueve(posAnt);
            
        }

        // Recursivo
        Invoke("mueveWorm", tiempoMueve);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && direcc != "abj")
        {
            direcc = "arr";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direcc != "arr")
        {
            direcc = "abj";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direcc != "der")
        {
            direcc = "izq";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direcc != "izq")
        {
            direcc = "der";
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            comeManzana();
        }
    }


    Vector3 getPosTablero()
    {
        var pos = terrenoLocalTransform.GetChild(posX).transform.GetChild(posZ).position;
        pos.y = 1;
        return pos;
    }

    void comeManzana()
    {
        cuerposLocalTransform.GetComponent<cuerposScr>().Crece();
    }


    void muereBicho()
    {
        Application.LoadLevel(Application.loadedLevel);
    }



    void OnCollisionEnter(Collision colisionador)
    {
        //Debug.Log(colisionador.gameObject.tag);
        if (colisionador.gameObject.tag == "manzana")
        {
            comeManzana();
            //Destroy(colision.gameObject);
        }
        else if (colisionador.gameObject.tag == "rompible")
        {
            muereBicho();
        }
        else if (colisionador.gameObject.tag == "irrompible")
        {
            muereBicho();
        }
        else if (colisionador.gameObject.tag == "cuerpo")
        {
            muereBicho();
        }

    }




}
