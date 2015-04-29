using UnityEngine;
using System.Collections;

public class PPellet : MonoBehaviour {
	public bool HasBeenCollected = false;

	public DataHolder DH;
	public GameObject MC;
	
	void Start () {
		// get dataholder
		 MC = GameObject.Find("Main Camera");
		 DH = MC.GetComponent<DataHolder>();
	}
	

	void Update () {
		

		if (HasBeenCollected) {
			DH.powerup = true;// set bool in data holder
			Destroy(gameObject); // remove pellet

			DH.PelletCount = (DH.PelletCount -1); // decrement pellet count
			DH.Score = (DH.Score + 50);// increment scores 

		}
	}
}
