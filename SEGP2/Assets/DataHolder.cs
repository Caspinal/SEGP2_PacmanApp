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

	//store the size of the Grid
	public int xLength;
	public int yLength;

	public int PelletCount; // decrement this when pellets are eaten end game when equal to zero


	// store the all coordinates
	public Vector3[,] StoredCoordinates = new Vector3[0,0];
	public Vector3[,] StoredCoordinates90;
	public Vector3[,] StoredCoordinates180;
	public Vector3[,] StoredCoordinates270;

	public char[,] StoredRefCoordinates = new char[0,0];
	public char[,] StoredRefCoordinates90;
	public char[,] StoredRefCoordinates180;
	public char[,] StoredRefCoordinates270;


	// this function will rotate a MDA by 90 degrees
	Vector3[,] rotateArray(Vector3[,] input, int xlength, int ylength){

		Vector3[,] target = new Vector3[ylength,xlength];

		for (int RY = 0; RY < ylength; RY++) {
			for (int RX = 0; RX < xlength; RX++) {

				target[RX,RY] = input[RY,ylength - RX -1];
			}
			}// end of RY
		
			return target;
	} // end of rotatearray

	void Start () {
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

			// access the grid coordinates and store for publix avalibilty
			StoredCoordinates = new Vector3[xLength,yLength];
			StoredRefCoordinates = new char[xLength,yLength];

			for(int i = 0; i < yLength; i++){
				for(int j = 0; j < xLength; j++){

					StoredCoordinates[j,i] = GameLogic.Coordinates[j,i];
					StoredRefCoordinates[j,i] = GameLogic.CoordinatesReference[j,i];
				}
			}
			// initialise relitive arrays
			StoredCoordinates90 = rotateArray(StoredCoordinates,xLength,yLength);
			StoredCoordinates180 = rotateArray(StoredCoordinates90,yLength,xLength);
			StoredCoordinates270 = rotateArray(StoredCoordinates180,xLength,yLength);

			//hold the position of PacMan
			PacmanY = GameLogic.PacmanY;
			PacmanX = GameLogic.PacmanX;

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
			//StoredCoordinates180 = rotateArray(StoredCoordinates,xLength,yLength,180);

			Debug.Log(StoredCoordinates[0,0] + " Is now at 90 " + StoredCoordinates90[0,0] +" 180 "+ StoredCoordinates180[0,0] +" 270 "+ StoredCoordinates270[0,0]);

			trigger = false;// set trigger to false to stop, the above should only exexte once
		}

//		if Score has changed print Touch standard output
//		if (Score > PrevScore) {
//			Debug.Log("Current Score is: " + Score);
//			PrevScore = Score;
//		}
		// If all 3 lives lost, load end of game scene
		if(lives  <= 0){
			Application.LoadLevel("gameover");

		}

		if(powerup == true){
			Debug.Log("powered up");
			Debug.Log("power pellet");
			if(powerPelletTimer > 1){
				powerup = true;
				powerPelletTimer -= Time.deltaTime;
			}else{
				powerup = false;
				Debug.Log("powered down");
				powerPelletTimer = 15f;
			}

		}

		if (globalRespawn == true) {
			fadeController2.BeginFade(1);
			if(respawnTimer > 1){
				globalRespawn = true;
				respawnTimer -= Time.deltaTime;

				
			}else{
				globalRespawn = false;
				Debug.Log("Go!");
			
				fadeController2.BeginFade(-1);
				respawnTimer = 0.5f;
			}


		}

		if(PelletCount <= 0){

			Debug.Log("Maze Clear");
			Application.LoadLevel("winning");
		}

	}

	// Update score and lives GUI display
	void OnGUI() {
		stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20),("Score: " + Score +"Lives: " + lives), 25);
	}
}
