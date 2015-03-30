using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour {
	//Public variables
	static internal GameManagerScript instance;
	public float blocksPositionOffset;
	public Transform blocksParent;
	//Private variables
	private List<Transform> spawnedBlocks;
	private float lastBlockZ;
	private int currentScore;
	// Use this for initialization
	void Awake () {
		//Generate the singleton instance of this class
		instance = this;
		//Create a new instance of the blocks list
		spawnedBlocks = new List<Transform> ();
		//Set the default value of lastBlockZ to be the start point
		lastBlockZ = 0 - blocksPositionOffset;
	}

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
	public void MoveLastBlock(Transform block, int scoreToAdd){
		ChangeBlockPosition (block);
		currentScore += scoreToAdd;
		UIManagerScript.instance.setScoreTo (currentScore);
	}

}
