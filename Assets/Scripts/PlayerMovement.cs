using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Obstacle") {
			//TODO: Game over dude!
			GameManager.instance.GameOver();
		}
	}
}
