#pragma strict
import System.IO;

var Maze = new Array();
var MazeValidated = true;
function Start () {

var filepath = "/Users/connoraspinall/Documents/Maze.csv";// set up EXACT path here

//var link : WWW = new WWW("file://~/Users/connoraspinall/Documents/Maze.csv");
//ield link;
//print(link.url);

var sr = new File.OpenText(filepath);// open the file
print(sr.ReadLine() + "\n"); // read  and print the first line for debug

var x = sr.ReadLine();// assign to x 

var i : int = 0;

while(true){
	
if (x == "" || x == null){// if EOF then break
	
	break;
}else{
	x = sr.ReadLine(); // reassign next line
	//print("RES" + x + "\n");// print for debug
	i++;
	//print("Array attempt: "+i + "\n"); // print for debug
	Maze[i] = x;
	}
 }
 
 sr.Close();// close file
print("checking maze....");
for(var j = 1; j < Maze.length-1; j++){

if (Maze[j] != null){
	print(Maze[j]);
}else{
	print("Maze Error");
	MazeValidated = false;
}
   }
   
   
   if(MazeValidated == true){
   		
   		var xpos = 0;
   		var xpos2 = 0;
   		var ypos = 0;
   		var xhold = 0;
   		var hold : String = "Blank";
   		print("Entering the build state!");
   		
   		for ( ypos = 0; ypos < Maze.length -1; ypos++){
   			
   			xpos = 0;
   			
   			if(Maze[ypos + 1] != null){
   			hold = Maze[ypos + 1];
   			}else{print("NULL ARRAY VALUE >< FORCE BREAK");break;}
   			
   			var SL : int = hold.Length;
   			
   			print(hold);
   			for(xhold = 0; xhold < SL; xhold++){
   				
   				if (xhold % 2 == 0){
   					var nextchar : char = (hold[xhold]);
   					
   					xpos++; 
   					xpos2 = -SL;
   					xpos2 = xpos2/2;
   					xpos -= xpos2;
   					print(xpos2);
   					
   					switch(nextchar){
   					
   					case 'p': print("pellet and path node");
   					var p : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					p.transform.position = Vector3((((xpos) - (SL)/2)),1, ypos);
   					break;
   					case 'w': print("wall");
   					var w : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Cube);
					w.transform.position = Vector3(((xpos) - (SL)/2), 1, ypos);
   					break;
   					case 'O': print("power pellet and path node");
   					var o : GameObject  = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					o.transform.position = Vector3(((xpos) - (SL)/2), 1, ypos);
   					break;
   					default: print("unrecognized char");
   					
   					
   					
   					}
   				
   				}
   			
   			}
   		
   		
   		}
   		
   		
   }
   print("Building complete...");
}

function Update () {




}