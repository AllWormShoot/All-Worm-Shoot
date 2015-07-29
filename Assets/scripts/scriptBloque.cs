using UnityEngine;
using System.Collections;

public class scriptBloque : MonoBehaviour {

    public int alto;
    public int ancho;

    public int dureza = 0;
    public int velocidad = 2;
    public int puntos = 100;
   
    public bool esFijo = true; //Indica si es un borde o un obstaculo fijo, provoca daños tras colisionar
    public bool esDestructible = false; //Indica si el objeto se destruye o no tras colisión
    public bool esMovible = false; //Indica si el objeto se destruye o no tras colisión

    //public Material[] arrayMaterial; //Arrastro bloques de materials y le ponemos size fijo

    public Material materialDureza3;
    public Material materialDureza2;
    public Material materialDureza1;

    public GameObject estados;

    // Private
    //private Rigidbody rb;
    private Renderer rend;

    private Material material; // Material, relacionado con el tipo de objeto (Fijo, Destructibles (3 tipos))
    //private float thrust = 50;

    private KeyCode moveLeft = KeyCode.LeftArrow;
    private KeyCode moveRight = KeyCode.RightArrow;
    private KeyCode moveForward = KeyCode.UpArrow;
    private KeyCode moveBackward = KeyCode.DownArrow;

    //bool protectColisionBloque = false;

    private Vector2 input;

	// Use this for initialization
	void Start () {
       // rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //rb.AddForce(-transform.forward * thrust);
        if (esMovible)
        {
            if (Input.GetKey(moveLeft))
            {
                transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            }

            if (Input.GetKey(moveRight))
            {
                transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(moveForward))
            {
                transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
            }
            if (Input.GetKey(moveBackward))
            {
                transform.Translate(Vector3.back * velocidad * Time.deltaTime);
            }
        }

        //Debug.Log("Dureza " + dureza);
        if (dureza <= 0)
        {
            DestruirObjeto();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Entrando",this.gameObject);
        if (this.tag != collision.gameObject.tag) {

            switch (collision.gameObject.tag) //ANT: Hay que cambiarlo a tipo o Tag, no Name
            {
                case "spawnBullet": //Pruebas
                
                    if (esDestructible) 
                    {
                        dureza = dureza - 1;
                        estados.GetComponent<Counters>().modifyPoints(puntos);
                        //Destroy(collision.gameObject);
                        CambiarMaterial();
                        
                    }
                    break;
                case "cabezon": //Gusano
                    //Fin de partida
                    estados.GetComponent<Counters>().endGame(0);
                    break;
                default:
                    break;
            }
        }
    }

    void CambiarMaterial()
    {
        switch (dureza)
        {
            case 3: 
                rend.material = materialDureza3;
                break;
            case 2:
                rend.material = materialDureza2;
                break;
            case 1:
                rend.material = materialDureza1;
                break;
            default:
                break;
        }
    }
    void DestruirObjeto() {
        Destroy(gameObject);
        Debug.Log("Destruido");
    }
}
