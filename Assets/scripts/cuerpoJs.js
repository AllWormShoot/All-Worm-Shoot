#pragma strict

private var thisTransform: Transform;
private var posAnt: Transform;

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

function crece(){
	//Debug.Log("Hijo de puta");
	var cuerpo = thisTransform.GetChild(thisTransform.childCount-1);
	var clon = Instantiate(cuerpo, cuerpo.transform.position, cuerpo.transform.rotation);
	clon.transform.parent = cuerpo.transform.parent;
}