using UnityEngine;
using System.Collections;

// collectable pellet class 

public class Pellet : MonoBehaviour {
	public bool HasBeenCollected = false;

	public DataHolder DH;
	public GameObject MC;
	
	void Start () {
		 MC = GameObject.Find("Main Camera");
		 DH = MC.GetComponent<DataHolder>();
	}
	
	// UpdaDatate is called once per frame
	void Update () {
		

		if (HasBeenCollected) {

			Destroy(gameObject); // destroy once collected 

			DH.PelletCount = (DH.PelletCount -1);
			DH.Score = (DH.Score + 10);
			// add score decremnet pellet count
		}
	}
}
