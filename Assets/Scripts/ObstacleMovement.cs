using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

	//Public fields
	public float minPosX;
	public float maxPosX;
	public float movementSpeed;
	//Private fields
	public bool movingRight;
	Transform mTransform;

	void Awake(){
		mTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		MoveObstacleSideway ();
		IsGoingLeftOrRight ();
	}

	void MoveObstacleSideway(){
		Vector3 newPos = mTransform.position;
		if (movingRight) 
			newPos.x += movementSpeed * Time.deltaTime;
		else 
			newPos.x -= movementSpeed * Time.deltaTime;
		mTransform.position = newPos;
	}

	void IsGoingLeftOrRight(){
		if (movingRight && mTransform.position.x > maxPosX)
			movingRight = !movingRight;
		if (!movingRight && mTransform.position.x < minPosX)
			movingRight = !movingRight;
	}
}
