using System;
using UnityEngine;
/// <summary>
/// this class goes on the item in the actual world, and makes it disapear in the world 
/// and appear in the inventory, while also adding its game object name to a picked up 
/// item list. 
/// 
/// </summary>
public class ItemHandler : MonoBehaviour{

	public Item item;
	public Player _Player;
	public string ItemDescription;

	void Start(){
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}

	public void PickUpItem(){
		_Player.AddInventoryItem (item);
		_Player.PickedUpItems.Add (gameObject.name);
		Destroy (gameObject);


	}






}
