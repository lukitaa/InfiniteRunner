using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	//Public variables
	static internal PlayerManager instance;
	public FollowTarget cameraScript;
	public Transform playerPrefab;
	//Private variables
	Transform playerInstance;
	PlayerMovement playerMovement;

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
		//Save the PlayerMovement component of the player
		playerMovement = playerInstance.GetComponent<PlayerMovement> ();
	}

	public void MovePlayerForward(float zMovement) {
		playerMovement.MovePlayerForward (zMovement);
	}

	public void MovePlayerSideway(float xMovement) {
		playerMovement.MovePlayerSideway (xMovement);
	}

	public void MovePlayerJump(float yMovement) {
		playerMovement.PlayerJump (yMovement);
	}

	//TODO: Implement slide movement
	public void MovePlayerSlide(){

	}
}
