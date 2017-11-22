using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreateHandler : MonoBehaviour {

	public InputField NameField;
	public Dropdown GenderDropdown;
	public Player _Player;
	public GameState _GameState;
	public Dropdown ComDropdown;
	public Dropdown PhysDropdown;
	public Dropdown EngiDropdown;
	public Dropdown SciDropdown;
	public Dropdown SubtDropdown;
	public Dropdown ChaDropdown;
	public Dropdown RaceDropDdown;
	public List<Race> PlayableRaces = new List<Race> ();
	public List<string> PlayableRacesNames = new List<string>();



	public void GetName(){
		Debug.Log (NameField.text);
		_Player.Name = NameField.text;
	}

	public void GetGender(){
		Debug.Log (GenderDropdown.captionText.text);
		_Player.Gender = GenderDropdown.captionText.text;
	}

	public void GetRace(){
		_Player.PlayerRace = PlayableRaces [RaceDropDdown.value];
	}

	public void GetCombat(){
		_Player.Combat = ComDropdown.value;
		Debug.Log (ComDropdown.value);
		Debug.Log (_Player.Combat);
	}
	public void GetPhysical(){
		_Player.Physical = PhysDropdown.value;

	}
	public void GetEngineering(){
		_Player.Engineering = EngiDropdown.value;
	}
	public void GetScience(){
		
		_Player.Science = SciDropdown.value;
	}
	public void GetSubtle(){
		_Player.Subtle = SubtDropdown.value;
	}
	public void GetCharisma(){
		_Player.Charisma = ChaDropdown.value;
	
	}
		
	// Use this for initialization
	void Start () {
		
		foreach (Race race in PlayableRaces) {
			PlayableRacesNames.Add (race.RaceName);
		}
		RaceDropDdown.AddOptions (PlayableRacesNames);


		
		
		
	}
	

}
