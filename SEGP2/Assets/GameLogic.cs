using UnityEngine;
using System.Collections;
using System.IO;
public class GameLogic : MonoBehaviour {

	public string test = "Hello";
	string[] InitialLoadedMaze = new string[20];
	string[] HoldLoadedMaze = new string[20];
	string IntitailHold = "";
	public Vector3[,] Coordinates = new Vector3[0,0];
	public char[,] CoordinatesReference  = new char[0,0];
	public int xlength;
	public int ylength;
	public int PacmanX;
	public int PacmanY;
	public int pelletCount = 0;
	int prevrc = 0;
	int rc = 0;
	int colourOption = 4;
	public bool randomColour = false;
	//public Vector3[] colourV = {new Vector3(255f,0f,0f), new Vector3(26f,255f,0f), new Vector3(4f,222f,255f), new Vector3(177f,34f,255f) , new Vector3(255f,130f,32f), new Vector3(114f,255f,199f)};
	//public Color[] colour = new Color[] {(new Color(255,0,0)),(new Color(26,255,0)),(new Color(4,222,255)),(new Color(177,34,255)),(new Color(255,130,32)),(new Color(26,255,0))};

	//
	public Color[] colour8 = new Color[] {new Color(0.101196078f,1.0f,0.0f,1.0f), new Color(0.69411765f,0.13333333f,1.0f,1.0f), new Color(1.0f,0f,0f,1f), new Color(0.0156862745098f,0.87058823529412f,1f,1f), new Color(1f,0.4862745098f,0f,1f), new Color(0.56470588235294f,1f,0.78039215686275f,1f),new Color(1f,0.7960784314f,0.007843137255f),new Color(0,0.1960784314f,1f)};
	//public Color[] colourRGB = new Color[]{new Color(1f,0f,0f,1f),new Color(0f,1f,0f,1f),new Color(0f,0f,1f,1f)};

	public bool inky = false;
	public int inkyX; 
	public int inkyY; 
	//temp value for testing
	public int makedoor =  3;

	public bool blinky = false;

	public int blinkyX;
	public int blinkyY;

	public bool pinky = false;
	public int pinkyX;
	public int pinkyY;

	public bool clyde = false;
	public int clydeX;
	public int clydeY;
	string currentOption = "option";
		
	// Use this for initialization
	//bool trigger = true;

	void LoadConfig(){

		if (randomColour = false) {
			StreamReader ConfigInput = new StreamReader ("config");
			while ((currentOption = ConfigInput.ReadLine())!= null) {
			if (currentOption == "Colour") {
			currentOption = ConfigInput.ReadLine ();
			colourOption = int.Parse (currentOption);
				}
			}
		ConfigInput.Close ();
		}else if(true){
			colourOption = Random.Range(0,8);

		}
	}


