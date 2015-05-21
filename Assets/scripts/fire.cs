using UnityEngine;
using System.Collections;

public class fire : MonoBehaviour {
    
    public GameObject Bala;
    public int velocidad;
    public bool balaDisparada = false;
	public GameObject Cabezon;
	public float tiempoDestruirBala = 0.8f;
    public GameObject Gusano;

    private GameObject shot;
    //private KeyCode fireButton = KeyCode.Space;
	
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

    void OnCollisionEnter(Collision colisionador)
    {
        // Siempre se destruye la bala al impactar con algo
        Destroy(this.gameObject);
        balaDisparada = false;
        
        // Si impactó contra el cuerpo del gusano informa a este manualmnete (ya que se destruye antes de que la colision pueda ser propagada por el sistema)
        if (colisionador.gameObject.tag == "cuerpo")
        {
            Gusano.GetComponent<gusanazoScr>().gusanoColisiona(colisionador);
        }
    }

	void destruirBala(){
		//Destroy(shot);
        balaDisparada = false;
	}
}
