using UnityEngine;
using System.Collections;

public class cabezonScr : MonoBehaviour {

    public GameObject Terreno;
    public GameObject Gusano;

    private Transform terrenoTransform;
    private Transform cabezonTransform;
    private int posX; // Posicion horizontal de la cabeza en el tablero
    private int posZ; // Posicion vertical de la cabeza en el tablero
    private int maxPosX; // Anchura maxima del tablero
    private int maxPosZ; // Altura maxima del tablero
    private string direcc; // arr, abj, der, izq

    void Start()
    {
        cabezonTransform = this.transform;
        terrenoTransform = Terreno.transform;
        maxPosX = Terreno.GetComponent<fieldScr>().Ancho;
        maxPosZ = Terreno.GetComponent<fieldScr>().Alto;
        posX = 9;
        posZ = 3;
        direcc = "der";

        // Posiciona la cabeza del gusano por primera vez
        cabezonTransform.position = getPosTablero();
    }

    /** Mueve el gusano el la direccion indicada (arr, abj, der, izq) */
    public void Mueve()
    {
        // Establece la Nueva posicion y rotacion de la cabeza del gusano
        if (direcc == "arr" && posZ < maxPosZ - 1)
        {
            posZ++;
            cabezonTransform.right = Vector3.forward;
        }
        else if (direcc == "abj" && posZ > 0)
        {
            posZ--;
            cabezonTransform.right = -Vector3.forward;
        }
        else if (direcc == "izq" && posX > 0)
        {
            posX--;
            cabezonTransform.right = -Vector3.right;
        }
        else if (direcc == "der" && posX < maxPosX - 1)
        {
            posX++;
            cabezonTransform.right = -Vector3.left;
        }

        // Posiciona la cabeza del gusano por primera vez
        cabezonTransform.position = getPosTablero();
    }


    /** Devuelve la posicion en el espacio en base a los cubos de los que esta compuesto el terreno*/
    Vector3 getPosTablero()
    {
        var pos = terrenoTransform.GetChild(posX).transform.GetChild(posZ).position;
        pos.y = 1;
        return pos;
    }

    void Update()
    {
        // Guarda el proximo movimiento la cabeza del gusano
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
    }

    /** Envia las colisiones al padre (gusanazo)*/
    void OnCollisionEnter(Collision colisionador) {
        Gusano.GetComponent<gusanazoScr>().gusanoColisiona(colisionador);
    }

    
}
