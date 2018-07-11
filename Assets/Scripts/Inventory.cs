using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	public List<InventoryObject> items = new List<InventoryObject>();

	public void AddItem(InventoryObject item) {
		items.Add(item);
	}

	public bool HasItem(InventoryObject item) {
		return items.Contains(item);
	}

	public bool RemoveItem(InventoryObject item) {
		return items.Remove(item);
	}
}
