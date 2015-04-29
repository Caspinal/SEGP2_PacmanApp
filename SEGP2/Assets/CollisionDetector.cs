using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	// Use this for initialization

	public DataHolder DH;
	public GameObject MC;
	public Pellet PDS;
	public PPellet PPS;
	public Ghost G2S;
	public GameObject PD;
	public GameObject detectedGhost;
	bool starttimer = false;
	float time = 2f;





	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame
	void Update () {
		if (starttimer){
			
			time -= Time.deltaTime;
		}
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

		if (other.tag == "SpecialItem"){
			DH.Score += 300;
			Destroy(other.gameObject);
			DH.SpecialExists = false;
			DH.ItemRespawnTimer = 10f;
		}


	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ghost"){
			if(DH.powerup == false){

				DH.globalRespawn = true;

				DH.lives -= 1;
			
				Debug.Log("Ghost ran into pacman");
			}else{
				
				detectedGhost = other.gameObject;
				G2S = detectedGhost.GetComponent<Ghost>();
				G2S.HasBeenEaten = true;
				Debug.Log("GHOST HAS BEEN EAT");
				DH.Score += 100;
				
			}
		}
	}
	
}
