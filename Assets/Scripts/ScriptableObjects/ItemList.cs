using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Inventory/ItemList", order = 2)]
public class ItemList : ScriptableObject {

	public string itemListName;
	public List<Item> itemList = new List<Item>();
	public List<string> itemstring = new List<string>();
	public string[] itemarray;


	public string[] SaveItemList(){

		foreach (Item item in itemList) {
			itemstring.Add (item.itemName);
			
		}
		itemarray = itemstring.ToArray();
		return itemarray;

	
	}

}

