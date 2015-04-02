using UnityEngine;
using System.Collections;

public class BlocksDestroyer : MonoBehaviour {

	//On the exit of the collision, send the block to be moved to the game manager
	void OnTriggerExit(Collider other){
		//Move the first block to the end of the road.
		if (other.gameObject.tag == "Obstacle")
			GameManager.instance.MoveLastObstacle (other.transform);
		GameManager.instance.MoveLastBlock (other.transform);
	}

}
