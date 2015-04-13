
/***
 * Originally created: Connor
 * Edited by: Yahya
 * 
 * Changes made by Yahya: 
 * Changed algorithm for movement however used most of the code 
 * created by Connor. The code was moved around and placed in switches and 
 * a counter was used to track direction of movement (and more). Also boolean variables 
 * were used to make sure the key could not be pressed again simultaniously 
 * but instead the user had to wait 0.16 seconds. This is similar to what 
 * Connor did however he checked if a key was pressed and did not allow it to 
 * be pressed again unless another key was pressed. This could not work in this
 * situation as the algorithm is changed and it works in a different way.
 * Changed the function of the up key. Now, the up key just starts the initial movement
 * of pacman and is not needed after that as pacman will always travel up now
 * 
 * Differences it made within the game:
 * Down, right, and left keys now work in all directions so pressing right will make 
 * pacman move right and rotate to 90 degrees so it is facing right. Pressing right again will make 
 * pacman rotate to 180 degrees so it is facing down but will also allow him to move down. This works with
 * all directions. Previously, up, left, right, and down keys were only working from one direction. 
 * 
 * 
 * Changes still needed: 
 * To refractor the code so that similar lines of code can be removed
 * To set 
 * 
 * Date: 30/03/2015
 * 
 **/

using UnityEngine;
using System.Collections;

public class PacManV2 : MonoBehaviour {
	
	// Use this for initialization
	

	public DataHolder DH;				// used to access DataHolder script
	public GameObject MC;				// used to find Main Camera Object

	int pacmanX;						// stores Pacmans X co-ordinate 
	int pacmanY;						// stores Pacmans Y co-ordinate

	bool rightPressed = true;			// checks if rightKey has been pressed
	bool leftPressed = true;			// checks if leftKey has been pressed
	bool downPressed = true;			// checks if downKey has been pressed
	bool moving = true;					// used to make pacman move constantly


	bool trigger = true;				// used to execute statements in the first frame
	int counter = 0;					// used to check what way pacman is facing

	void Start () {								// Executed once 
		MC = GameObject.Find("Main Camera");	// finds and stores the Main Camera Object
		DH = MC.GetComponent<DataHolder>();		// accesses the DataHolder script attached to it
	}

	/*
	 * This method/function makes sure that the up key is pressed
	 * so that pacman can move. If the up key is not pressed, pacman cannot 
	 * move however he can still rotate.
	 * 
	 */
	IEnumerator PressUpKey() {						 // this method is executed in the first frame and continues until complete
		while(!(Input.GetKey("up"))) {				 // while the user does not press the up key
			Debug.Log ("Please press the up key");	 // print this message
			yield return new WaitForSeconds (0.10f); // wait 0.10 seconds before the loop is iterated again 
		}
		StartCoroutine (StartMoving ());			// when the user presses up, the StartMoving() method is launched
	}

