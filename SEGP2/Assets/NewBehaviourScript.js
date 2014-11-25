#pragma strict

var rotx:float = 0.0;

function Start () {

}

function Update () {

rotx = (Time.deltaTime*(Mathf.PI*360));
transform.Rotate(0,rotx,0);

}