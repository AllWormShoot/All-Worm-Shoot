#pragma strict
var direcc = "der"; // izq, der, abj, arr

function Start () {

}

function Update () {
	if(Input.GetKey(KeyCode.UpArrow) && direcc != "abj"){
		direcc = "arr";
	}
	else if(Input.GetKey(KeyCode.DownArrow) && direcc != "arr"){
		direcc = "abj";
	}
	else if(Input.GetKey(KeyCode.LeftArrow) && direcc != "der"){
		direcc = "izq";
	}
	else if(Input.GetKey(KeyCode.RightArrow) && direcc != "izq"){
		direcc = "der";
	}
}