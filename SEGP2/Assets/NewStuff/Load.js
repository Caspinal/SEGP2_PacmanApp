#pragma strict

function Start () {

}

var gamepaused = false;


function StartGame(){
Application.LoadLevel("test");
Debug.Log("START_GAME");
}
function QuitGame(){

Application.Quit();
Debug.Log("QUIT_GAME");
}

function options(){

Application.LoadLevel("Options");
}

function menu(){
Application.LoadLevel("welcome");

}

function Update () {

//Application.loadLevel(Resources.Load());

if(Input.GetKey ("space")){

//Transform.(0,0,90);
Application.LoadLevel("test");



}

if(Input.GetKey ("return")){

//Transform.(0,0,90);
Application.LoadLevel("welcome");
}

//if( gamepaused == true){
//		Time.timeScale=0.0;
//		
//	}else if(gamepaused == false){
//		Time.timeScale = 1.0;
//	}

if(Input.GetKey ("p")){

	
	Debug.Log("toggle Play state");
	if(Time.timeScale >= 1.0){ 
	Time.timeScale = 0.0;
	}else{Time.timeScale =1.0;}
}
}
