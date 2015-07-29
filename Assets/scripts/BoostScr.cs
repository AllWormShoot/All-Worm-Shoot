using UnityEngine;
using System.Collections;

public class BoostScr : MonoBehaviour 
{
	public float timeCreateBooster = 30; // Tiempo en segundos que se tardara en crear un booster
	public float timeDestroyBooster = 10; // Tiempo en segundos que se tardara en destruir un booster
	public GameObject [] boosters; // Array que contendra toda la coleccion de objetos booster
	public int amount = 2; // Cantidad de booster que se van a generar aleatoriamente para introducirlos en el escenario

	private GameObject [] clonBoosters; // Lista de boosters seleccionados aleatorimente para incluirlos en el escenario
	private Vector3 [] positions; // Contiene las posiciones de los boosters selecionados (el booster seleccionado clonBoosters [i] tendra la posicion positions [i])

	void Start () {
		clonBoosters = new GameObject [this.amount];
		positions = new Vector3 [this.amount];

		InvokeRepeating ("createBoosters", timeCreateBooster, timeCreateBooster);
	}

	// Crea y posiciona en el tablero un numero dados de boosters (por defecto dos boosters)
	private void createBoosters ()
	{
		//Debug.Log("Crear Boosters");
		for (int i = 0; i < amount; i++) {
			GameObject newBooster = getBooster();

			positions [i] = getFreePosition();
			//Debug.Log(positions[i]);

			clonBoosters [i] = (GameObject) Instantiate (newBooster, positions [i], newBooster.transform.rotation);

			StartCoroutine(destroyBoosters());
		}
	}

	// Corutica que destruye todos los booster del tablero
	private IEnumerator destroyBoosters ()
	{
		//Debug.Log("Destruir Booster");
		yield return new WaitForSeconds(timeDestroyBooster);

		if (clonBoosters.Length > 0) {

			for (int i = 0; i < clonBoosters.Length; i++) {
				Destroy(clonBoosters[i]);
			}
		}
	}

	// Obtiene una posicion libre de objetos en el tablero de juego
	private Vector3 getFreePosition ()
	{
		float x = Random.Range(1,28);
		float z = Random.Range(1,18);
		
		Vector3 position = new Vector3 (x, 1, z);

		Collider [] colliders = Physics.OverlapSphere(position, 0.1f);

		if (colliders.Length > 0) {
			return getFreePosition();
		}
		else {
			return position;
		}
	}

	// Obtiene un booster aleatorio del array boosters, luego comprueba que no este selecionado ya y de no ser asi lo debuelve,
	//    el proceso es repitido hasta que obtenga un booster no selecionado con aterioridad
	private GameObject getBooster ()
	{
		int boostersArrayIndex;
		GameObject newBooster;
		bool alreadyExist;

		do {
			alreadyExist = false;

			boostersArrayIndex = Random.Range(0, boosters.Length-1);
			newBooster = boosters [boostersArrayIndex];

			if (clonBoosters.Length > 0) {
				foreach (GameObject boosterElement in clonBoosters) {
					if (boosterElement != null && boosterElement.name == newBooster.name) {
						alreadyExist = true; // El booster nuevo ya esta en la lista de seleccionados, por  tanto se eligira uno nuevo aleatorio
					}
				}
			}

		} while (alreadyExist == true);


		return newBooster;
	}
}