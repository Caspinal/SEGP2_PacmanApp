using UnityEngine;
using System.Collections;

public class DataHolder : MonoBehaviour {
	bool trigger = true; // set this Bool to false in update function to extecute post start initialisation 
	public bool powerup = false;
	public bool globalRespawn = false;
	public int Score; // publily accesable to all classes should only be aceessd in the DataHolder
	//int PrevScore; // holds the last recorded score
	float powerPelletTimer = 15f;
	float respawnTimer = 2f;
	public int PacmanX; // PacMans initial positon
	public int PacmanY;

	public int lives = 3; // publily accesable to all classes should only be aceessd in the DataHolder when all lost end game
	public string stringToEdit; // used to update GUI score and live display

	// Store the positions of all Ghosts
	public int InkyX;
	public int InkyY;
	public Fading fadeController2;

	public int ClydeX;
	public int ClydeY;

	public int PinkyX;
	public int PinkyY;

	public int BlinkyX;
	public int BlinkyY;

	// store the position of special items
	public int specialIX;
	public int specialIY;

	
	public float ItemRespawnTimer = 5f;
	public bool SpecialExists = false;
	// set theese gameobjects in editor
	public GameObject[] items = new GameObject[3];




	//store the size of the Grid
	public int xLength;
	public int yLength;

	public int PelletCount; // decrement this when pellets are eaten end game when equal to zero


	// store the all coordinates
	public Vector3[,] StoredCoordinates = new Vector3[0,0];
	public char[,] StoredRefCoordinates = new char[0,0];




	void Start () {
		lives = 3; // temp fix form memory retention bug
	}
	
	// Update is called once per frame
	void Update () {
	
		if (trigger == true) {

			// access the values initialised by the GameLogic class
			GameObject MC = GameObject.Find("Main Camera");
			GameLogic GameLogic = MC.GetComponent<GameLogic>();
			fadeController2 = MC.GetComponent<Fading>();
			//hold the size of the Grid
			xLength = GameLogic.xlength;
			yLength = GameLogic.ylength;
			//hold the pellet count
			PelletCount = GameLogic.pelletCount;
			Debug.Log("this maze contains " + PelletCount + " pellets");

			// access the grid coordinates and store for public avalibilty
			StoredCoordinates = new Vector3[xLength,yLength];
			StoredRefCoordinates = new char[xLength,yLength];

			for(int i = 0; i < yLength; i++){
				for(int j = 0; j < xLength; j++){

					StoredCoordinates[j,i] = GameLogic.Coordinates[j,i];
					StoredRefCoordinates[j,i] = GameLogic.CoordinatesReference[j,i];
				}
			}

			//hold the position of PacMan
			PacmanY = GameLogic.PacmanY;
			PacmanX = GameLogic.PacmanX;
			specialIX = GameLogic.specialItemX;
			specialIY = GameLogic.specialItemY;

			// if the ghost is loaded then hold its position
			if(GameLogic.inky == true){
				InkyX = GameLogic.inkyX;
				InkyY = GameLogic.inkyY;

			}

			if(GameLogic.blinky == true){
				BlinkyX = GameLogic.blinkyX;
				BlinkyY = GameLogic.blinkyY;
				
			}

			if(GameLogic.clyde == true){
				ClydeX = GameLogic.clydeX;
				ClydeY = GameLogic.clydeY;
				
			}

			if(GameLogic.pinky == true){
				PinkyX = GameLogic.pinkyX;
				PinkyY = GameLogic.pinkyY;
				
			}

			trigger = false;// set trigger to false to stop, the above should only execute once
		}

		// if all lives deducted load gameover scene
		if(lives  <= 0){
			PlayerPrefs.SetInt("Player Score", Score);
			Application.LoadLevel("gameover");

		}


		if(powerup == true){
			Debug.Log("powered up");
			Debug.Log("power pellet");
			if(powerPelletTimer > 1){
				powerup = true;
				powerPelletTimer -= Time.deltaTime; // deducted the timer
			}else{
				powerup = false; // set powerup to false to stop powerpellet effect
				Debug.Log("powered down");
				powerPelletTimer = 15f; // set timer to 15.0 seconds
			}

		}

		if (globalRespawn == true) {
			fadeController2.BeginFade(1); // fade out scene
			if(respawnTimer > 1){
				globalRespawn = true; // start global respawn
				respawnTimer -= Time.deltaTime; // deduct timer 

				
			}else{
				globalRespawn = false;
				Debug.Log("Go!");
			
				fadeController2.BeginFade(-1); //fade in scene
				respawnTimer = 0.5f;// reset timer
			}


		}

		if(PelletCount <= 0){
			PlayerPrefs.SetInt("Player Score", Score); // store in player prefrences to avoid destruction on load
			Debug.Log("Maze Clear");
			Application.LoadLevel("winning");// load winning scene
		}

		if (SpecialExists == false) { //


			if (ItemRespawnTimer < 1){

				GameObject special = Instantiate(items[Random.Range(0,(items.Length))]) as GameObject;
				
				Debug.Log("I shall spawn at " +  specialIX + " " + specialIY);

				special.transform.position = new Vector3(specialIX, 0 ,specialIY);
				ItemRespawnTimer = 5f;
				SpecialExists = true;
			}else{
				ItemRespawnTimer -= Time.deltaTime;

			}

		}


	}

	// Update score GUI display
	void OnGUI() {
		stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20),("Score: " + Score), 25);
	}
}
