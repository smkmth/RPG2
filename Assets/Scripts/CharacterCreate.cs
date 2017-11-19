using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreate : MonoBehaviour {

	public InputField NameField;
	public Dropdown GenderDropdown;
	public Player _Player;
	public GameState _GameState;
	public Dropdown StrDropdown;
	public Dropdown DexDropdown;
	public Dropdown ConDropdown;
	public Dropdown IntDropdown;
	public Dropdown WisDropdown;
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

	public void GetStrength(){
		_Player.Strength = StrDropdown.value;
		Debug.Log (StrDropdown.value);
		Debug.Log (_Player.Strength);
	}
	public void GetDexterity(){
		_Player.Dexterity = DexDropdown.value;

	}
	public void GetConstitution(){
		_Player.Constitution = ConDropdown.value;
	}
	public void GetIntellegence(){
		_Player.Intellegence = IntDropdown.value;
	}
	public void GetWisdom(){
		_Player.Wisdom = WisDropdown.value;
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
