using UnityEngine;
using System.Collections;

public class GhostV2G1: MonoBehaviour {

	// Use this for initialization


	public DataHolder DH;	// DataHolder variable
	public GameObject MC;  	// GameObject variable

	//public PacManV2 PM;
	public GameObject MC2;
	int GhostX;				// x-axis for ghost
	int GhostY;				// y-axis for ghost


	public int PacmanX;		// stores x-axis for pacman
	public int PacmanY;		// sotres y-axis for pacman
	
	bool moving = true;		// is something moving
	bool trigger = true;	// has the game started

	//PacManV2 PacManV2;

	//Connors
	float MoveDelayTimer = 2f;
	int SpawnPosX;
	int SpawnPosY;
	public bool HasBeenEaten;
	Material defaultTex;
	Material blue;
	Vector3 targetpos;
	Quaternion origaRotation;


	int counter = 2;


	void Start () {			// once per frame
		MC = GameObject.Find("Main Camera"); 	// finds the main camera object  
		DH = MC.GetComponent<DataHolder>();		// gets the dataHolder script attached to the camera

//		MC2 = GameObject.Find ("PacMan 1(Clone)");
//
//		if (GameObject.Find ("PacMan 1(Clone)") == null) {
//			Debug.Log ("null");
//		} else {
//			Debug.Log ("Not null");
//		}

//		PM = MC.GetComponent<PacManV2>();
	}

	
	// Update is called once per frame

