using UnityEngine;
using System.Collections;

public class balaScr : MonoBehaviour {

    public GameObject BalaOrg;
    public GameObject Cabezon;
    public GameObject Gusano;

    private Transform balaTransform;
    private Transform cabezonTransform;

    // Se instancia con static porque el objeto Bala se duplica y es necesario usar el datos en todas las instancias (patron Singleton)
    static private int fuerzaDisparo;
    static private int maxBalas;
    static private int balasActivas;

    void Start()
    {
        // Filtra que solo se aplique al objeto Bala Original, y no a sus clones
        // Así no se machacan los valores en cada instancia
        if (this.transform.name == "bala")
        {
            cabezonTransform = Cabezon.transform;
            balaTransform = BalaOrg.transform;
            fuerzaDisparo = 15;
            balasActivas = 0;
            maxBalas = 2;
        }
    }

    void Update()
    {
        // Filtra que solo se aplique al objeto Bala Original, y no a sus clones
        if (this.transform.name == "bala")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                disparaBala();
            }
        }

    }

    void disparaBala()
    {
        if (balasActivas < maxBalas)
        {
            // Crea una nueva bala, la activa y le aplica una fuerza en base a la orientacion de la cabeza
            GameObject clonBala = (GameObject)Instantiate(BalaOrg, balaTransform.position, balaTransform.rotation);
            clonBala.GetComponent<MeshRenderer>().enabled = true;
            clonBala.GetComponent<CapsuleCollider>().enabled = true;
            clonBala.GetComponent<Rigidbody>().AddForce(cabezonTransform.right * fuerzaDisparo, ForceMode.Impulse);
            clonBala.name = "clonBala" + balasActivas;
            balasActivas += 1;
        }
    }


    void OnCollisionEnter(Collision colisionador)
    {
        // Si impactó contra el cuerpo del gusano informa a este manualmnete (ya que se destruye antes de que la colision pueda ser propagada por el sistema)
        if (colisionador.gameObject.tag == "cuerpo")
        {
            Gusano.GetComponent<gusanazoScr>().gusanoColisiona(colisionador);
        }

        // Destruye la bala
        Destroy(this.gameObject);
        balasActivas -= 1;
    }
}
