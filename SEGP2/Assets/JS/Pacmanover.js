#pragma strict

function Start () {

}

function Update () {
// Shrink and rotate pacman
transform.Rotate(0,20,0);
transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-0.1,-0.1,-0.1),Time.deltaTime * 1);
restart();
}

function restart(){
	//After 3 seconds load the welcome screen to restart the game
	yield WaitForSeconds (3);
	Application.LoadLevel("Score");
}