#pragma strict

function Start () {

}

function Update () {
transform.Translate(Vector3.up * -Mathf.Sin(Time.time * 2.16) * 0.005);
transform.Rotate((Vector3.up * Mathf.Sin(Time.time * 2.16) * (0.30 + 0.25)));

}