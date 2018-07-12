using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May need to inherit from script or something to render items updates on UI
public class Inventory {

	public List<InteractableObject> items = new List<InteractableObject>();

	public void AddItem(InteractableObject item) {
		if (item.canPickUp) {
			items.Add(item);
		} else {
			// Throw exception
		}
	}

	public bool HasItem(InteractableObject item) {

		// Potential TODO: override == in InteractableObject
		foreach (InteractableObject invItem in items) {
			if (invItem.type == item.type) {
				return true;
			}
		}

		return false;
	}

	// TODO rework
	public bool RemoveItem(InteractableObject item) {
		return items.Remove(item);
	}
}
