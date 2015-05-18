using UnityEngine;
using System.Collections;

public class manzanaColision : MonoBehaviour {

    public GameObject gui;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision Apple");
        switch (collision.gameObject.name)
        {
            case "gusanazo":
                gui.GetComponent<Counters>().decreaseApples();
                Destroy(this.gameObject);
                break;
            default:
                break;
        }

    }
}
