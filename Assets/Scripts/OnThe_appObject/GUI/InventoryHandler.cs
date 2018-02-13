using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Class which takes care of the inventory GUI.
/// 
/// </summary>
public class InventoryHandler : MonoBehaviour {
	public Player _Player;							//reference to player class 
	public GameState _GameState;					//refenence to gamestate class
	public GameObject InfoPanel;					//a panel which gives the player personal infomation 
	public GameObject ItemPanel;					//a panel with all the displayed items in the inventory
	private UnityAction VariableChanged;			//A unity action which triggers on the player class when a variable is changed
	public Text Name;								//a text which shows the players name
	public Text DynamicNameText;					//A text which will show the selected item name 
	public Text Stats;								//a text which shows the players stats
	public Sprite nullSprite;						//The null sprite which displays when no items are present
	public Item displayItem;						//the item which has been selected
	public List<GameObject> ItemSlots = new List<GameObject>();		//an empty list waiting to be filled with the itemslots
	public List<Image> ItemImage = new List<Image>();				//an empty list waiting to be filled with item images
	public List<Text> ItemText = new List<Text>();					//an empty list waiting to be fileld with item texts
	public List<Button> DisplayButton = new List<Button>();			//an empty list waiting to be filled with display buttons.
	public GameObject SelectedItemButtons;
	public GlobalItemHandler _GlobalItemHandler;
	public Button UseButton;
	public Button EquipButton;
	public Button DropButton;

	public GameObject HeadSlot;
	public Text HeadText;
	public Image HeadImage;
	public GameObject WeaponSlot;
	public Text WeaponText;
	public Image WeaponImage;
	public GameObject BodySlot;
	public Text BodyText;
	public Image BodyImage;
	public GameObject FeetSlot;
	public Text FeetText;
	public Image FeetImage;
	/// <summary>
	/// On awake, this sets the unity action variablechanged
	/// to a new unity action, with the method refreshtext as the 
	/// method to trigger, so when the player changes somthing about
	/// themeselves, this class is alerted and refeshes the inv text.
	/// </summary>
	void Awake(){

		VariableChanged = new UnityAction (RefreshText); 
	}

	/// <summary>
	/// Here we start listening for the varirable changed event.
	/// </summary>
	void OnEnable (){
		EventManager.StartListening ("VariableChanged", VariableChanged);
		Debug.Log ("Started Listening to variable changed");
	}