	IEnumerator CheckForPath() { 

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'S' &&
			DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' &&
			DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
			DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {

			if(PacmanX < GhostX) {
				counter = 3;
			} else {
				counter = 1;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
			DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
			DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' && 
			DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {

			if(PacmanX < GhostX) {
				counter = 3;
			} else if (PacmanY > GhostY) {
				counter = 0;
			} else {
				counter = 2;
			}
		}

		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {

			if(PacmanX > GhostX) {
				counter = 1;
			} else {
				counter = 0;
			}
		}

		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {

			if(PacmanX > GhostX) {
				counter = 1;
			} else if (PacmanY > GhostY) {
				counter = 0;
			} else {
				counter = 2;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {

			if(PacmanX < GhostX) {
				counter = 3;
			} else {
				counter = 0;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {

			if(PacmanY < GhostY) {
				counter = 2;
			} else if (PacmanX > GhostX) {
				counter = 1;
			} else {
				counter = 3;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {

			if(PacmanY > GhostY) {
				counter = 0;
			} else if (PacmanX > GhostX) {
				counter = 1;
			} else {
				counter = 3;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {

			if(PacmanX > GhostX) {
				counter = 1;
			} else {
				counter = 2;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY -1] == 'o') && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {
			
			if(PacmanX <GhostX) {
				counter = 3;
			} else {
				counter = 2;
			}
		}

		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p') {
			
			if(PacmanX > GhostX) {
				counter = 1;
			} else if (PacmanX < GhostX){
				counter = 3;
			} else if (PacmanY > GhostY) {
				counter = 0;
			} else {
				counter = 2;
			}
		}


		yield return new WaitForSeconds (0.16f);
	}

	IEnumerator PressUpKey() {
		while (!(Input.GetKey ("up"))) {
			yield return new WaitForSeconds (0.10f);
		}
		StartCoroutine (StartMoving ());
	}

	IEnumerator StartMoving() {
		while (moving) {
			UpdatePacManPosition ();
			StartCoroutine (CheckForPath ());

			switch (counter) {
			case 0:
				if (DH.StoredRefCoordinates [GhostX, GhostY + 1] != 'w') {
					GhostY++;
					targetpos = DH.StoredCoordinates[GhostX,GhostY];

					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z + 0.1f));
					transform.position = targetpos;

				}
				yield return new WaitForSeconds (0.025f);
				break;
			

			case 1:
				if (DH.StoredRefCoordinates [GhostX + 1, GhostY] != 'w') {
					GhostX++;

					targetpos = DH.StoredCoordinates[GhostX,GhostY];
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x + 0.1f),transform.position.y,transform.position.z);
					transform.position = targetpos;



				}
				yield return new WaitForSeconds (0.025f);
				break;

			case 2: 
				if(DH.StoredRefCoordinates[GhostX, GhostY-1] != 'w') {
					GhostY--;
					//transform.position = new Vector3(GhostX, 0, GhostY);

					targetpos = DH.StoredCoordinates[GhostX,GhostY];
					
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3(transform.position.x,transform.position.y,(transform.position.z - 0.1f));
					transform.position = targetpos;



				}
				yield return new WaitForSeconds (0.025f);
				break;

			case 3:
				if(DH.StoredRefCoordinates[GhostX-1, GhostY] != 'w') {
					GhostX--;
					targetpos = DH.StoredCoordinates[GhostX,GhostY];
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					yield return new WaitForSeconds(0.01f);
					transform.position = new Vector3((transform.position.x - 0.1f),transform.position.y,transform.position.z);
					transform.position = targetpos;
				}
				yield return new WaitForSeconds (0.025f);
				break;
			default:
				Debug.Log("ERROR");
				break;
			}
		}
	}

	void UpdatePacManPosition() {
		PacmanX = DH.PacmanX;
		PacmanY = DH.PacmanX;
	}

	void Update () {
		if (trigger == true) {
			//GameLogic GameLogic = MC.GetComponent<GameLogic>();

			//PacManV2 PacManV2 = MC2.GetComponent<PacManV2>();

			//PacManV2 = MC2.GetComponent<PacManV2>();
			origaRotation = transform.rotation;

			if(gameObject.name == "G1" || gameObject.name == "G1(Clone)" ){
				GhostX = DH.ClydeX;
				GhostY = DH.ClydeY;
			}

			if(gameObject.name == "G2" || gameObject.name == "G2(Clone)" ){
				GhostX = DH.PinkyX;
				GhostY = DH.PinkyY;
			}

			if(gameObject.name == "G3" || gameObject.name == "G3(Clone)" ){
				GhostX = DH.InkyX;
				GhostY = DH.InkyY;
			}

			if(gameObject.name == "G4" || gameObject.name == "G1(Clone)" ){
				GhostX = DH.BlinkyX;
				GhostY = DH.BlinkyY;
			}
			// get ghost!
			SpawnPosX = GhostX;
			SpawnPosY = GhostY;
			//hold the position of PacMan
		//	PacmanY = GameLogic.PacmanY;
	//		PacmanX = GameLogic.PacmanX;

			//PacmanX = PacManV2.pacmanX;
			//PacmanY = PacManV2.pacmanY;

//			Debug.Log ("PacmanX in  Update = " + PacmanX);
//			Debug.Log ("PacmanY in  Updata = " + PacmanY);


			blue = Resources.Load("Dblue") as Material;
			defaultTex = renderer.material;

			trigger = false;
			StartCoroutine (PressUpKey ());
		}

		if (DH.powerup == true) {
			renderer.material = blue;
		}
		
		if (DH.powerup == false) {
			renderer.material.color = new Color(1f,1f,1f,1f);
			renderer.material = defaultTex;
		}
		
		if (HasBeenEaten == true) {
			
			renderer.material = defaultTex;
			GhostX = SpawnPosX;
			GhostY = SpawnPosY;
			transform.position = DH.StoredCoordinates[GhostX,GhostY];
			moving = true;
			counter = 2;
			//startCoroutine (StartMoving ());
			HasBeenEaten = false;
		}

//		if(DH.globalRespawn == true){
//			GhostX = SpawnPosX;
//			GhostY = SpawnPosY;
//			transform.position = new Vector3(GhostX, 0, GhostY);
//			if(MoveDelayTimer > 1){
//				moving = false;
//				MoveDelayTimer -= Time.deltaTime;
//			}else{
//				moving = true;
//				counter = 2;
//				MoveDelayTimer = 2f;
//			}

			if (DH.globalRespawn == true) {
				//if (spawntrigger == false){
				StopCoroutine (StartMoving ());

				counter = 2;
				GhostX = SpawnPosX;
				GhostY = SpawnPosY;
				transform.position = DH.StoredCoordinates[GhostX,GhostY];
				//respawn();
				Debug.Log("respawning");
				//StartCoroutine (respawn ());
				//}
			}


			//StartCoroutine (StartMoving ());
		}


}