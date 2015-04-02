using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {
	//Public variables
	static internal WorldManager instance;
	public Transform[] blocksPrefabs;
	public Transform[] obstaclesPrefabs;
	public int maxBlocksOnRoad;
	//Private variables
	private int blocksPrefabsLenght;
	private int obstaclesPrefabsLenght;

	//On the start of the game, create a road with the especified numbers of blocks in the road
	void Awake(){
		//Generate the singleton instance of this class
		instance = this;
		//Store the amount of prefabs in the array
		blocksPrefabsLenght = blocksPrefabs.Length;
		//Store the amount of prefabs in the array
		obstaclesPrefabsLenght = obstaclesPrefabs.Length;
	}

	void Start(){
		//If there are blocks in the prefabs list, Instantiate the requeried amount of them.
		if (blocksPrefabsLenght > 0) {
			for (int i = 0; i < maxBlocksOnRoad; i++) {
				Transform newBlockPrefab = GenerateRandomBlock();
				//Send the game manager the prefab to be instantiated.
				GameManager.instance.AddNewBlock(newBlockPrefab);
			}
		}
	}

	//Function that generates a new random bock prefab
	Transform GenerateRandomBlock(){
		int randomIndex = Random.Range (0, blocksPrefabsLenght);
		return blocksPrefabs[randomIndex];
	}

	//Function to add some obstacles to the game
	public void AddNewObstacle(){
		Transform newObstaclePrefab = GenerateRandomObstacle ();
		//Send the obstacle to be instantiated into the road.
		GameManager.instance.AddNewObstacle (newObstaclePrefab);
	}

	//Function that generates a new random bock prefab
	Transform GenerateRandomObstacle(){
		int randomIndex = Random.Range (0, obstaclesPrefabsLenght);
		return obstaclesPrefabs[randomIndex];
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.O))
			AddNewObstacle ();
	}

	//TODO: Implement a way to make the obstacles appear (randomly/based on distance/points)
	//TODO: Implement a way to make the obstacles appear (randomly/based on distance/points)
}
