using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class GlobalItemHandler : MonoBehaviour{

	public ItemList GlobalItemList;
	public List<string> GlobalItemString = new List<string>();
	private Item usingItem;
	public Item NullItem;
	public ItemList tempitemlist;
	public GameState _GameState;


	void Start(){
		_GameState = GetComponents<GameState> ();
		foreach (Item item in GlobalItemList.itemList) {

			if (item.itemName != null || item.itemName != " ") {
				GlobalItemString.Add (item.itemName);
			} else {
				Debug.LogError ("Assign a name to " + item.name);
			}
		}
	}


	public void UseItem(string itemName, GameObject user){
		int index = GlobalItemString.IndexOf (itemName);
		usingItem = GlobalItemList.itemList [index];

		for (int i = 0; i < usingItem.attributes.Count; i ++){
			Debug.Log (usingItem.attributes [i].GetType().ToString ());
			if (usingItem.attributes [i].GetType() == typeof(WeaponAttribute)){
				Debug.Log (usingItem.attributes [i].GetType().ToString ());
				WeaponAttribute weaponattribute = usingItem.attributes [i] as WeaponAttribute;
				_GameState._GameState = "AimMode";

				Debug.Log("Weapon Attribute name = " + weaponattribute.Name + " WeaponAttribute Damage = " + weaponattribute.Damage);

			}
		}





		Debug.Log ("Trying to use a " + usingItem.itemName);

	}

		



	public Item[] LoadItems (string[] itemarray){
		foreach (string itemstring in itemarray) {
			int index = GlobalItemString.IndexOf (itemstring);

			tempitemlist.itemList.Add (GlobalItemList.itemList [index]);
		}
		return tempitemlist.itemList.ToArray();
	}

	public Item ConvertStringToItem(string itemname){
		int storedindex = 0;
		foreach (string itemstring in GlobalItemString) {
			if (itemstring == itemname) {
				storedindex = GlobalItemString.IndexOf (itemstring);
			}

		}
		return  GlobalItemList.itemList [storedindex];

	}



}
