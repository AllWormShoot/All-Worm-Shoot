using UnityEngine;
using System.Collections;

public class cuerposScr : MonoBehaviour {

    public GameObject Gusano;

    /* Mueve todos los cuerpos 
    ** Recibe como parametro la posicion donde ha de moverse el primer cuerpo, 
    el resto de cuerpos asumiran la posicion de su homonimo delantero*/
    public void Mueve(Vector3 posCabezon)
    {
        // Posiciona los cuerpos en la posicion del delantero
        Vector3 pos = posCabezon;
        Vector3 posAnt;
        foreach(Transform child in transform)
        {
            posAnt = pos;
            pos = child.position;
            child.position = posAnt;
        }   
    }

    /** Clona el ultimo cuerpo */
    public void Crece(){
        GameObject cuerpo = transform.GetChild(transform.childCount - 1).gameObject;
        GameObject clon = Instantiate(cuerpo, cuerpo.transform.position, cuerpo.transform.rotation) as GameObject;
        clon.transform.parent = cuerpo.transform.parent;
    }

    /** Envia las colisiones al padre (gusanazo)*/
    void OnCollisionEnter(Collision colisionador)
    {
        Gusano.GetComponent<gusanazoScr>().gusanoColisiona(colisionador);
    }

}
