using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	//Public variables
	public float yOffset;
	public float zOffset;
	//Private variables
	Transform target;
	Transform mTransform;

	//Save the transfrom variable
	void Awake(){
		mTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		if (target != null) {
			//Change the position to follow the required target
			Vector3 newPosition = target.position;
			//Offset where the camera is placed at
			newPosition.y = yOffset;
			newPosition.z = target.position.z - zOffset;
			//Assign the new position to the camera
			mTransform.position = newPosition;
		}
	}

	public void SetTarget(Transform target){
		this.target = target;
	}
}
