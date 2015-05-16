#pragma strict

var thisTransform: Transform;
var posAnt: Transform;

function Start () {
	thisTransform = this.transform;
}

// Se invoca desde gusano.moeveWorm()
function mueve(posCabezon){
	//Debug.Log("Jola!!!");
	
	// Posiciona los cuerpos en la posicion del anterior
	var pos = posCabezon;
	var posAnt;
	for (var child : Transform in transform) {
    	posAnt = pos;
    	pos = child.position;
    	child.position = posAnt;
	}
}


function Update () {
}