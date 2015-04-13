using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	// Use this for initialization

	public DataHolder DH;
	public GameObject MC;
	public Pellet PDS;
	public GameObject PD;

	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

void OnTriggerEnter(Collider other){

		// if PacMan colides with a Pellet then set the current instances HasBeenCollected boolean to true 
		if (other.tag == "Collectable"){
			PD = other.gameObject;
			PDS = PD.GetComponent<Pellet>();
			PDS.HasBeenCollected = true;
		}

// if PacMan colides with a Ghost then deduct a live by dectementing the lives varible in DataHolder 
		if(other.tag == "Ghost"){
			DH.lives -= 1;
		}
	}
	
	
	
}
