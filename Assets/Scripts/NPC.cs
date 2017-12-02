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
		_Dialogue.PlayNextResponce (StartTopic);
	
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
	private int physical;
	public int Physical{
		get {
			return physical;
		}
		set {
			physical = value;
			if (physical != null) {
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
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
				EventManager.TriggerEvent ("NPCVariableChanged");
				Debug.Log ("Charisma changed to " + value);

			}
		}
	}

}