	/// <summary>
	/// for some reason you always need to tell unity to stop listing to 
	/// events, so this method triggers when the game is quit, to unhook
	/// the listener.
	/// </summary>
	void OnDisable(){
		EventManager.StopListening ("VariableChanged", VariableChanged);
		Debug.Log ("stropped listening to variable changed ");
	
	}
	/// <summary>
	/// Attach the player reference using the player tag.
	///  
	/// then we are pulling the transforms of the childs of item panel 
	/// (which are item slots) and adding them to the lists earlier, 
	/// so the ItemSlots list just adds each childs gameobject,
	/// the itemimage does the component in childs text, and so on.
	/// 
	/// when i first needed to use this function a while back i thought
	/// it didnt work becuase it never had previously occured to me to set
	/// a list as the place the items go= - so stupid :/
	/// 
	/// we then set the text components to blank, the sprites to null. 
	/// 
	/// lastly the button we give a listener on click, to return the index of 
	/// button to the display item method. so when the user clicks a button,
	/// the button actually just tells this script what button index they pressed.
	/// since the itemslots are populated with the same list as the buttons, 
	/// this should all just line up.
	/// 
	/// feel like their should be a simpler way of doing this , couldnt think
	/// of anything at the time. :l
	/// </summary>
	void Start () {
		
		SelectedItemButtons.SetActive (false);
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		HeadText = HeadSlot.GetComponentInChildren<Text> ();
		HeadImage = HeadSlot.GetComponentInChildren<Image> ();
		BodyText = BodySlot.GetComponentInChildren<Text> ();
		BodyImage = BodySlot.GetComponentInChildren<Image> ();
		WeaponText = WeaponSlot.GetComponentInChildren<Text> ();
		WeaponImage = WeaponSlot.GetComponentInChildren<Image> ();
		FeetText = FeetSlot.GetComponentInChildren<Text> ();
		FeetImage = FeetSlot.GetComponentInChildren<Image> ();
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

	/// <summary>
	/// This method takes a buttonindex and uses that to display an item in the invetory. 
	/// it also sets the dyanamicnametext, and sets displayItem to the relevent item.
	/// </summary>
	/// <param name="buttonindex">Buttonindex.</param>
	public void DisplayItem(int buttonindex){
		if (_Player.Inventory.itemList [buttonindex] != null) {
			Debug.Log (_Player.Inventory.itemList [buttonindex]);
			displayItem = _Player.Inventory.itemList [buttonindex];

			DynamicNameText.text = _Player.Inventory.itemList [buttonindex].itemName;
			SelectedItemButtons.SetActive (true);
		}

	}

	public void UseItemButton(){
		_GlobalItemHandler.AimItem (displayItem.itemName, _Player.gameObject);
		

	}
	public void EquipItemButton(){
		if (displayItem.equipableType != "") {
			if (displayItem.equipableType == "Head") {
				if (_Player.EquipedHeadItem != null ) {
					_Player.EquipedHeadItem = null;
					Debug.Log ("unequip " + displayItem.itemName + " to Head");
					RefreshText ();

				} else {
					
					_Player.EquipedHeadItem = displayItem;
					Debug.Log ("equip " + displayItem.itemName + " to Head");
				}

			} else if (displayItem.equipableType == "Weapon") {
				if (_Player.EquipedWeapon != null ) {
					_Player.EquipedWeapon = null;
					Debug.Log ("unequip " + displayItem.itemName + " to Weapon");
					RefreshText ();

				} else {

					_Player.EquipedWeapon = displayItem;
					Debug.Log ("equip " + displayItem.itemName + " to Weapon");
				}

			} else if (displayItem.equipableType == "Body") {
				if (_Player.EquipedBody != null ) {
					_Player.EquipedBody = null;
					Debug.Log ("unequip " + displayItem.itemName + " to Bodt");
					RefreshText ();

				} else {

					_Player.EquipedBody  = displayItem;
					Debug.Log ("equip " + displayItem.itemName + " to Body");
				}
			} else if (displayItem.equipableType == "Feet") {
				if (_Player.EquipedFeet != null ) {
					_Player.EquipedFeet = null;
					Debug.Log ("unequip " + displayItem.itemName + " to feet");
					RefreshText ();

				} else {

					_Player.EquipedFeet = displayItem;
					Debug.Log ("equip " + displayItem.itemName + " to feet");
				}
			}
		} else {
			Debug.Log ("Item " + displayItem.itemName + " cannont be equiped");
		}
	}
	

	/// <summary>
	/// Refreshs the text. Can be a little 'iffy' - things falling of it and such 
	/// not, i usually just run if checks to make sure everything will run if the 
	/// refershtext() is trying to display a null obejct. 
	/// 
	/// Make sure to add any changes to this part of the inventory else it wont
	/// end up being displayed.	
	/// </summary>
	public void RefreshText(){
		
		Name.text = _Player.Name + "\n"; 
		if (_Player.PlayerRace != null) {
			Name.text += _Player.PlayerRace.RaceName;
		}

		Stats.text = "Combat = " + _Player.Combat + "\n" + "Engineering = " + _Player.Engineering + "\n" + "Science = " +
		_Player.Science + "\n" + "Physical = " + _Player.Physical + "\n" + "Subtle = " + _Player.Subtle + "\n" + "Charisma = " + _Player.Charisma;
		int count = 0;
		foreach (Item item in _Player.Inventory.itemList) {
			if (count > _Player.Inventory.itemList.Count) {
				break;
			}
				
			ItemText [count].text = item.itemName;
			ItemImage [count].sprite = item.itemImage;
			count += 1;
		}
		if (_Player.EquipedHeadItem != null) {
			HeadText.text = _Player.EquipedHeadItem.itemName;
			HeadImage.sprite = _Player.EquipedHeadItem.itemImage;
		} else {
			HeadText.text = "Head";
			HeadImage.sprite = nullSprite;
		}
		if (_Player.EquipedBody != null) {
			BodyText.text = _Player.EquipedBody.itemName;
			BodyImage.sprite = _Player.EquipedBody.itemImage;
		}
		if (_Player.EquipedWeapon != null) {
			WeaponText.text = _Player.EquipedWeapon.itemName;
			WeaponImage.sprite = _Player.EquipedWeapon.itemImage;
		}
		if (_Player.EquipedFeet != null) {
			FeetText.text = _Player.EquipedFeet.itemName;
			FeetImage.sprite = _Player.EquipedFeet.itemImage;
		}
	}
}
