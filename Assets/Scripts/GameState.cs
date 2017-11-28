using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Game states are - as strings :
/// 
/// CharacterCreateMode - Where the character create window shows up - time is paused
/// PlayMode - where the character can move around and interact with the enviroment - time is not paused
/// PauseMode - where you can save and load, change options, quit or resume - time is paused
/// DialogueMode - where you are talking with another npc - atm time is not paused- will change later
/// InventoryMode
/// 
/// </summary>
public class GameState : MonoBehaviour{


	[SerializeField]
	private string gameState;
	public string _GameState {
		
		get {
			return gameState;
		}
		set {
			gameState = value;
			if (gameState != null) {
				GetState ();
				Debug.Log("Game is in ... " + _GameState);

			}
		}
	}
	//public LevelHandler _LevelHandler;

	public GameObject _CharacterSelect;
	public GameObject _Inventory;
	public GameObject _PauseMenu;
	public GameObject _OnScreenGui;
	public GameObject _DialogueWindow;
	public GameObject _ShipElevatorGUI;
	public Button _ContinueButton;



	void Start(){
		//_LevelHandler = gameObject.GetComponent(LevelHandler);
		gameState = "MainMenu";
		GetState ();

	}

	void GetState(){
		if (_GameState == "CharacterCreateMode") {
			_CharacterSelect.SetActive (true);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (false);
			_DialogueWindow.SetActive (false);
			_ShipElevatorGUI.SetActive (false);		

			Time.timeScale = 0;

		} else if (_GameState == "PlayMode") {
			_CharacterSelect.SetActive (false);
			_OnScreenGui.SetActive (true);
			_Inventory.SetActive (false);
			_PauseMenu.SetActive (false);
			_DialogueWindow.SetActive (false);
			_ShipElevatorGUI.SetActive (false);		


			Time.timeScale = 1;

		} else if (_GameState == "PauseMode") {
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (true);
			_DialogueWindow.SetActive (false);
			_ContinueButton.gameObject.SetActive (true);
			_ShipElevatorGUI.SetActive (false);		


			Time.timeScale = 0;
			
		} else if (_GameState == "DialogueMode") {
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (false);
			_DialogueWindow.SetActive (true);
			_ShipElevatorGUI.SetActive (false);		


			Time.timeScale = 1;

		} else if (_GameState == "InventoryMode") {
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (true);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (false);
			_DialogueWindow.SetActive (false);
			_ShipElevatorGUI.SetActive (false);		


			Time.timeScale = 0;

		} else if (_GameState == "MainMenu") {
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (true);
			_DialogueWindow.SetActive (false);
			_ContinueButton.gameObject.SetActive (false);
			_ShipElevatorGUI.SetActive (false);		


			Time.timeScale = 0;

		} else if (_GameState == "ElevatorMode") {
			_ShipElevatorGUI.SetActive (true);		
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (false);
			_PauseMenu.SetActive (false);
			_DialogueWindow.SetActive (false);
			Time.timeScale = 0;


		}
		


	}
	public void ChangeState(string state){
		_GameState = state;
		GetState ();

	}

	void Update () {
		if (_GameState == "PlayMode") {

			if (Input.GetKeyDown (KeyCode.Escape)) {
				ChangeState ("PauseMode");
			}
			
			if (Input.GetButtonDown ("Inventory")) {
				ChangeState ("InventoryMode");

			}

			} else if (_GameState == "InventoryMode") {
				if (Input.GetButtonDown ("Inventory")) {
					ChangeState ("PlayMode");


		
				}
			}  else if (_GameState == "PauseMode") {
				if (Input.GetKeyDown (KeyCode.Escape)) {
					_GameState = "PlayMode";
				}
			}
		}
}







	