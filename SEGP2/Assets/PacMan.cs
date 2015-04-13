using UnityEngine;
using System.Collections;

public class PacMan : MonoBehaviour {

	// Use this for initialization


	public DataHolder DH;
	public GameObject MC;

	int CurrentRotation;

	int PacmanX;
	int PacmanY;

	bool up = true;
	bool MovingUp;

	bool down = true;
	bool MovingDown;

	bool left = true;
	bool MovingLeft;


	bool right = true;
	bool MovingRight;



	bool trigger = true;

	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame

	IEnumerator MoveUp() {
		while (true && MovingUp == true) {
			up = false;
			//transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);

			if (DH.StoredRefCoordinates[(PacmanX),(PacmanY + 1)] != 'w'){

				transform.position = Vector3.Lerp(DH.StoredCoordinates[PacmanX,PacmanY],DH.StoredCoordinates[(PacmanX),(PacmanY + 1)],Time.deltaTime * 1);
				PacmanY++;
			}
			yield return new WaitForSeconds(0.16f);

			up = true;
		}

	}



	IEnumerator MoveDown() {
		while (true && MovingDown == true) {
			down = false;
			//transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);

			if (DH.StoredRefCoordinates[(PacmanX),(PacmanY - 1)] != 'w'){
			
				transform.position = Vector3.Lerp(DH.StoredCoordinates[PacmanX,PacmanY],DH.StoredCoordinates[(PacmanX),(PacmanY - 1)],Time.deltaTime * 1);
			PacmanY--;
			}
			yield return new WaitForSeconds(0.16f);

		
			down = true;
		}
		
	}

	IEnumerator MoveRight() {
		while (true && MovingRight == true) {
			right = false;
			//transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);

			if (DH.StoredRefCoordinates[(PacmanX + 1),(PacmanY)] != 'w'){
			
				transform.position = Vector3.Lerp(DH.StoredCoordinates[PacmanX,PacmanY],DH.StoredCoordinates[(PacmanX + 1),(PacmanY)],Time.deltaTime * 1);
			PacmanX++;
			}
			yield return new WaitForSeconds(0.16f);
		
		
			right = true;
		}
		
	}


	IEnumerator MoveLeft() {
		while (true && MovingLeft == true) {
			left = false;
			
			//transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);

			if (DH.StoredRefCoordinates[(PacmanX - 1),(PacmanY)] != 'w'){
				transform.position = Vector3.Lerp(DH.StoredCoordinates[PacmanX,PacmanY],DH.StoredCoordinates[(PacmanX - 1),(PacmanY)],Time.deltaTime * 1);
			PacmanX--;
			}
			yield return new WaitForSeconds(0.16f);


			left = true;
		}
		
	}








	void Update () {

		CurrentRotation = (int)transform.eulerAngles.y;
		Debug.Log (CurrentRotation);
		if (trigger == true) {
			PacmanX = DH.PacmanX;
			PacmanY = DH.PacmanY;
			trigger = false;
		}



		if (Input.GetKey("up")){

		switch(CurrentRotation){
			
			case 0:
			
			MovingUp = true;
			MovingDown = false;
			MovingLeft = false;
			MovingRight = false;

			if(up == true){
			StartCoroutine(MoveUp());
					transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);

				}
			break;

			case 90:

				MovingUp = false;
				MovingDown = false;
				MovingLeft = true;
				MovingRight = false;
				
				if(left == true){
					StartCoroutine(MoveLeft());
					transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);

				}

				break;

			case 180:

				MovingUp = false;
				MovingDown = true;
				MovingLeft = false;
				MovingRight = false;
				
				if(down == true){
					StartCoroutine(MoveDown());
					transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);

				}
				break;
			case 270:

				MovingUp = false;
				MovingDown = false;
				MovingLeft = false;
				MovingRight = true;
				
				if(right == true){
					StartCoroutine(MoveRight());
					transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);

				}

			break;
		}	
		}

//		switch(CurrentRotation){
//			
//		case 0:
//		break;
//		case 90:
//		break;
//		case 180:
//		break;
//		case 270:
//		break;

		if (Input.GetKey("down")){

		switch(CurrentRotation){
						
		case 0:
				MovingUp = false;
				MovingDown = true;
				MovingLeft = false;
				MovingRight = false;
				
				if(down == true){
					StartCoroutine(MoveDown());
					transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);

				}
		break;
		case 90:
				MovingUp = false;
				MovingDown = false;
				MovingLeft = false;
				MovingRight = true;
				
				if(right == true){
					StartCoroutine(MoveRight());
					transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);

				}
		break;
		case 180:
				MovingUp = true;
				MovingDown = false;
				MovingLeft = false;
				MovingRight = false;
				
				if(up == true){
					StartCoroutine(MoveUp());
					transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);

				}
		break;
		case 270:
				MovingUp = false;
				MovingDown = false;
				MovingLeft = true;
				MovingRight = false;
				
				if(left == true){
					StartCoroutine(MoveLeft());
					transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);

				}
		break;
			
			}
		}


		if (Input.GetKey("right")){

		switch(CurrentRotation){
							
					case 0:
					MovingUp = false;
					MovingDown = false;
					MovingLeft = false;
					MovingRight = true;
					
					if(right == true){
						StartCoroutine(MoveRight());
					transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);

				}
						break;
						case 90:
					MovingUp = true;
					MovingDown = false;
					MovingLeft = false;
					MovingRight = false;
					
					if(up == true){
						StartCoroutine(MoveUp());
					transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);

				}
						break;
						case 180:

				MovingUp = false;
				MovingDown = false;
				MovingLeft = true;
				MovingRight = false;
				
				if(left == true){
					StartCoroutine(MoveLeft());
					transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);

				}
						break;
						case 270:
					MovingUp = false;
					MovingDown = true;
					MovingLeft = false;
					MovingRight = false;
					
					if(down == true){
					StartCoroutine(MoveDown());
					transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);

				}
						break;
			}
		}

		if (Input.GetKey("left")){

			
			switch(CurrentRotation){
								
			case 0:
						MovingUp = false;
						MovingDown = false;
						MovingLeft = true;
						MovingRight = false;
						
						if(left == true){
							StartCoroutine(MoveLeft());
					transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);

				}
			break;
			case 90:
						MovingUp = false;
						MovingDown = true;
						MovingLeft = false;
						MovingRight = false;
						
						if(down == true){
							StartCoroutine(MoveDown());
					transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);

				}
			break;
			case 180:
					MovingUp = false;
					MovingDown = false;
					MovingLeft = false;
					MovingRight = true;
				
				if(right == true){
					StartCoroutine(MoveRight());
					transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);

				}

			break;
			case 270:
						
						MovingUp = true;
						MovingDown = false;
						MovingLeft = false;
						MovingRight = false;
						
						if(up == true){
							StartCoroutine(MoveUp());
					transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);

				}
				
			break;
			}
		}
	}
}