#pragma strict

var terrenoLocal: GameObject;
var cuerposLocal: GameObject;
var tiempoMueve: float = 0.2;
var posX: int = 9;
var posZ: int = 3;
var maxPosX: int = 0;
var maxPosZ: int = 0;
var cuerposLocalTransform: Transform;
var terrenoLocalTransform: Transform;
var manzanasQuedan: int = 2;

//private var guiTransform: Transform; 

function Start () {
    //guiTransform = gui.transform;
	cuerposLocalTransform = cuerposLocal.transform;
	terrenoLocalTransform = terrenoLocal.transform;
	maxPosX = terrenoLocal.GetComponent(terreno).ancho;
	maxPosZ  = terrenoLocal.GetComponent(terreno).alto;
	var pos = getPosTablero();
	this.transform.position = pos;
	Invoke('mueveWorm', tiempoMueve);
	
	/*for(var child: Transform in terrenoLocalTransform){
		Debug.Log(child.name);
	}*/
}

function mueveWorm(){

	// Direccion del movimiento
	var direcc = this.GetComponent(controles).direcc;
	if(direcc=='arr' && posZ < maxPosZ-1){	
		posZ++; 
		transform.right = Vector3.forward;
	}
	else if(direcc=='abj' && posZ > 0){	
		posZ--; 
		transform.right = -Vector3.forward;
	}
	else if(direcc=='izq' && posX > 0){	
		posX--; 
		transform.right = -Vector3.right;
	}
	else if(direcc=='der' && posX < maxPosX-1){	
		posX++; 
		transform.right = -Vector3.left;
	}
	
	// Extrae la nueva posicion desde las baldosas y posiciona
	var pos = getPosTablero();
	var posAnt = this.transform.position;
	this.transform.position = pos;
	
	// Posiciona los cuerpos gusaniles
	if(posAnt != pos){
   		cuerposLocal.GetComponent(cuerpoJs).mueve(posAnt);
    }
	
	// Recursivo
	Invoke('mueveWorm', tiempoMueve);
}

function getPosTablero(){
	var pos = terrenoLocalTransform.GetChild(posX).transform.GetChild(posZ).position;
	pos.y = 1;
	return pos;
}

function Update () {
 if(Input.GetKeyDown(KeyCode.A)){
		comeManzana();
	}
}

function comeManzana(){
	cuerposLocalTransform.GetComponent(cuerpoJs).crece();
     manzanasQuedan = manzanasQuedan - 1;
     if (manzanasQuedan <= 0){
        Application.LoadLevel(Application.loadedLevel + 1);
     }
        
    //guiTransform.GetComponent(Counters).modifyPoints(200);
}

function muereBicho(){
	Application.LoadLevel(Application.loadedLevel);
}

function OnCollisionEnter(colision: Collision){
	Debug.Log(colision.gameObject.tag);
	if(colision.gameObject.tag == 'manzana'){
		comeManzana();
        Destroy(colision.gameObject);
	}
	else if(colision.gameObject.tag == 'rompible'){
		muereBicho();
	}
	else if(colision.gameObject.tag == 'irrompible'){
		muereBicho();
	}
	else if(colision.gameObject.tag == 'cuerpo'){
		muereBicho();
	}
	
}














