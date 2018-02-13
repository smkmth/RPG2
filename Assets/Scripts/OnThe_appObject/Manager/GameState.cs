using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// GameState is a fancy way of handling what GUI elements are currently switched on, if the
/// player can move and if the game is running or paused.  
/// 
/// By storing this all in gamestate, i dont have to fiddle around with this kind of stuff on 
/// a case by case basis i can just set it broadly
/// 
/// It also handles the persistant 'GUI' controls, like the pause menu and the inventory menu
/// 
/// 
/// Game states are - as strings :
///
/// CharacterCreateMode - Where the character create window shows up - time is paused
/// PlayMode - where the character can move around and interact with the enviroment - time is not paused
/// PauseMode - where you can save and load, change options, quit or resume - time is paused
/// DialogueMode - where you are talking with another npc - atm time is not paused- will change later
/// InventoryMode - where you can equip weapons and that - time is paused
/// MainmMenu - the first screen of the game 
/// Elevatormode - puts up the elevator menu - time is paused
/// Aimmode- i think does nothing atm 
/// 
/// _GameState - a getsetter which returns what that game state is, and sets the game state
/// to whatever you want it to be. 
/// 
/// A whole bunch of GUI objects. Importantly, these are the 'display objects' which are not 
/// attached to any logic and can be turned on and off without changing anything which calls them.
/// 
/// For instance, i can turn off _Inventory without loosing any references to the inventoryhandler.
/// 
/// GetState()  stupidly named now i think of it, but get state enacts any changes which need to be made 
/// when a state is on or off. It just goes through a list of what should be on or off. 
/// 
/// one slightly anoying thing is that i have to update each state when a new gui object is added.
/// its slightly annoying, in the future i will find a more flexiable work around, but for now its fine.
/// 
/// ChangeState() a public method which changes the state. This is handled by my setter, this is just a 
/// legacy feature i need to erradicate. 
/// 
/// Update ()  a short stack of if else conditionals which handle when and when you cannot pause, and go into the 
/// inventory. 
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


		} else if (_GameState == "AimMode") {
			_ShipElevatorGUI.SetActive (false);		
			_CharacterSelect.SetActive (false);
			_Inventory.SetActive (false);
			_OnScreenGui.SetActive (true);
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







	