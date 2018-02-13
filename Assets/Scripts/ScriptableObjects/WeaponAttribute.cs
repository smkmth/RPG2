using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAttribute", menuName = "Inventory/DamageAttribute", order = 1)]
public class WeaponAttribute : ItemAttribute {
	public int Damage;
	public string Name;
}