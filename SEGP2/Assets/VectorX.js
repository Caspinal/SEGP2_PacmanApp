#pragma strict

public class VectorX extends MonoBehaviour{

	var pointer = 0;
	var MazeX = new Array();
	var rowreference = 0;

function IncrementPointer() {
	this.pointer++;

}

function DecrementPointer() {
	this.pointer--;

}

function getVector() {

return MazeX[pointer];

}


function setVector(X : float, Y : float, Z : float ) {

	this.MazeX[pointer] = new Vector3(X,Y,Z);

}

function setPointer(p: int) {

	this.pointer = p;

}

function printXvector(){

	for (var i = 0; i < MazeX.length; i++){
		print(MazeX[i]);
		}
	}

function IncrementRowY(){

	this.rowreference++;		
	
}

function DecrementRowY(){

	this.rowreference--;		
	
}


function getRowY(){

	return rowreference;		
	
}

}



