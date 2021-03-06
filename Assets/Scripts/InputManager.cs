﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	//Public variables
	static internal InputManager instance;
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
		SlideMovement ();
	}

	//Function to check horizontal movement
	void HorizontalMovement(){
		//Check the horizontal movement
		if(Input.GetButtonDown("Horizontal"))
			PlayerManager.instance.MovePlayerSideway (Input.GetAxisRaw("Horizontal"));
	}

	void VerticalMovement(){
		//Do we want the player to automatically move forward? or do we want the player to be able to move by himself?
		//		IF WANTED TO MOVE AUTOMATICALLY:
		verticalMovement = maxSpeed * Time.deltaTime;
		//		IF WANTED TO MOVE MANUALLY
		//		Grab the current horizontal and vertical movement
		//verticalMovement = Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		//If the vertical movement isn't 0, then the player should move (Used for the manual movement, otherwise it always move)
		if (verticalMovement != 0)
			PlayerManager.instance.MovePlayerForward(verticalMovement);
	}

	void JumpMovement(){
		//Check for jumping
		if (Input.GetButtonDown("Jump"))
			PlayerManager.instance.MovePlayerJump (jumpPower);
	}

	void SlideMovement(){
		//Check if the player pressed the slide key.
		if(Input.GetButtonDown("Vertical")){
			if(Input.GetAxisRaw("Vertical") < 0)
				Debug.Log("GOTTA SLIDE MAN");
		}
	}

}
