﻿using System;
using UnityEngine;

public class SomeGuy : NPC {

	//this

	[SerializeField]
	private string name;
	public string Name{
		get {
			return name;
		}
		set {
			name = value;
			if (name != null) {
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
				Debug.Log ("Charisma changed to " + value);

			}
		}
	}






}