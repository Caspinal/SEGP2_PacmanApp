using UnityEngine;
using System.Collections;

public class Ghost: MonoBehaviour {
	
	// Use this for initialization
	
	
	public DataHolder DH;	// DataHolder variable
	public GameObject MC;  	// GameObject variable
	

	public GameObject MC2;
	int GhostX;				// x-axis for ghost
	int GhostY;				// y-axis for ghost
	
	
	public int PacmanX;		// stores x-axis for pacman
	public int PacmanY;		// sotres y-axis for pacman
	
	bool moving = true;		// is something moving
	bool trigger = true;	// has the game started
	int random1 = 0;
	int random2 = 0;
	int randomValue = 0;
	int randomIndexArray = 0;
	int[] arrayOfPellets = new int[4];
	
	
	int SpawnPosX;				// x - axis spawn position
	int SpawnPosY;				// y - axis spawn position
	public bool HasBeenEaten;	// checks if ghost is eaten 
	Material defaultTex;		// ghost material
	Material blue;				// ghost colour
	Vector3 targetpos;			// position where ghost will move
	Quaternion origaRotation;	// rotation of ghost
	
	
	int counter = 2;			// so that the ghost travels down when he starts off 
	// this helps it to come out of the ghost enclosure
	
	void Start () {								
		MC = GameObject.Find("Main Camera"); 	// finds the main camera object  
		DH = MC.GetComponent<DataHolder>();		// gets the dataHolder script attached to the camera

	}
	
	

	
	IEnumerator CheckForPath() { 
		randomValue = Random.Range (random1, random2);
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'S' &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') &&
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			
			if(randomValue == 1) {
				randomIndexArray = Random.Range(0,3);
				arrayOfPellets[0] = 1;
				arrayOfPellets[1] = 2;
				arrayOfPellets[2] = 3;
				counter = arrayOfPellets[randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				
				if(PacmanX < GhostX) { 		    // is pacman to the left of the ghost
					counter = 3;        		// if so, then move ghost left 
				} else if (PacmanY < GhostY) { 	// if not, is pacman below the ghost 
					counter = 2;				// if so, move ghost down
				} else {						// if pacman is not to the left hand side and also not below, 
					counter = 1;				// move to the right
				}
			}
		}
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'S' &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') &&
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if(randomValue == 1) {
				randomIndexArray = Random.Range (0,2);
				arrayOfPellets[0] = 1;
				arrayOfPellets[1] = 3;
				counter = arrayOfPellets[randomIndexArray];
				
				arrayOfPellets = new int[4];
				
			} else {
				
				if(PacmanX < GhostX) { 			// is pacman to the left of the ghost
					counter = 3;				// if so, move left
				} else {						// if not,
					counter = 1;				// then move right
				}
			}
		}
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			
			if(randomValue == 1) {
				randomIndexArray = Random.Range (0,3);
				arrayOfPellets[0] = 0;
				arrayOfPellets[1] = 2;
				arrayOfPellets[2] = 3;
				counter = arrayOfPellets[randomIndexArray];
				
				arrayOfPellets = new int[4];
				
			} else {
				
				if(PacmanX < GhostX) {			// is pacman to the left 
					counter = 3;				// if so, move ghost left	
				} else if (PacmanY > GhostY) {  // if not, is pacman above ghost
					counter = 0;				// if so, move ghost up
				} else {						// if not, 
					counter = 2;				// then move ghost down
				}
			}
		}
		
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' &&  
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {
			if(randomValue == 1) {
				randomIndexArray = Random.Range (0,2);
				arrayOfPellets[0] = 0;
				arrayOfPellets[1] = 1;
				counter = arrayOfPellets[randomIndexArray];
				
				arrayOfPellets = new int[4];
				
			} else {
				if(PacmanX > GhostX) {			// is pacman to the right of the ghost
					counter = 1;				// if so, move ghost right
				} else {						// if not, 
					counter = 0;				// then move up
				}
			}
		}
		
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {
			Debug.Log ("PPPW");
			Debug.Log ("Random value = " + randomValue);
			if (randomValue == 1) {
				
				
				randomIndexArray = Random.Range (0, 3);
				Debug.Log ("Entered");
				arrayOfPellets [0] = 0;
				arrayOfPellets [1] = 1;
				arrayOfPellets [2] = 2;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else { 
				
				if (PacmanX > GhostX) {			// is pacman to the right of the ghost
					counter = 1;				// if so, move right
				} else if (PacmanY > GhostY) {  // if not, is pacman above ghost, 
					counter = 0;				// if so, move up
				} else {						// if not,
					counter = 2;				// move down
				}
			}
		}
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 2);
				arrayOfPellets [0] = 0;
				arrayOfPellets [1] = 3;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				
				if (PacmanX < GhostX) {			// is pacman to the left of the ghost
					counter = 3;				// if so, move ghost right
				} else {						// if not, 
					counter = 0;				// move ghost up
				}
			}
		}
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 3);
				arrayOfPellets [0] = 1;
				arrayOfPellets [1] = 2;
				arrayOfPellets [2] = 3;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				if (PacmanY < GhostY) { 			// is pacman below ghost
					counter = 2; 				// if so, move ghost down
				} else if (PacmanX > GhostX) {  // if not, is pacman to the right of the ghost
					counter = 1; 				// if so then move right
				} else {						// if not, 
					counter = 3;				// move left
				}
			}
		}
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 3);
				arrayOfPellets [0] = 0;
				arrayOfPellets [1] = 1;
				arrayOfPellets [2] = 3;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				
				if (PacmanY > GhostY) {			// is pacman above the ghost
					counter = 0;				// if so, move ghost up
				} else if (PacmanX > GhostX) {	// if not, is pacman right side of ghost
					counter = 1;				// if so, move ghost right
				} else {						// if not, 
					counter = 3;				// move ghost left
				}
			}
		}
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'w') {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 2);
				arrayOfPellets [0] = 1;
				arrayOfPellets [1] = 2;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				if (PacmanX > GhostX) { 			// is pacman to the right of the ghost
					counter = 1;				// if so, move ghost
				} else {						// if not.
					counter = 2;				// move down
				}
			}
		}
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'w' && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 2);
				arrayOfPellets [0] = 2;
				arrayOfPellets [1] = 3;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				
				if (PacmanX < GhostX) {  			// is pacman to the left of the ghost
					counter = 3;				// if so, move ghost left
				} else {						// if not, 
					counter = 2;				// move ghost down
				}
			}
		}
		
		if ((DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'o') &&
		    (DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'p' || DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'o') && 
		    (DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'p' || DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'o')) {
			if (randomValue == 1) {
				randomIndexArray = Random.Range (0, 4);
				arrayOfPellets [0] = 0;
				arrayOfPellets [1] = 1;
				arrayOfPellets [2] = 2;
				arrayOfPellets [3] = 3;
				counter = arrayOfPellets [randomIndexArray];
				
				arrayOfPellets = new int[4];
			} else {
				
				if (PacmanX > GhostX) { 			// is pacman to the right of the ghost 
					counter = 1;				// if so, move ghost right
				} else if (PacmanX < GhostX) {	// if not, is pacman to the left of the ghost.
					counter = 3;				// if so, move ghost left
				} else if (PacmanY > GhostY) { 	// if not, is pacman above the ghost
					counter = 0;				// if so, move ghost up
				} else {						// if not, 
					counter = 2;				// move ghost down
				}
			}
		}
		
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'S' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'S' &&
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'S' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'S') {
			
			counter = 2; 					// move ghost down 
		}
		
		
		if (DH.StoredRefCoordinates [GhostX, GhostY + 1] == 'w' &&
		    DH.StoredRefCoordinates [GhostX + 1, GhostY] == 'S' &&
		    DH.StoredRefCoordinates [GhostX, GhostY - 1] == 'S' && 
		    DH.StoredRefCoordinates [GhostX - 1, GhostY] == 'S') {
			
			counter = 2; 					// move ghost down 
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
	
	void UpdatePacManPosition() {// find pacmans position values in dataholder and update in ghost script called every frame and decision
		PacmanX = DH.PacmanX;
		PacmanY = DH.PacmanY;
	}
	
	void Update () {
		if (trigger == true) {
		
			origaRotation = transform.rotation;
			// find correct ghost values and setup behavior 
			if(gameObject.name == "G1" || gameObject.name == "G1(Clone)" ){
				GhostX = DH.ClydeX;
				GhostY = DH.ClydeY;
				random1 = 0;
				random2 = 2;
			}
			
			if(gameObject.name == "G2" || gameObject.name == "G2(Clone)" ){
				GhostX = DH.PinkyX;
				GhostY = DH.PinkyY;

				random1 = 0;
				random2 = 3;
			}
			
			if(gameObject.name == "G3" || gameObject.name == "G3(Clone)" ){
				GhostX = DH.InkyX;
				GhostY = DH.InkyY;

				random1 = 1;
				random2 = 3;
			}
			
			if(gameObject.name == "G4" || gameObject.name == "G4(Clone)" ){
				GhostX = DH.BlinkyX;
				GhostY = DH.BlinkyY;

				random1 = 0;
				random2 = 2;
			}
			// get ghost!
			SpawnPosX = GhostX;
			SpawnPosY = GhostY;
			
			blue = Resources.Load("Dblue") as Material; // load blue material
			defaultTex = renderer.material; // store default texture
			
			trigger = false;
			StartCoroutine (PressUpKey ());
		}
		
		if (DH.powerup == true) {
			renderer.material = blue;
		}
		
		if (DH.powerup == false) {
			renderer.material.color = new Color(1f,1f,1f,1f); // set ghost to blue
			renderer.material = defaultTex; // restore texture;
		}
		
		if (HasBeenEaten == true) {
			
			renderer.material = defaultTex; // restore texture
			GhostX = SpawnPosX; // return to sarting position
			GhostY = SpawnPosY;
			transform.position = DH.StoredCoordinates[GhostX,GhostY];
			moving = true;
			counter = 2;// reset counter
			HasBeenEaten = false;
		}
		
		
		if (DH.globalRespawn == true) {
			StopCoroutine (StartMoving ());// stop moving 
			
			counter = 2; // reset counter
			GhostX = SpawnPosX; // reset positions 
			GhostY = SpawnPosY;
			transform.position = DH.StoredCoordinates[GhostX,GhostY];//

		}

	}
	
}