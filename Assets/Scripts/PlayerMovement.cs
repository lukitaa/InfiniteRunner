using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//Public variables
	public float movementSize;
	public float distanceToGround;
	public float movementSpeed;
	//Private variables
	float currentHorizontalPosition;
	Vector3 moveTo;
	Transform mTransform;

	void Awake() {
		mTransform = transform;
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
			mTransform.rigidbody.AddForce(new Vector3(0f,yMovement,0f),ForceMode.Impulse);
	}
	
	
	//If the player is hitting the ground returns true, otherwise false
	bool canJump(){
		return Physics.Raycast(mTransform.transform.position, -Vector3.up, distanceToGround);
	}
	
	//
	void FixedUpdate(){
		mTransform.position = Vector3.Lerp(mTransform.position, moveTo, Time.deltaTime * movementSpeed);
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Obstacle") {
			GameManager.instance.GameOver();
		}
	}
}
