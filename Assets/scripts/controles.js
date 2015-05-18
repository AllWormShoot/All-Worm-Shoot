#pragma strict
var direcc = "der"; // izq, der, abj, arr

function Start () {

}

function Update () {
	if(Input.GetKeyDown(KeyCode.UpArrow) && direcc != "abj"){
		direcc = "arr";
	}
	else if(Input.GetKeyDown(KeyCode.DownArrow) && direcc != "arr"){
		direcc = "abj";
	}
	else if(Input.GetKeyDown(KeyCode.LeftArrow) && direcc != "der"){
		direcc = "izq";
	}
	else if(Input.GetKeyDown(KeyCode.RightArrow) && direcc != "izq"){
		direcc = "der";
	}
}