	/*
	 * This method allows pacman to always move. Once the up key is pressed within 
	 * the PressUpKey() method, this method is launched. The method uses a while 
	 * loop to ensure pacman is always moving and then checks which direction pacman 
	 * is facing using cases within a switch. Within each case is slightly different 
	 * code to move pacman one position forward relative to the way pacman is facing.
	 * 
	 * Cases from 0-3 are used when pacman is facing forward, right, down and left. The 
	 * reason why they are possitive depends on the implementation for rotation. When the right key is pressed, 
	 * then a counter is incremented. If it is pressed again (right key) then the counter is 
	 * incremented again and this is continued up until a full clockwise rotation has been made back 
	 * to facing forward. But if the user presses the left key, then another value for the counter 
	 * to show that we are rotating anti-clockwise is needed. This is because if the left key is pressed
	 * from facing right, then we will face forward, if the left key is pressed from facing down, then 
	 * we will face right etc. But if the left key is pressed from facing forward, then it needs to 
	 * show that we are facing left. 
	 * 
	 */
	IEnumerator StartMoving() {			 // this method is executed once the up key is pressed
		while (moving) {				 // while we are moving, this is always true at this moment
			switch(counter) {			 // enter the switch
			case 0:															// if pacman is facing up											
				if(DH.StoredRefCoordinates[pacmanX, pacmanY+1] != 'w') {	// check if there is a wall infront of us
					pacmanY++;												// if not, then increment Y co-ordinate
					transform.position  = new Vector3(pacmanX, 0, pacmanY); // change our position to the new overall position
				}
				yield return new WaitForSeconds(0.16f);						// wait 0.16 seconds before we move another space
				break;														// exit from the switch statement

			case 1:															// if pacman is facing right
				if(DH.StoredRefCoordinates[pacmanX+1, pacmanY] != 'w') {
					pacmanX++;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;

			case 2:															// if pacman is facing down
				if(DH.StoredRefCoordinates[pacmanX, pacmanY-1] != 'w') {
					pacmanY--;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;

			case 3:															// if pacman is facing left
				if(DH.StoredRefCoordinates[pacmanX-1, pacmanY] != 'w') {
					pacmanX--;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;

			case -1:														
				if(DH.StoredRefCoordinates[pacmanX-1, pacmanY] != 'w') {	// if pacman is facing left
					pacmanX--;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;
				
			case -2:														// if pacman is facing down
				if(DH.StoredRefCoordinates[pacmanX, pacmanY-1] != 'w') {
					pacmanY--;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;
				
			case -3:													   // if pacman is facing right
				if(DH.StoredRefCoordinates[pacmanX+1, pacmanY] != 'w') {
					pacmanX++;
					transform.position = new Vector3(pacmanX, 0, pacmanY);
				}
				yield return new WaitForSeconds(0.16f);
				break;

			default:
				Debug.Log ("Error");
				break;
			}
		}
	}

	/*
	 * This method is executed when the right key is pressed. Its purpose is to iterate the 
	 * counter to show that we want to rotate right from the current position. An if statement 
	 * is used to make sure that once we have made a full rotation, the counter resets to 0. 
	 * 
	 * The variable rightPressed is set to false at the beginning of the method to ensure 
	 * that the right key cannot be pressed until this coroutine ends. This is so that 
	 * pacman does not rotate 3-6 times for a single key press as this would make the 
	 * rotation somewhat uncontrollable. After the switch statement, rightPressed is set 
	 * to true to allow the user to rotate again. There is a 0.16 second gap from entering
	 * the method to pressing the right key again to control the occurance of rotating right.
	 * 
	 * Within each case, slightly different code is used to control what direction pacman should 
	 * be facing. Counters are again used to keep track of the direction of rotation and each counter
	 * represents the desired direction of rotation. So counter 2 represents that pacman would like 
	 * to face downwards so it is rotated 180 degrees. The rotation here is not incremented but it is
	 * rotated to a certain position within the game so 180 degrees within any case would always rotate 
	 * to down. 
	 * 
	 */

	IEnumerator RotateRight() {  // this method is executed when the user presses the right key
		rightPressed = false;	 // false to avoid pressing key again until after the method is exectuted (once)
		counter++;				 // increment counter to show we are rotating to the right
		if (counter > 3) {		 // if we complete a full clockwise rotation, 
			counter = 0;		 // then set counter back to 0
		}
		switch(counter) {		 // enter the switch 
		case 0:														// if pacman wants to face forward
			transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);  // rotate to 0 degrees
			yield return new WaitForSeconds(0.16f);					// wait 0.16 seconds before you can press right key again
			break;

		case 1:														// if pacman wants to face right,
			transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f); // rotate to 90 degrees
			yield return new WaitForSeconds(0.16f);
			break;

		case 2:														 // if pacman wants to face down,
			transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f); // rotate to 180 degrees
			yield return new WaitForSeconds(0.16f);
			break; 

		case 3:														 // if pacman wants to face left
			transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f); // rotate to 270 degrees
			yield return new WaitForSeconds(0.16f);
			break;

		case -1:													 // if pacman wants to face left 
			transform.rotation = Quaternion.Euler(0.0f,-90.0f,0.0f); // rotate -90 degrees (270)
			yield return new WaitForSeconds(0.16f);
			break;
			
		case -2:													  // if pacman wants to face down
			transform.rotation = Quaternion.Euler(0.0f,-180.0f,0.0f); // rotate -180 degrees (180)
			yield return new WaitForSeconds(0.16f);
			break;
			
//		case -3:													  // case 3 does not seem to be needed as you will 
//			Debug.Log ("Entered case -3");							  // never face that direction from pressing right rather 
//			transform.rotation = Quaternion.Euler(0.0f,-270.0f,0.0f); // you will rotate from -3 to -2. From debugging with case 
//			yield return new WaitForSeconds(0.16f);					  // debug messages, case -3 is never entered 
//			break;
		default:
			Debug.Log ("Error");
			break;
		}

		rightPressed = true; // true so that the user can now press the right key
	}


	/*
	 * The rotateLeft() method is similar to the rotateRight() method however
	 * instead of incrementing the counter, it decrements it to show that the user
	 * wants to rotate left. If the counter is decremented so that it eventually 
	 * rotates anti-clockwise all the way to the beginning (facing forward), the counter is 
	 * set to 0.
	 */
	IEnumerator rotateLeft() {
		leftPressed = false;
		counter--;
		if (counter < -3) {
			counter = 0;
		}
		switch(counter) {
		case 0:
			transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case 1:
			transform.rotation = Quaternion.Euler(0.0f,90.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break;
			
		case 2:
			transform.rotation = Quaternion.Euler(0.0f,180.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break; 
			
//		case 3:
//			Debug.Log("Entered case 3");
//			transform.rotation = Quaternion.Euler(0.0f,270.0f,0.0f);
//			yield return new WaitForSeconds(0.16f);
//			break;

		case -1:
			transform.rotation = Quaternion.Euler(0.0f,-90.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break;
			
		case -2:
			transform.rotation = Quaternion.Euler(0.0f,-180.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break;
			
		case -3:
			transform.rotation = Quaternion.Euler(0.0f,-270.0f,0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		default:
			Debug.Log ("Error");
			break;
		}
		
		leftPressed = true;				
	}

	/**
	 * This method rotates pacman so that he rotates 180 degrees from which ever 
	 * direction it is facing. It does this using counters to check which direction 
	 * pacman is currently facing. Then it rotates pacman so depending on the direction 
	 * it is facing by a certain amount. So if pacman was facing 90 degrees (counter 1), it 
	 * would rotate it to 270 degrees. The counter is also incremented or decremented so
	 * that rotation stays relevent. If the counter minus 2  is out of range, as in it is more than 
	 * 3 or less than -3, it is incremented or decremented so that it stays within the range. 
	 */
	IEnumerator rotateDown() {
		downPressed = false;
		switch (counter) {
		case 0:
			counter-=2;
			transform.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case 1:
			counter+=2;
			transform.rotation = Quaternion.Euler (0.0f, 270.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;
		case 2:
			counter-=2;
			transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case 3:
			counter-=2;
			transform.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case -1:
			counter-=2;
			transform.rotation = Quaternion.Euler (0.0f, -270.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case -2:
			counter+=2;
			transform.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;

		case -3:
			counter+=2;
			transform.rotation = Quaternion.Euler (0.0f, -90.0f, 0.0f);
			yield return new WaitForSeconds(0.16f);
			break;	
		}
		downPressed = true;
	}


	void Update() {
		if (trigger == true) {  					// enter if first frame as trigger is true
			pacmanX = DH.PacmanX;					// store x co-ordinate of pacman
			pacmanY = DH.PacmanY;					// store y co-ordinate of pacman
			trigger = false;						// set trigger to false to avoid entering if block again
			StartCoroutine (PressUpKey());			// start the coroutine to move pacman in the direction it is facing
		}

		if (Input.GetKey ("right")) {				// if the user presses right key,
			if(rightPressed == true) {				// if right pressed is true
				StartCoroutine(RotateRight ());		// then lauch the coroutine to rotate pacman right and move in that direction 
			}
		}

		if(Input.GetKey ("left")) {					// if the user presses left key, 
			if(leftPressed == true) {				// if left key pressed is true
				StartCoroutine (rotateLeft());      // then launch coroutine to rotate pacman left and move in that direction 
			}
		}

		if (Input.GetKey ("down")) {				// if the user presses the down key,
			if(downPressed == true) {				// if the down key is pressed is true, 
				StartCoroutine (rotateDown());		// start the coroutine to rotate pacman down
			}
		}
	}
}