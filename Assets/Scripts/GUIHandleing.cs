using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIHandleing : MonoBehaviour {
	public GameObject Inventory;
	public Player _Player;
	public GameState _GameState;
	public GameObject InfoPanel;
	public GameObject ItemPanel;
	private UnityAction VariableChanged;
	public Text Name;
	public Text DynamicNameText;
	public Text Stats;
	public bool InventoryOn;
	public Sprite nullSprite;

	public List<GameObject> ItemSlots = new List<GameObject>();
	public List<Image> ItemImage = new List<Image>();
	public List<Text> ItemText = new List<Text>();
	public List<Button> DisplayButton = new List<Button>();
	

	void Awake(){

		VariableChanged = new UnityAction (RefreshText); 
	}

	void OnEnable (){
		EventManager.StartListening ("VariableChanged", VariableChanged);




	}
	void OnDisable(){
		EventManager.StopListening ("VariableChanged", VariableChanged);
	
	}

	// Use this for initialization
	void Start () {
		InventoryOn = false;
		foreach (Transform child in ItemPanel.transform) {
			ItemSlots.Add (child.gameObject);
			ItemImage.Add (child.gameObject.GetComponentInChildren<Image> ());
			ItemText.Add (child.gameObject.GetComponentInChildren<Text> ());
			DisplayButton.Add (child.gameObject.GetComponentInChildren<Button> ());

			
		}
		foreach (Text text in ItemText) {
			text.text = " Null ";
			
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
		DynamicNameText.text = _Player.Inventory.itemList [buttonindex].itemName;
	}
	
	// Update is called once per frame
	void Update () {
		if (_GameState.gameState == 1) {
			if (Input.GetKeyDown (KeyCode.I) && InventoryOn == false) {
				Inventory.SetActive (true);
				InventoryOn = true;
				_GameState.gameState = 2;
				
			
			}

		} else if (_GameState.gameState == 2) {

			if (Input.GetKeyDown (KeyCode.I) && InventoryOn == true) {
				Inventory.SetActive (false);
				InventoryOn = false;
				_GameState.gameState = 1;
			}
		}
	}

	public void RefreshText() {
		Name.text = _Player.Name;
		Stats.text = "Strength = " + _Player.Strength + "\n" + "Dexterity = " + _Player.Dexterity + "\n" + "Constitution = " +
		_Player.Constitution + "\n" + "Intellegence = " + _Player.Intellegence + "\n" + "Wisdom = " + _Player.Wisdom + "\n" + "Charisma = " + _Player.Charisma;
		int count = 0;
		foreach (Item item in _Player.Inventory.itemList) {
			ItemText [count].text = item.itemName;
			ItemImage [count].sprite = item.itemImage;
		}


		
		


	}
}
