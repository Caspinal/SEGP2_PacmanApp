using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	// Use this for initialization

	public DataHolder DH;
	public GameObject MC;
	public Pellet PDS;
	public PPellet PPS;
	public Ghost G1S;
	public GhostV2G1 G2S;
	public GhostG3 G3S;
	public GhostG4 G4S;
	public GameObject PD;
	public GameObject detectedGhost;
	



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

		if (other.tag == "Power"){
			PD = other.gameObject;
			PPS = PD.GetComponent<PPellet>();
			PPS.HasBeenCollected = true;


		}


// if PacMan colides with a Ghost then deduct a live by dectementing the lives varible in DataHolder 
		if(other.tag == "Ghost"){
			if(DH.powerup == false){
			DH.lives -= 1;
			DH.globalRespawn = true;
			}else{
//				if("G1" == other.gameObject.name || "G1(Clone)" == other.gameObject.name){
//					detectedGhost = other.gameObject;
//					G1S = detectedGhost.GetComponent<Ghost>();
//					G1S.HasBeenEaten = true;
//					Debug.Log("G1 HAS BEEN EAT");
//				}
//
//				if("G2" == other.gameObject.name || "G2(Clone)" == other.gameObject.name){
//					detectedGhost = other.gameObject;
//					G2S = detectedGhost.GetComponent<GhostV2G1>();
//					G2S.HasBeenEaten = true;
//					Debug.Log("G2 HAS BEEN EAT");
//				}
//
//				if(G3 == other){
//					detectedGhost = other.gameObject;
//					G3S = detectedGhost.GetComponent<GhostG3>();
//				}
//
//				if(G4 == other){
//					detectedGhost = other.gameObject;
//					G4S = detectedGhost.GetComponent<GhostG4>();
//				}
				detectedGhost = other.gameObject;
				G2S = detectedGhost.GetComponent<GhostV2G1>();
				G2S.HasBeenEaten = true;
				Debug.Log("GHOST HAS BEEN EAT");
				DH.Score += 100;
			}
		}
	}
	
	
	
}
