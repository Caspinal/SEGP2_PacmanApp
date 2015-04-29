using UnityEngine;
using System.Collections;

public class CollisionDetectorG : MonoBehaviour {

	// Use this for initialization

	public DataHolder DH;
	public GameObject MC;
	public Pellet PDS;
	public PPellet PPS;
	public GameObject PD;

public Ghost G2S;
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
				//DH.lives -= 1;
				DH.globalRespawn = true;
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
