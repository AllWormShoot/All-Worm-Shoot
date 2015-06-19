using UnityEngine;
using System.Collections;

public class manzanaColision : MonoBehaviour {

    public GameObject estados;

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
