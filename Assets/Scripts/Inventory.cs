using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	public List<ItemType> items = new List<ItemType>();

	public ItemType itemHeld;

	public void AddItem(ItemType itemType) {
		// TODO
	}

	public void hasItem(ItemType itemType) {
		// TODO
	}
}

public enum ItemType { 
	DrawerKey, 
	TrunkKey, 
	Compass, 
	TeddyBear, 
	USB, 
	Scissors, 
	KeyCard, 
	Screwdriver 
};
