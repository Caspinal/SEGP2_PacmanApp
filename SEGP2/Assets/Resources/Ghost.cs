using UnityEngine;
using System.Collections;

public class Ghost: MonoBehaviour {

	// Use this for initialization


	public DataHolder DH;
	public GameObject MC;
	int GhostX;
	int GhostY;

	bool up = true;
	bool MovingUp;

	bool down = true;
	bool MovingDown;

	bool left = true;
	bool MovingLeft;


	bool right = true;
	bool MovingRight;

	bool moving = true;

	bool trigger = true;

	void Start () {
		MC = GameObject.Find("Main Camera");
		DH = MC.GetComponent<DataHolder>();
	}
	
	// Update is called once per frame

	IEnumerator MoveUp() {
		while (true && MovingUp == true) {
			up = false;
			transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
			if (DH.StoredRefCoordinates[(GhostX),(GhostY + 1)] != 'w'){

				transform.position = Vector3.Lerp(DH.StoredCoordinates[GhostX,GhostY],DH.StoredCoordinates[(GhostX),(GhostY + 1)],1);
				GhostY++;
			}
			yield return new WaitForSeconds(0.16f);

			up = true;
		}

	}



	IEnumerator MoveDown() {
		while (true && MovingDown == true) {
			down = false;
			transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
			if (DH.StoredRefCoordinates[(GhostX),(GhostY - 1)] != 'w'){
			
				transform.position = Vector3.Lerp(DH.StoredCoordinates[GhostX,GhostY],DH.StoredCoordinates[(GhostX),(GhostY  - 1)],1);
				GhostY--;
			}
			yield return new WaitForSeconds(0.16f);

		
			down = true;
		}
		
	}

	IEnumerator MoveLeft() {
		while (true && MovingLeft == true) {
			left = false;
			transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);	
			if (DH.StoredRefCoordinates[(GhostX + 1),(GhostY)] != 'w'){
			
				transform.position = Vector3.Lerp(DH.StoredCoordinates[GhostX,GhostY],DH.StoredCoordinates[(GhostX + 1),(GhostY)],1);
			GhostX++;
			}
			yield return new WaitForSeconds(0.16f);
		
		
			left = true;
		}
		
	}


	IEnumerator MoveRight() {
		while (true && MovingRight == true) {
			right= false;
			
			transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);
			if (DH.StoredRefCoordinates[(GhostX - 1),(GhostY)] != 'w'){
				transform.position = Vector3.Lerp(DH.StoredCoordinates[GhostX,GhostY],DH.StoredCoordinates[(GhostX - 1),(GhostY)],1);
				GhostX--;
			}
			yield return new WaitForSeconds(0.16f);


			right = true;
		}
		
	}

	IEnumerator MoveRandomly() {
		while (true) {
			moving = false;
			//yield return new WaitForSeconds(30.0f);
			int x = Random.Range(1,5);
			yield return new WaitForSeconds(2.0f);
			switch(x){
				
			case 1:
				//yield return new WaitForSeconds(10.0f);
				MovingUp = true;
				MovingDown = false;
				MovingLeft = false;
				MovingRight = false;
				
				if(up == true){
					StartCoroutine(MoveUp());
				}

				break;
				
				
				
				
				
				
				
			case 2:

				//yield return new WaitForSeconds(10.0f);
				MovingUp = false;
				MovingDown = true;
				MovingLeft = false;
				MovingRight = false;
				
				if(down == true){
					StartCoroutine(MoveDown());
				}

				break;
				
			case 3:
				
				
				//yield return new WaitForSeconds(10.0f);
				MovingUp = false;
				MovingDown = false;
				MovingLeft = false;
				MovingRight = true;
				
				if(right == true){
					StartCoroutine(MoveRight());
				}

				break;
				
			case 4:
				
				//yield return new WaitForSeconds(10.0f);
				MovingUp = false;
				MovingDown = false;
				MovingLeft = true;
				MovingRight = false;
				
				if(left == true){
					StartCoroutine(MoveLeft());
				}

				break;
				
			}
			moving = true;

		}
		
	}







	void Update () {

		if (trigger == true) {
			GhostX = DH.ClydeX;
			GhostY = DH.ClydeY;
			// get ghost!


			trigger = false;
		}

		if (moving == true){
		StartCoroutine(MoveRandomly());
		}

	}
}