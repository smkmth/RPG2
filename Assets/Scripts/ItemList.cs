using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Inventory/ItemList", order = 2)]
public class ItemList : ScriptableObject {

	public string itemListName;
	public List<Item> itemList = new List<Item>();


}

