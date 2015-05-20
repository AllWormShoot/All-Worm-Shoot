using UnityEngine;
using System.Collections;

public class cuerposScr : MonoBehaviour {
    
    private Transform posAnt;
    
    // Use this for initialization
	void Start () {
    }

    // Se invoca desde gusano.moeveWorm()
    public void Mueve(Vector3 posCabezon)
    {
        //Debug.Log("Jola!!!");

        // Posiciona los cuerpos en la posicion del anterior
        Vector3 pos = posCabezon;
        Vector3 posAnt;

        foreach(Transform child in transform)
        {
            posAnt = pos;
            pos = child.position;
            child.position = posAnt;
        }
        
    }

    public void Crece(){
        //Debug.Log("Hijo de puta");
        GameObject cuerpo = transform.GetChild(transform.childCount - 1).gameObject;
        GameObject clon = Instantiate(cuerpo, cuerpo.transform.position, cuerpo.transform.rotation) as GameObject;
        clon.transform.parent = cuerpo.transform.parent;
    }




}
