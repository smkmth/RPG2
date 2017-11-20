using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// Variables:
/// string Name;
/// string Gender;
/// int Health;
/// int Strength;
/// int Dexterity;
/// int Constitution;
/// int Wisdom;
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

	void Start(){
//		ClearInventory ();
//		ClearStats ();
//		PlayerRace = NullRace;


	}
	public void ClearStats(){
		Strength = 0;
		Dexterity = 0;
		Constitution = 0;
		Intellegence = 0;
		Wisdom = 0;
		Charisma = 0;
		PlayerRace = NullRace;
	}

	public List<GameObject> Party = new List<GameObject> ();

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
	private int strength;
	public int Strength{
		get {
			return strength;
		}
		set {
			strength = value;
			if (strength != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("strength changed to " + value);

			}
		}
	}

	[SerializeField]
	private int dexterity;
	public int Dexterity{
		get {
			return dexterity;
		}
		set {
			dexterity = value;
			if (dexterity != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("dexterity changed to " + value);

			}
		}
	}

	[SerializeField]
	private int constitution;
	public int Constitution {
		get {
			return constitution;
		}
		set {
			constitution = value;
			if (constitution != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("constitution changed to " + value);

			}
		}
	}

	[SerializeField]
	private int intellegence;
	public int Intellegence {
		get {
			return intellegence;
		}
		set {
			intellegence = value;
			if (Intellegence != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("intellegence changed to " + value);

			}
		}
	}

	[SerializeField]
	private int wisdom;
	public int Wisdom {
		get {
			return wisdom;
		}
		set {
			wisdom = value;
			if (wisdom != null) {
				EventManager.TriggerEvent ("VariableChanged");
				Debug.Log ("Wisdom changed to " + value);
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
		if (challangeType == "Strength") {
			if (Strength > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Dexterity") {
			if (Dexterity > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Constitution") {
			if (Constitution > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Intellegence") {
			if (Intellegence > challange) {
				return true;
			} else {
				return false;
			}
		} else if (challangeType == "Wisdom") {
			if (Wisdom > challange) {
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
		Name = loadedPlayer.stringstats [0];
		Gender = loadedPlayer.stringstats [1];

		Health = loadedPlayer.intstats [0];
		Strength = loadedPlayer.intstats [1];
		Dexterity = loadedPlayer.intstats [2];
		Constitution = loadedPlayer.intstats [3];
		Intellegence = loadedPlayer.intstats [4];
		Wisdom = loadedPlayer.intstats [5];
		Charisma = loadedPlayer.intstats [6];
		Vector3 vectortemp = new Vector3(loadedPlayer.playerx, loadedPlayer.playery, loadedPlayer.playerz);
		transform.position = vectortemp;

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