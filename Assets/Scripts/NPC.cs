using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	public GameObject InteractionCube;
	public Topic StartTopic;
	public DialogueHandler _Dialogue;
	public List<Topic> SpecialTopics = new List<Topic> ();
	public Player _Player;
	


	public void Start(){
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}



	public void TalkToThisNPC(){
		_Dialogue = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogueHandler> ();
		foreach (Topic specialtopic in SpecialTopics) {
			if (_Player.SpecialDialogueMarkers.Contains (specialtopic.DialogueName)) {
				StartTopic = specialtopic;
				Debug.Log("specaial topic " + specialtopic.DialogueName);
			}
		}
		_Dialogue.RunDialogueStart (gameObject);

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
