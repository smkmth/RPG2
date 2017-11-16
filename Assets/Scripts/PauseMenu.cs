using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public GameObject PausePanel;
	public GameState _GameState;

	void Start(){
		PausePanel.SetActive (false);
	}


	void Update(){
		if (_GameState.gameState < 5 && Input.GetKeyDown (KeyCode.Escape)) {
			PauseGame ();
		}

		else if (_GameState.gameState == 5 && Input.GetKeyDown(KeyCode.Escape)){
			ResumeGame ();
		

		}

	}

	public void PauseGame() {
		_GameState.gameState = 5;
		PausePanel.SetActive (true);
		Time.timeScale = 0;

	}
	public void ResumeGame(){
		_GameState.gameState = 1;
		PausePanel.SetActive (false);
		Time.timeScale = 1;
	}

		
}
