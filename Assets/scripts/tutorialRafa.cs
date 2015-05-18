using UnityEngine;
using System.Collections;

public class tutorialRafa : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.StartCoroutine(this.SpawnEvery1Sec());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void Spawn()
    {
    }

    private IEnumerator SpawnEvery1Sec()
    {
        while (true) //Lanza un Spawn cada segundo peor no es una espera activa, no bloquea el procesador. Único sitio donde se puede usar While(true)
        {
            this.Spawn();
            yield return new WaitForSeconds(1f); //Cada yield es un paso de la iteración de forma automática
        }
    }

}


//Corrutinas: metodos que suspenden su ejecución, basado en un iterador: 
//hace los plasos del planing que le da un iterador