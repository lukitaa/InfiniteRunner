using UnityEngine;
using System.Collections;

public class InputManagerScript : MonoBehaviour {
	//Public variables
	static internal InputManagerScript instance;
	public float maxSpeed;
	public float jumpPower;
	//Private variables
	float verticalMovement;
	float horizontalMovement;

	void Awake(){
		//Generate the singleton instance
		instance = this;
	}

	void Update(){
		VerticalMovement ();
		HorizontalMovement ();
		JumpMovement ();
	}

	//Function to check horizontal movement
	void HorizontalMovement(){
		//Check the horizontal movement
		if(Input.GetButtonDown("Horizontal") && !PlayerManagerScript.instance.isMoving)
			PlayerManagerScript.instance.MovePlayerSideway (Input.GetAxisRaw("Horizontal"));
	}

	void VerticalMovement(){
		//Do we want the player to automatically move forward? or do we want the player to be able to move by himself?
		//		IF WANTED TO MOVE AUTOMATICALLY:
		//verticalMovement = maxSpeed * Time.deltaTime;
		//		IF WANTED TO MOVE MANUALLY
		//		Grab the current horizontal and vertical movement
		verticalMovement = Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		//If the vertical movement isn't 0, then the player should move (Used for the manual movement, otherwise it always move)
		if (verticalMovement != 0)
			PlayerManagerScript.instance.MovePlayerForward(verticalMovement);
	}

	void JumpMovement(){
		//Check for jumping
		if (Input.GetButtonDown("Jump"))
			PlayerManagerScript.instance.PlayerJump (jumpPower);
	}

}
