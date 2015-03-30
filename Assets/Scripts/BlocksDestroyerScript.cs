using UnityEngine;
using System.Collections;

public class BlocksDestroyerScript : MonoBehaviour {

	public int scoreToAdd;

	//On the exit of the collision, send the block to be moved to the game manager
	void OnTriggerExit(Collider other){
		//Move the first block to the end of the road.
		GameManagerScript.instance.MoveLastBlock (other.transform,scoreToAdd);
	}

}
