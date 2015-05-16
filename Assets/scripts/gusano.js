#pragma strict

var terrenoLocal: GameObject;
var cuerposLocal: GameObject;
var tiempoMueve: float = 0.2;
var posX: int = 2;
var posZ: int = 2;
var maxPosX: int = 0;
var maxPosZ: int = 0;
var cuerposLocalTransform: Transform;
var terrenoLocalTransform: Transform;

function Start () {
	cuerposLocalTransform = cuerposLocal.transform;
	terrenoLocalTransform = terrenoLocal.transform;
	maxPosX = terrenoLocal.GetComponent(terreno).ancho;
	maxPosZ  = terrenoLocal.GetComponent(terreno).alto;
	var pos = terrenoLocalTransform.GetChild(posX).transform.GetChild(posZ).position;
	pos.y = 1;
	this.transform.position = pos;
	Invoke('mueveWorm', tiempoMueve);
	
}

function mueveWorm(){

	// Direccion del movimiento
	var direcc = this.GetComponent(controles).direcc;
	if(direcc=='arr' && posZ < maxPosZ){	
		posZ++; 
	}
	else if(direcc=='abj' && posZ > 0){	
		posZ--; 
	}
	else if(direcc=='izq' && posX > 0){	
		posX--; 
	}
	else if(direcc=='der' && posX < maxPosX){	
		posX++; 
	}
	
	// Extrae la nueva posicion desde las baldosas y posiciona
	var pos = terrenoLocalTransform.GetChild(posX).transform.GetChild(posZ).position;
	pos.y = 1;
	var posAnt = this.transform.position;
	this.transform.position = pos;
	
	// Posiciona los cuerpos gusaniles
	if(posAnt != pos){
   		cuerposLocal.GetComponent(cuerpoJs).mueve(posAnt);
    }
	
	// Recursivo
	Invoke('mueveWorm', tiempoMueve);
}


function Update () {
 
}










