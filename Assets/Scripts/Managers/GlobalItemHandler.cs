using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalItemHandler : MonoBehaviour{

	public ItemList GlobalItemList;
	public List<string> GlobalItemString = new List<string>();
	private Item usingItem;
	public Item NullItem;
	public ItemList tempitemlist;


	void Start(){
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
		Item UsingItem = GlobalItemList [index];
		if (UsingItem.itemType == "Weapon") {
			if (UsingItem.attributes.Contains (WeaponAttribute)) {
				int weaponindex = UsingItem.attributes.IndexOf (WeaponAttribute);
				WeaponAttribute ItemWeapon = UsingItem.attributes [weaponindex];
				Aim (user);
			}
		}
		Debug.Log ("Trying to use a " + GlobalItemList.itemList [index].itemName);

	}

	public void Aim(GameObject aimer){
		

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
