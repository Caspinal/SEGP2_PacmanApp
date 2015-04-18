using UnityEngine;
using System.Collections;

public class CollisionDetectorG : MonoBehaviour {

	// Use this for initialization

	public DataHolder DH;
	public GameObject MC;
	public Pellet PDS;
	public PPellet PPS;
	public GameObject PD;

	public GhostV2G1 G2S;
	public GameObject detectedGhost;

	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			if(DH.powerup == false){
				DH.lives -= 1;
				DH.globalRespawn = true;
				Debug.Log("Ghost ran into pacman");
			}else{

				detectedGhost = other.gameObject;
				G2S = detectedGhost.GetComponent<GhostV2G1>();
				G2S.HasBeenEaten = true;
				Debug.Log("GHOST HAS BEEN EAT");
				DH.Score += 100;

			}
		}
}

void OnTriggerEnter(Collider other){

		// if PacMan colides with a Pellet then set the current instances HasBeenCollected boolean to true 
//		if (other.tag == "Collectable"){
//			PD = other.gameObject;
//			PDS = PD.GetComponent<Pellet>();
//			PDS.HasBeenCollected = true;
//		}
//
//		if (other.tag == "Power"){
//			PD = other.gameObject;
//			PPS = PD.GetComponent<PPellet>();
//			PPS.HasBeenCollected = true;
//
//
//		}


// if PacMan colides with a Ghost then deduct a live by dectementing the lives varible in DataHolder 
		if(other.tag == "Player"){
			if(DH.powerup == false){
			DH.lives -= 1;
			DH.globalRespawn = true;
				Debug.Log("Ghost ran into pacman");
			}
		}
	}
	
	
	
}
