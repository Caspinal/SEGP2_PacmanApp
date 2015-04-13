#pragma strict
import System.IO;

var Maze = new Array();// an array to store the lines of text to be parsed by the build state 
var MazeValidated = true;// a flag to state if the file is valid
var MazeY : VectorX[]; // an array to store all vectors of placed items by the builder
var PacmanPos = new Array(2);
var test : int[,];

public var XPosition : int[];
public var YPosition : int[]; // not needed
public var ZPosition : int[];


function Start () {

//print("This is a gift!" + xv);



var sr = new File.OpenText("FILE.txt");// open the file
print(sr.ReadLine() + "\n"); // read  and print the first line for debug


var i : int = 0;
var x = "MAZE"; // set up an intial string to stor readlines 
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
   	
   		var ss:String = Maze[1];
   		var linec = ss.length;
   		//test = new Vector3[Maze.length-1,linec];
   		var xpos = 0;
   		var xpos2 = 0;
   		var ypos = 0;
   		var xhold = 0;
   		var hold : String = "Blank";
		//var VC : Vector3 = Vector3(1,1,1);
		//var VXC;
   		
   		var size = Maze.length * linec;
   		XPosition = new int[size];
   		ZPosition = new int[size];
   		for ( ypos = 0; ypos < Maze.length-1; ypos++){
   			print("Iterating");
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
   					//print(xpos2);
   					
   					switch(nextchar){
   					case 'm':
   					print("i found pacman");

						PacmanPos[0] = xpos;
						PacmanPos[1] = ypos;
						
						
						XPosition[xpos] = xpos;
						ZPosition[xpos] = ypos;
						
						
   					break; 
   					
   					case 'p': 
   					print("i found pellet");
//						MazeX.setVector(xpos,1,ypos);
//						MazeX.IncrementPointer();
//						VC = new Vector3(xpos,1,ypos);
//						print(VC);
//						test[ypos,xpos].Set(xpos,1,ypos);
//						print(test[ypos,xpos] + "TEST")
						XPosition[xpos] = xpos;
						ZPosition[xpos] = ypos;
						
						
   					break;
   					
   					case 'o': 
   					print("i found pelltersds"); 
//   						MazeX.setVector(xpos,1,ypos);
//						MazeX.IncrementPointer();
					
						 
						XPosition[xpos] = xpos;
						ZPosition[xpos] = ypos;
						 
					break;
					
   					default:break;			
   		
   	
   			}   					
 }
  
  		//MazeY[ypos+1] = (MazeX); // put the vectors of row[X] into MazeY[x]
   		//MazeX.IncrementRowY();   		// record the column position in row Y

    }
    
	
  }

	//print( "hello you fool" + (XPosition[2]));
	//print(ZPosition[2]);
	

}

//var MoveAmount = 10 * Time.deltaTime;
//var pcx :int = PacmanPos[0];
//var pcy :int = PacmanPos[1];

function Update () {


//if(Input.GetKey("up")){
//print("up");
//var vv : Vector3 = test[pcx,pcy];
//if (transform.position == test[pcx,pcy]){
////if (pcx != test.length){pcx++;}
//if (pcy != test.length -1 || pcy != 0){pcy++;}
//}
//transform.position = Vector3.MoveTowards(transform.position,vv, MoveAmount);
//}


}
