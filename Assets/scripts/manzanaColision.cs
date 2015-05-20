using UnityEngine;
using System.Collections;

public class manzanaColision : MonoBehaviour {

    public GameObject estados;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Colision Apple con " + collision.gameObject.name);
        switch (collision.gameObject.name)
        {
            case "gusanazo":case "cuerpo":
                estados.GetComponent<Counters>().decreaseApples();
                Destroy(this.gameObject);
                break;
            default:
                break;
        }

    }
}
