#pragma strict
import System.IO;

var Maze = new Array();
var MazeValidated = true;


var MazeY = new Array();






function Start () {

//var filepath = "/Users/connoraspinall/Documents/Maze.csv";// set up EXACT path here
var filepath = "/Users/connoraspinall/Google Drive/SEGP2 - A6/Developer Resources/FILE.txt";


var sr = new File.OpenText(filepath);// open the file
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
   		
   		var xpos = 0;
   		var xpos2 = 0;
   		var ypos = 0;
   		var xhold = 0;
   		var hold : String = "Blank";
   		print("Entering the build state!");
   		
   		for ( ypos = 0; ypos < Maze.length-1; ypos++){
   			var MazeX = new VectorX();
   			xpos = 0;
   			
   			if(Maze[ypos] != null){
   			hold = Maze[ypos];
   			}else{print("NULL ARRAY VALUE >< FORCE BREAK");break;}
   		
   			var SL : int = hold.Length;
   			xpos2 = SL;
   			print(hold);
   			for(xhold = 0; xhold < SL; xhold++){
   				
   				//if (xhold % 2 == 0){
   					var nextchar : char = (hold[xhold]);
   					
   					xpos++; 
   					
   					//xpos2 = xpos2/2;
   					//xpos -= xpos2;
   					print(xpos2);
   					
   					switch(nextchar){
   					
   					case 'p': print("pellet and path node");
   					
   					var p : GameObject  = Instantiate(Resources.Load("Pac-Dot", GameObject));
 					p.transform.position = Vector3((xpos),1, ypos);
					
					MazeX.setVector(xpos,1,ypos);
					MazeX.IncrementPointer();
					
					
					
					
   					break;
   					case 'w': print("wall");
   					var w : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Cube);
   					w.renderer.material = Resources.Load("Blue");
					w.transform.position = Vector3((xpos), 1, ypos);
					w.name = "Wall";
					
					
					
					
   					break;
   					case 'o': print("power pellet and path node");
   					
   					var o : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Sphere);
   					o.renderer.material = Resources.Load("orange");
					o.transform.position = Vector3((xpos), 1, ypos);
					o.transform.localScale = Vector3(0.3,0.3,0.3);
					o.name = "PowerPellet";
   					break;
   					
   					MazeX.setVector(xpos,1,ypos);
					MazeX.IncrementPointer();
					
   					default: print("unrecognized char");
   					
   					
   					
   				
   					
   					
   					
   					//}
   				
   					
   				}
   			
   			}
   		
   		//MazeX.printXvector();			
   		MazeY[ypos] = MazeX;
   		MazeX.IncrementRowY();
   		print("Current row" + MazeX.getRowY());
   		
   		var fXpos = 1;
   		for(xhold = 0; xhold < ((SL)); xhold++){
   		
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