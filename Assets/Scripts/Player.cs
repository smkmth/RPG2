using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Variables:
/// string Name;
/// string Gender;
/// int Health;
/// int Physical;
/// int Combat;
/// int Engineering;
/// int Subtle;
/// int Charisma;
/// ItemList Inventory;
/// Race PlayerRace;
/// Methods:
/// SkillRequireCheck() - which returns true if a 
/// player has the correct stat requirements, and false if not.
/// ClearInventory() - clears players inventory on start- becuase
/// any items picked up will stay in the inventory even after closeing 
/// game
/// AddInventoryItem(Item) - needs an 'item' - will add the item to 
/// the inventory
/// RemoveInventoryItem(Item) - Needs an 'item' - will remove the item
/// from the inventory.
/// </summary>
public class Player : MonoBehaviour {
	///This class is the dynamic player class, which gets changed as the game is playing
	/// While it might look complicated its really not. most of these stats are wrapped in 
	/// getter setter methods, which keep all the variables private, but still let other scripts
	/// access them. As a bonus, i can also be alerted when a variable is changed via my 
	/// unity event which activates when the setter is called. The Serialize Field part of 
	/// it just forces a private variable to be exposed in the unity inspector, so we can 
	/// see the private variables playout in game by watching the player object. 
	public List<Race> RaceList = new List<Race>();
	public LevelHandler _LevelHandler;

	void Start(){
		ClearInventory ();
		ClearStats ();


	}
	public string CurrentLevel() {
		Scene scene = SceneManager.GetActiveScene();
		return scene.name;
	}
	public string CurrentLevelData() {
		return _LevelHandler._buildingScene.LevelName;
	}

	public void ClearStats(){
		Physical = 0;
		Combat = 0;
		Engineering = 0;
		Science = 0;
		Charisma = 0;
		Subtle = 0;
		PlayerRace = NullRace;
	}

	public List<GameObject> Party = new List<GameObject> ();
	public List<string> SpecialDialogueMarkers = new List<string> ();

	public ItemList Inventory;
	private Race playerRace;
	public Race PlayerRace {
		get {
			return playerRace;
		}
		set {
			playerRace = value;
			Debug.Log ("Player race is " + PlayerRace);
			EventManager.TriggerEvent("VariableChanged");


		}

	}
	public Race NullRace;

	public void AddInventoryItem(Item item){
		Inventory.itemList.Add (item);
		EventManager.TriggerEvent("VariableChanged");
	}
	public void RemoveInvetoryItem(Item item){
		Inventory.itemList.Remove (item);
		EventManager.TriggerEvent("VariableChanged");

	}
	public void ClearInventory(){
		Inventory.itemList.Clear ();
	}

	

	[SerializeField]
	private string name;
	public string Name{
		get {
			return name;
		}
		set {
			name = value;
			if (name != null) {
				EventManager.TriggerEvent ("VariableChanged");
			}
		}
	}

	[SerializeField]
	private string gender;
	public string Gender {
		get {
			return gender;
		}
		set {
			gender = value;
			if (gender != null) {
				EventManager.TriggerEvent ("VariableChanged");
			}
		}
	}


	[SerializeField]
	private int health;
	public int Health{
		get {
			return health;
		}
		set {
			health = value;
			if (health != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("health changed to " + value);
			}
		}
	}

	[SerializeField]
	private int physical;
	public int Physical{
		get {
			return physical;
		}
		set {
			physical = value;
			if (physical != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("physical changed to " + value);

			}
		}
	}

	[SerializeField]
	private int combat;
	public int Combat{
		get {
			return combat;
		}
		set {
			combat = value;
			if (combat != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("combat changed to " + value);

			}
		}
	}

	[SerializeField]
	private int engineering;
	public int Engineering {
		get {
			return engineering;
		}
		set {
			engineering = value;
			if (engineering != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("engineering changed to " + value);

			}
		}
	}

	[SerializeField]
	private int science;
	public int Science {
		get {
			return science;
		}
		set {
			science = value;
			if (Science != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("science changed to " + value);

			}
		}
	}

	[SerializeField]
	private int subtle;
	public int Subtle {
		get {
			return subtle;
		}
		set {
			subtle = value;
			if (subtle != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("Subtle changed to " + value);
			}
		}
	}

	[SerializeField]
	private int charisma;
	public int Charisma {
		get {
			return charisma;
		}
		set {
			charisma = value;
			if (charisma != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("Charisma changed to " + value);

			}
		}
	}


	public bool SkillRequireCheck(string challangeType, int challange){
		if (challangeType == "Physical") {
			if (Physical > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Combat") {
			if (Combat > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Engineering") {
			if (Engineering > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Science") {
			if (Science > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Subtle") {
			if (Subtle > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Charisma") {
			if (Charisma > challange) {
				return true;	
			} else {
				return false;
			}
		} else {
			return false;
		}
	}




	public void Save(){
		SaveLoadHandler.SavePlayer (this);

		Debug.Log ("Character Saved!");


	}
	public void Load(){
		PlayerData loadedPlayer = SaveLoadHandler.LoadPlayer ();
		_LevelHandler.LoadLevel (loadedPlayer.currentlevel, loadedPlayer.currentleveldata);
		Name = loadedPlayer.stringstats [0];
		Gender = loadedPlayer.stringstats [1];

		Health = loadedPlayer.intstats [0];
		Physical = loadedPlayer.intstats [1];
		Combat = loadedPlayer.intstats [2];
		Engineering = loadedPlayer.intstats [3];
		Science = loadedPlayer.intstats [4];
		Subtle = loadedPlayer.intstats [5];
		Charisma = loadedPlayer.intstats [6];
		Vector3 vectortemp = new Vector3(loadedPlayer.playerx, loadedPlayer.playery, loadedPlayer.playerz);
		transform.position = vectortemp;
		SpecialDialogueMarkers.AddRange (loadedPlayer.stringmarkers);
		

		foreach (Race race in RaceList) {
			if (loadedPlayer.race == race.RaceName) {
				PlayerRace = race;
				break;
			}
		}
		Debug.Log ("Character Loaded!");

		//Inventory = loadedPlayer.inventory;
	}
}