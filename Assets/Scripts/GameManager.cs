﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	//Public variables
	static internal GameManager instance;
	public float blocksPositionOffset;
	public float obstacleOffset;
	public Transform blocksParent;
	//Private variables
	private List<Transform> spawnedBlocks;
	private float lastBlockZ;
	private float currentScore;
	private Transform mTransform;
	private Transform playerInstance;

	// Use this for initialization
	void Awake () {
		//Generate the singleton instance of this class
		instance = this;
		//Create a new instance of the blocks list
		spawnedBlocks = new List<Transform> ();
		//Set the default value of lastBlockZ to be the start point
		lastBlockZ = 0 - blocksPositionOffset;
		//Store the transform of this object
		mTransform = transform;
	}

	/// <summary>
	/// The following 3 functions are used for the blocks of the road.
	/// </summary>
	//Function that instantiates a new block into the road and adds it into the currents blocks list
	public void AddNewBlock(Transform block){
		//Instantiate the new block into the world.
		Transform newBlock = (Transform) Instantiate (block);
		//Set the parent of the new block to be the blocks container.
		newBlock.parent = blocksParent;
		//Change the block position to fit into the last spot of the road.
		ChangeBlockPosition (newBlock);
		//Add the new block into the spawned blocks, in case that needs to be used later
		spawnedBlocks.Add (newBlock);
	}

	//Function to change a block position to fit into the last spot of the road.
	void ChangeBlockPosition(Transform block){
		//Change the block Z position
		Vector3 newBlockPos = block.position;
		newBlockPos.z = blocksPositionOffset + lastBlockZ;
		block.position = newBlockPos;
		//Save the lastBlockZ to be the new block one
		lastBlockZ = newBlockPos.z;
	}

	//Function that gots called from other scripts to move the blocks to the last position
	public void MoveLastBlock(Transform block){
		ChangeBlockPosition (block);

	}

	/// <summary>
	/// The upcoming 3 functions are used for the obstacles of the game.
	/// </summary>
	public void AddNewObstacle(Transform newObstaclePrefab){
		int obstacleX = Random.Range(-1,1);
		//Instantiate the new block into the world.
		Transform newObstacle = (Transform) Instantiate (newObstaclePrefab);
		//Set the parent of the new block to be the blocks container.
		newObstacle.parent = blocksParent;
		//Change the block newObstacle to fit into the last spot of the road.
		ChangeObstaclePosition (newObstacle,obstacleX);
	}
	

	public void MoveLastObstacle(Transform obstacle){
		int obstacleX = Random.Range(-1,1);
		ChangeObstaclePosition (obstacle,obstacleX);
	}

	void ChangeObstaclePosition(Transform obstacle, int position){
		Vector3 newPos = new Vector3 (obstacleOffset * position, 1f, --lastBlockZ);
		obstacle.position = newPos;
	}

	//Look for the player transform
	void Start() {
		FindPlayerTransform ();
	}

	//Function to find the player Transform component
	void FindPlayerTransform(){
		if (playerInstance == null) {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if(player == null){
				Debug.Log("There's no GameObject with the tag 'Player'");
				return;
			}
			playerInstance = player.transform;
		}
	}

	//Check if there's a player instance seted, and change the score. Otherwise do nothing.
	void Update() {
		if (playerInstance == null) {
			FindPlayerTransform();
			if(playerInstance == null)
				return;
		}
		//Change the score.
		currentScore = Vector3.Distance (mTransform.position, playerInstance.position);
		UIManager.instance.setScoreTo (currentScore);
	}

	public void GameOver() {
		//TODO: Implement the game over function.
		//TODO: Implement the game over function.
		Application.LoadLevel ("GameOver");
	}

	//TODO: Implement a way to make the obstacles appear (randomly/based on distance/points)
	//TODO: Implement a way to make the obstacles appear (randomly/based on distance/points)

}
