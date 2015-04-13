#pragma strict
import System.IO;

var Maze = new Array();
var MazeValidated = true;


public var MazeY = new Array();


//public function getArray(){
//
//print("one array coming up!");
//return MazeY; 
//
//} 



function Start () {

//var filepath = "/Users/connoraspinall/Documents/Maze.csv";// set up EXACT path here
//var filepath = "/Users/connoraspinall/Google Drive/SEGP2 - A6/Developer Resources/FILE.txt";


var sr = new File.OpenText("FILE.txt");// open the file
print(sr.ReadLine() + "\n"); // read  and print the first line for debug


var i : int = 0;
var x = "MAZE";
while(true){
	
if (x == "" || x == null){// if EOF then break
	
	break;
}else{
	x = sr.ReadLine();
	// reassign next line
	Maze[i] = x; // load into maze array
	i++;
	}
 }
 
 sr.Close();// close file

print("checking maze....");
// check each element in the array
for(var j = 0; j < Maze.length-1; j++){

if (Maze[j] != null){
	print(Maze[j]);
}else{
	print("Maze Error");
	MazeValidated = false;
}
   }
   
// if maze is valid start building
   
   if(MazeValidated == true){
   		
   		var xpos = 0; // save the X pointer posistion (rows)
   		//var xpos2 = 0;
   		var ypos = 0; // save the Y pointer posistion (collumns)
   		var xhold = 0; // set a temp value to hold the string length 
   		var hold : String = "Blank"; // set a temp value to hold the test string
   		print("Entering the build state!");// debug information
   		
   		for ( ypos = 0; ypos < Maze.length-1; ypos++){// iterate through the collumns 
   			//var MazeX = new VectorX();// create a vector array to s
   			xpos = 0;// reset xpos 
   			
   			if(Maze[ypos] != null){// check if string is not emtpy as this will cause a build error 
   			hold = Maze[ypos]; //if string is valid assign to hold
   			}else{print("NULL ARRAY VALUE >< FORCE BREAK");break;}// else break out of build stage and Display error.
   		
   			var SL : int = hold.Length; // get the interger length of the x values
   			//xpos2 = SL;
   			//print(hold);
   			for(xhold = 0; xhold < SL; xhold++){ // loop to build rows 
   				
   				//if (xhold % 2 == 0){
   					var nextchar : char = (hold[xhold]); // read a char from the char array and hold in nextchar
   					
   					xpos++;// increment the row position 
   					
   					//xpos2 = xpos2/2;
   					//xpos -= xpos2;
   					//print(xpos2);
   					
   					switch(nextchar){
   					
   					case 'p': print("pellet and path node"); // if the char is a p then build a pellet
   					
   					var p : GameObject  = Instantiate(Resources.Load("Pac-Dot", GameObject)); // load the model from the resources directory 
 					p.transform.position = Vector3((xpos),1, ypos); // place in the world accordingly 
					
					//MazeX.setVector(xpos,1,ypos);
					//MazeX.IncrementPointer();
					
					
					
					
   					break;
   					case 'w': print("wall");
   					var w : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Cube); // create a cube primative 
   					w.renderer.material = Resources.Load("Blue"); // load the material from the resources directory 
					w.transform.position = Vector3((xpos), 1, ypos); // place in the world accordingly 
					w.name = "Wall"; // name arcodingly 
					
					
					
					
   					break;
   					case 'o': print("power pellet and path node");
   					
   					var o : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Sphere); // create a sphere primative
   					o.renderer.material = Resources.Load("orange"); // load the material from the resources directory 
					o.transform.position = Vector3((xpos), 1, ypos); // place in the world accordingly
					o.transform.localScale = Vector3(0.3,0.3,0.3); // name arcodingly 
					o.name = "PowerPellet";// name arcodingly 
   					break;
   					
   					//MazeX.setVector(xpos,1,ypos);
					//MazeX.IncrementPointer();
					
   					default: print("unrecognized char"); // if unrecognized then move on
   					
   					
   					
   				
   					
   					
   					
   					//}
   				
   					
   				}
   			
   			}
   		
   		//MazeX.printXvector();			
   		//MazeY[ypos] = MazeX;
   		//MazeX.IncrementRowY();
   		//print("Current row" + MazeX.getRowY());
   		
   		
   		
   		
   		
   		
   		
   		
   	
   		var fXpos = 1;
   		for(xhold = 0; xhold < ((SL)); xhold++){
   		// loop to create the floor in the maze
   		var floor : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Cube);
   		floor.renderer.material = Resources.Load("Dblue");
		floor.transform.position = Vector3((fXpos), 0, ypos); // this Ypos is zpos??? fix this! 		
   		floor.name = "Floor";
   		fXpos++;
   			} 
   		}
   		
   					
 }
  
   
   print("Building complete...");
}

function Update () {




}