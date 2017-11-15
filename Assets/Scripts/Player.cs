﻿using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Player : MonoBehaviour {

	void Start(){
		ClearInventory ();

	}

	public ItemList Inventory;

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

//	else if (activeResponceList [count].RequirementType == "Dexterity") {
//		if (_Player.Dexterity > activeResponceList [count].RequirementChallange) {
//			button.gameObject.SetActive (true);
//			count += 1;

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

}