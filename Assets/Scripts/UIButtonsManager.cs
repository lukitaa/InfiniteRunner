using UnityEngine;
using System.Collections;

public class UIButtonsManager : MonoBehaviour {

	public void ChangeLevelTo(string levelName){
		Application.LoadLevel (levelName);
	}

	public void ChangeLevelTo(int levelInt){
		Application.LoadLevel (levelInt);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
