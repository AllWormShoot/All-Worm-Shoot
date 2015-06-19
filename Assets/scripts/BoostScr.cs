using UnityEngine;
using System.Collections;

public class BoostScr : MonoBehaviour 
{
	public float timeCreateBooster = 20; // Tiempo en segundos que tardara en crear un booster
	public float timeDestroyBooster = 10; // Tiempo en segundos que tardara en destruir un booster
	public GameObject [] boosters ; // Array que contendra una coleccion de objetos booster
	public int amount = 2; // Cantidad de booster que se van a generar

	private float timer = 0; // Controladora del tiempo transcurrido
	private GameObject [] clonBoosters; // Clon de un objeto booster elegido aleatorimente
	private Vector3 [] positions; // Contiene las posiciones de los boosters clonados

	void Start () {
		clonBoosters = new GameObject [this.amount];
		positions = new Vector3 [this.amount];

		InvokeRepeating ("createBoosters", timeCreateBooster, timeCreateBooster);
	}

	// Crea y coloca en el tablero un numero dados de boosters, por defecto dos
	private void createBoosters ()
	{
		Debug.Log("Crear Boosters");
		for (int i = 0; i < amount; i++) {
			GameObject newBooster = getClonBooster();

			positions [i] = getFreePosition();
			Debug.Log(positions[i]);

			clonBoosters [i] = (GameObject) Instantiate (newBooster, positions [i], Quaternion.identity);

			StartCoroutine(destroyBoosters());
		}
		Debug.Log(clonBoosters.Length);
	}

	private IEnumerator destroyBoosters ()
	{
		yield return new WaitForSeconds(timeDestroyBooster);

		Debug.Log("Destruir Booster");
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

	// Obtiene un booster aleatorio del array boosters, luego comprueba que no exista y lo debuelve, el proceso se repite hasta que
	//    obtenga el booster no repetido
	private GameObject getClonBooster ()
	{
		int boostIndex;
		GameObject newBooster;
		bool alreadyExist = false;

		do {
			boostIndex = Random.Range(0, boosters.Length-1);
			newBooster = boosters [boostIndex];

			foreach (GameObject boosterElement in clonBoosters) {
				if (boosterElement == newBooster) {
					alreadyExist = true;
				}
			}
		} while (alreadyExist == true);

		return newBooster;
	}
}