#pragma strict

function Start () {

}

function Update () {

//transform.RotateAround(Vector3.zero,Vector3.zero,val * Time.deltaTime);

transform.RotateAround(Vector3.zero,Vector2.up, 10 * Time.deltaTime);
}
