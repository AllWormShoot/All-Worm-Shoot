using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
    
    public GameObject Bala;
    public int velocidad;
    public bool balaDisparada = false;
	public GameObject Cabezon;
	public float tiempoDestruirBala = 0.8f;

    private GameObject shot;
    //private KeyCode fireButton = KeyCode.Space;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!balaDisparada)
            {
				shot = Instantiate(Bala, this.transform.position, this.transform.rotation) as GameObject;
				shot.GetComponent<MeshRenderer>().enabled = true;
                shot.GetComponent<CapsuleCollider>().enabled = true;
				shot.GetComponent<Rigidbody>().AddForce(Cabezon.transform.right * velocidad);
                balaDisparada = true;
			}
            Invoke("destruirBala", tiempoDestruirBala);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entrando",this.gameObject);
        if (this.tag != collision.gameObject.tag)
        {
            switch (collision.gameObject.tag)
            {
                case "manzana":
                    Destroy(this.gameObject);
                    break;
                case "irrompible": //Pruebas
                    Destroy(this.gameObject);
                    break;
                default:
                    break;
            }
        }
    }

	void destruirBala(){
		//Destroy(shot);
        balaDisparada = false;
	}
}
