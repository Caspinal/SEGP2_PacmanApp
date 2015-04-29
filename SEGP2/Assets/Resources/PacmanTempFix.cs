using UnityEngine;
using System.Collections;

public class PacmanTempFix : MonoBehaviour {

	// Use this for initialization

	bool trigger = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (trigger == true) {
			Debug.Log("PacmanTempFix1" + transform.position);
			Vector3 normal = transform.position;
			normal.y = -0.4f;
			transform.position = normal;
			trigger = false;
			Debug.Log("PacmanTempFix2" + transform.position);
		}

	}
}
