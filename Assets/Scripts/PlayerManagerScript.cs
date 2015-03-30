using UnityEngine;
using System.Collections;

public class PlayerManagerScript : MonoBehaviour {
	//Public variables
	static internal PlayerManagerScript instance;
	public CameraFollowPlayer cameraScript;
	public Transform playerPrefab;
	public float distanceToGround;
	public float movementSize;
	public float movementSpeed;
	//Private variables
	Transform playerInstance;
	float currentHorizontalPosition;
	Vector3 moveTo;
	bool _isMoving;

	// Use this for initialization
	void Awake () {
		//Assign the singleton instance
		instance = this;
	}

	void Start(){
		//Instantiate the player and change it's name
		playerInstance = (Transform) Instantiate (playerPrefab, new Vector3 (0, 3, 0), Quaternion.identity);
		playerInstance.name = "Player";
		//Assign the camera the player object so it can be followed
		cameraScript.SetTarget (playerInstance);
	}

	//Function to move the player forward
	public void MovePlayerForward(float zMovement){
		//moveTo = playerInstance.position;
		moveTo.z += zMovement;
	}

	//Function to move the player horizontally
	public void MovePlayerSideway(float horizontalMovement){
		if ((horizontalMovement == 1 && currentHorizontalPosition != 1) || (horizontalMovement == -1 && currentHorizontalPosition != -1)) {
			//Change the horizontal position where the player should move to
			moveTo.x += movementSize * horizontalMovement;
			//Change the current position
			currentHorizontalPosition += horizontalMovement;
		}
	}

	//Function to make the player jump
	public void PlayerJump(float yMovement){
		if (canJump())
			playerInstance.rigidbody.AddForce(new Vector3(0f,yMovement,0f),ForceMode.Impulse);
	}


	//If the player is hitting the ground returns true, otherwise false
	bool canJump(){
		return Physics.Raycast(playerInstance.transform.position, -Vector3.up, distanceToGround);
	}

	//
	void FixedUpdate(){
		playerInstance.position = Vector3.Lerp(playerInstance.position, moveTo, Time.deltaTime * movementSpeed);
	}

}