	void Start () {
		//Debug.Log("colours is " + colour8.Length);
		LoadConfig();
		StreamReader FileInput = new StreamReader("filename.txt");
		int IntitailHoldPointer = 0;

		while((IntitailHold = FileInput.ReadLine())!= null){

			if(IntitailHoldPointer > (InitialLoadedMaze.Length -1)){

				// dynanically extend the array as needed.
				HoldLoadedMaze = new string[InitialLoadedMaze.Length];
				InitialLoadedMaze.CopyTo(HoldLoadedMaze,0); // hold the maze
				InitialLoadedMaze = new string[InitialLoadedMaze.Length + 1];
				HoldLoadedMaze.CopyTo(InitialLoadedMaze,0);// put it back
			
			}

			InitialLoadedMaze[IntitailHoldPointer] = IntitailHold;
			IntitailHoldPointer++;
		}
		

		FileInput.Close();

		string SecondryHold = InitialLoadedMaze[0];
		// get x an y for maze
		xlength = SecondryHold.Length;
		ylength = InitialLoadedMaze.Length;


		Coordinates = new Vector3[xlength,ylength];
		CoordinatesReference = new char[xlength,ylength];

		for(int y =0; y < ylength; y++){

			SecondryHold = InitialLoadedMaze[y];

			for(int x = 0; x < xlength; x++){

				char charHold = SecondryHold[x];

				switch(charHold){

				case 'p':
						
					Coordinates[x,y] = new Vector3(x,0,y);
					CoordinatesReference[x,y] = charHold;
					pelletCount++;

					break;

				case 'w':

					Coordinates[x,y] = new Vector3(x,0,y);
					CoordinatesReference[x,y] = charHold;

					break;

				case 'o':

					Coordinates[x,y] = new Vector3(x,0,y);
					CoordinatesReference[x,y] = charHold;
					pelletCount++;

					break;

				case 'i':
					Coordinates[x,y] = new Vector3(x,0.184f,y);
					CoordinatesReference[x,y] = charHold;

					blinky = true;
					blinkyX = x; 
					blinkyY = y;


					break;

				case 'n':
					Coordinates[x,y] = new Vector3(x,0.184f,y);
					CoordinatesReference[x,y] = charHold;

					pinky = true;
					pinkyX = x; 
					pinkyY = y;
					break;

				case 'k':
					Coordinates[x,y] = new Vector3(x,0.184f,y);
					CoordinatesReference[x,y] = charHold;



					inky = true;
					inkyX = x; 
					inkyY = y;
					break;
				
				case 'c':
					Coordinates[x,y] = new Vector3(x,0.184f,y);
					CoordinatesReference[x,y] = charHold;

					clyde = true;
					clydeX = x; 
					clydeY = y;

					break;

				case 'm':
					Coordinates[x,y] = new Vector3(x,0,y);
					CoordinatesReference[x,y] = charHold;
					PacmanX = x;
					PacmanY = y;

					break;
				case 'S':
					Coordinates[x,y] = new Vector3(x,0,y);
					CoordinatesReference[x,y] = charHold;
					// temp fix to add door to maze

//					if(makedoor == 2){
//
//					CoordinatesReference[x - 2,y -2] = 'S';
//					CoordinatesReference[x - 3,y -2] = 'S';
//						//makedoor = false;
//					}
//					makedoor--;
					break;

				default:
					break;
					
				}
			}
		}
		// step a temp fix to add a door

		CoordinatesReference[inkyX +1,inkyY -3] = 'S';
		CoordinatesReference[inkyX,inkyY -3] = 'S';
		CoordinatesReference[inkyX -1,inkyY -3]= 'S';

		for(int yp =0; yp < ylength; yp++){
			for(int xp =0; xp < xlength; xp++){
		
				switch(CoordinatesReference[xp,yp]){
					
				case 'p':
					
					GameObject p  = Instantiate(Resources.Load("Pac-Dot")) as GameObject;
					p.transform.position = Coordinates[xp,yp];

					GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor.renderer.material = Resources.Load("Black") as Material;
					floor.transform.position = new Vector3(xp, -1, yp);

					break;
					
				case 'w':
					bool colourDifference = false;
					GameObject W  = Instantiate(Resources.Load("Wall")) as GameObject;


					
					switch(colourOption){
					
					case 0://green
						rc = 0;
						break;
					case 1://purple
						rc = 1;
						break;
					case 2://red
						rc = 2;
						break;
					case 3:// light blue
						rc = 3;
						break;
					case 4:// orange
						rc = 4;
						break;
					case 5:// Aqua
						rc = 5;
						break;
					case 6: //yellow
						rc = 6;
						break;
					case 7:// dark blue
						rc = 7;
						break;
					default:// muliple colours
						while(colourDifference == false){
						rc = Random.Range(0,colour8.Length);
						//Debug.Log("Colour index " + rc +"prev " + prevrc);
						if(rc != prevrc){
							colourDifference = true;
						}
					}
						prevrc = rc;
						break;
					}

					//Color makeColour = colour[1];
					Debug.Log("colour "+rc+" "+ colour8[rc]);

					W.renderer.material.color = (Color32)colour8[rc];
					W.transform.position = Coordinates[xp,yp];



					GameObject floor2 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor2.renderer.material = Resources.Load("Black") as Material;
					floor2.transform.position = new Vector3(xp, -1, yp);
					
					break;
					
				case 'o':
					
					GameObject o  = Instantiate(Resources.Load("Power-Pellet")) as GameObject;
					o.transform.position = Coordinates[xp,yp];

					GameObject floor3 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor3.renderer.material = Resources.Load("Black") as Material;
					floor3.transform.position = new Vector3(xp, -1, yp);
					
					break;


				case 'n': // Inky
					
					GameObject n  = Instantiate(Resources.Load("G3")) as GameObject;
					n.transform.position = Coordinates[xp,yp];
					n.transform.position += new Vector3(0.0f,0.3f,0.0f);
					n.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
					
					GameObject floor4 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor4.renderer.material = Resources.Load("Black") as Material;
					floor4.transform.position = new Vector3(xp, -1, yp);

					break;

				case 'i': // Blinky
					
					GameObject i  = Instantiate(Resources.Load("G4")) as GameObject;
					i.transform.position = Coordinates[xp,yp];
					i.transform.position += new Vector3(0.0f,0.3f,0.0f);
					i.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
					GameObject floor5 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor5.renderer.material = Resources.Load("Black") as Material;
					floor5.transform.position = new Vector3(xp, -1, yp);
					
					break;


				case 'k': // Pinky
					
					GameObject k  = Instantiate(Resources.Load("G2")) as GameObject;
					k.transform.position = Coordinates[xp,yp];
					k.transform.position += new Vector3(0.0f,0.3f,0.0f);
					k.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
					
					GameObject floor6 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor6.renderer.material = Resources.Load("Black") as Material;
					floor6.transform.position = new Vector3(xp, -1, yp);
					
					break;


				case 'c': // Clyde
					
					GameObject c  = Instantiate(Resources.Load("G1")) as GameObject;
					c.transform.position = Coordinates[xp,yp];
					c.transform.position += new Vector3(0.0f,0.3f,0.0f);
					c.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
					
					GameObject floor7 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor7.renderer.material = Resources.Load("Black") as Material;
					floor7.transform.position = new Vector3(xp, -1, yp);
					
					break;

				case 'm': // pacman

					GameObject m  = Instantiate(Resources.Load("PacMan 1")) as GameObject;
					m.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
					m.transform.position =Coordinates[xp,yp];

					GameObject floor8 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor8.renderer.material = Resources.Load("Black") as Material;
					floor8.transform.position = new Vector3(xp, -1, yp);// make floor into an instatiated object!

					
					break;
					


				default:
					GameObject floor9 = GameObject.CreatePrimitive(PrimitiveType.Cube); 
					floor9.renderer.material = Resources.Load("Black") as Material;
					floor9.transform.position = new Vector3(xp, -1, yp);// make floor into an instatiated object!
					break;

				}
			}
		}
	}

	

	// Update is called once per frame
	void Update () {
		
		
	}
	
	
}