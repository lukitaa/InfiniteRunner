using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
	//Public variables
	static internal UIManagerScript instance;
	//Private variables
	Text scoreText;

	void Awake(){
		//Make this a singleton
		instance = this;
		//Get the score UI.Text component
		scoreText = Text.FindObjectOfType<Text> ();
	}

	//Change the UI.Text text to have the new score.
	public void setScoreTo(int score){
		scoreText.text = "Current score: " + score;
	}

}
