using UnityEngine;
using System.Collections;

public class manzanaColision : MonoBehaviour {

    public GameObject estados;
    public int applePoints = 100;

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Colision Apple con " + collision.gameObject.name);
        switch (collision.gameObject.name)
        {
            case "gusanazo":case "cuerpo":
                estados.GetComponent<Counters>().decreaseApples();
                estados.GetComponent<Counters>().modifyPoints(applePoints);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
