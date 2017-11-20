using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour {
	public Player _Player;
	public GameState _GameState;
	public GameObject InfoPanel;
	public GameObject ItemPanel;
	private UnityAction VariableChanged;
	public Text Name;
	public Text DynamicNameText;
	public Text Stats;
	public Sprite nullSprite;
	public Item displayItem;

	public List<GameObject> ItemSlots = new List<GameObject>();
	public List<Image> ItemImage = new List<Image>();
	public List<Text> ItemText = new List<Text>();
	public List<Button> DisplayButton = new List<Button>();
	

	void Awake(){

		VariableChanged = new UnityAction (RefreshText); 
	}

	void OnEnable (){
		EventManager.StartListening ("VariableChanged", VariableChanged);
		Debug.Log ("Started Listening ");




	}
	void OnDisable(){
		EventManager.StopListening ("VariableChanged", VariableChanged);
		Debug.Log ("stropped listening ");
	
	}

	// Use this for initialization
	void Start () {
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		foreach (Transform child in ItemPanel.transform) {
			ItemSlots.Add (child.gameObject);
			ItemImage.Add (child.gameObject.GetComponentInChildren<Image> ());
			ItemText.Add (child.gameObject.GetComponentInChildren<Text> ());
			DisplayButton.Add (child.gameObject.GetComponentInChildren<Button> ());

			
		}
		foreach (Text text in ItemText) {
			text.text = "  ";
			
		}
		foreach (Image image in ItemImage) {
			image.sprite = nullSprite;
		}
		foreach (Button button in DisplayButton) {
			button.onClick.AddListener (delegate {
				DisplayItem(DisplayButton.IndexOf(button));
				
			});
		}


	}
	public void DisplayItem(int buttonindex){
		Debug.Log (_Player.Inventory.itemList [buttonindex]);
		displayItem = _Player.Inventory.itemList [buttonindex];

		DynamicNameText.text = _Player.Inventory.itemList [buttonindex].itemName;
	}
	


	public void RefreshText(){
		Debug.Log("trying to refresh text");
		Debug.Log (Name.text);
		Debug.Log (_Player.Name);
		Debug.Log ("Race name  " + _Player.PlayerRace);
		Name.text = _Player.Name + "\n"; 
		if (_Player.PlayerRace != null) {
			Name.text +=	_Player.PlayerRace.RaceName;
		}

		Stats.text = "Strength = " + _Player.Strength + "\n" + "Dexterity = " + _Player.Dexterity + "\n" + "Constitution = " +
		_Player.Constitution + "\n" + "Intellegence = " + _Player.Intellegence + "\n" + "Wisdom = " + _Player.Wisdom + "\n" + "Charisma = " + _Player.Charisma;
		int count = 0;
		foreach (Item item in _Player.Inventory.itemList) {
			ItemText [count].text = item.itemName;
			ItemImage [count].sprite = item.itemImage;
		}

	}
}
