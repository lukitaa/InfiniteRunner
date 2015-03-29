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
	public bool isMoving {
		get { 
			return (moveTo != Vector3.zero) ? true : false;	
		}
		set{ _isMoving = value; }
	}
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
		//Change the transform of the object
		Vector3 newPosition = playerInstance.position;
		newPosition.z += zMovement;
		playerInstance.position = newPosition;
	}

	//Function to make the player jump
	public void PlayerJump(float yMovement){
		if (canJump())
			playerInstance.rigidbody.AddForce(new Vector3(0f,yMovement,0f),ForceMode.Impulse);
	}

	//Function to move the player horizontally
	public void MovePlayerSideway(float horizontalMovement){
		if ((horizontalMovement == 1 && currentHorizontalPosition != 1) || (horizontalMovement == -1 && currentHorizontalPosition != -1)) {
			//Move the player
			Vector3 newPosition = playerInstance.position;
			newPosition.x += movementSize * horizontalMovement;
			//playerInstance.position = newPosition;
			moveTo = newPosition;
			//Change the current position
			currentHorizontalPosition += horizontalMovement;
		}
	}

	//If the player is hitting the ground returns true, otherwise false
	bool canJump(){
		return Physics.Raycast(playerInstance.transform.position, -Vector3.up, distanceToGround);
	}

	//
	void Update(){
		//If there's not a point where the player should move to do nothing
		if (!isMoving)
			return;
		//Move the object based on what type of movement the object has
		playerInstance.position = Vector3.MoveTowards(playerInstance.position, moveTo, Time.deltaTime * movementSpeed);
		//Get the distance squared of the current position of the object to the position of the point to go of the path
		float distanceSquared = (playerInstance.position - moveTo).sqrMagnitude;
		//Check if the distance position is less than the MaxDistanceToGoal set in beforehand to start
		//Moving to the next point, in that case, get the next position that we should move to
		if (distanceSquared < 0.2f * 0.2f)
			moveTo = Vector3.zero;

	}

}
