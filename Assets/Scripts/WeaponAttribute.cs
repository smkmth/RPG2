using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemAttribute", menuName = "Inventory/DamageAttribute", order = 1)]
public class WeaponAttribute : ItemAttribute {
	public float Damage;
	public string Name;
}