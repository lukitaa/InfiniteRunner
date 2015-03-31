using UnityEngine;
using System.Collections;

public class WorldManager : MonoBehaviour {
	//Public variables
	static internal WorldManager instance;
	public Transform[] blocksPrefabs;
	public int maxBlocksOnRoad;
	//Private variables
	private int prefabsLenght;

	//On the start of the game, create a road with the especified numbers of blocks in the road
	void Awake(){
		//Generate the singleton instance of this class
		instance = this;
		//Store the amount of prefabs in the array
		prefabsLenght = blocksPrefabs.Length;
	}

	void Start(){
		//If there are blocks in the prefabs list, Instantiate the requeried amount of them.
		if (prefabsLenght > 0) {
			for (int i = 0; i < maxBlocksOnRoad; i++) {
				Transform newBlockPrefab = GenerateRandomBlock();
				//Send the game manager the prefab to be instantiated.
				GameManager.instance.AddNewBlock(newBlockPrefab);
			}
		}
	}

	//Function that generates a new random bock prefab
	Transform GenerateRandomBlock(){
		int randomIndex = Random.Range (0, prefabsLenght);
		return blocksPrefabs[randomIndex];
	}
}
