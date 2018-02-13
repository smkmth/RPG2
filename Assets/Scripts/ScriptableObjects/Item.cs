using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A scriptable object representing an item.
/// string itemName - the name of the item
/// string itemDescription - a description of what the item does
/// sprite itemImage - what appears in the inventory under this item.
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item : ScriptableObject {

	public string itemName;
	public string itemDescription;
	public Sprite itemImage;
	public string itemType;
	public string equipableType;

	public List<ItemAttribute> attributes;

}
