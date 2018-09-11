using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May need to inherit from script or something to render items updates on UI
public class Inventory : MonoBehaviour {

	// Could be combined later maybe
	public List<InteractableObject> items = new List<InteractableObject>();
	public UIInvItem[] UIInventory;

	private void Start()
    {
        foreach (UIInvItem j in UIInventory)
        {
            j.gameObject.SetActive(false);
        }

    }

	public void AddItem(InteractableObject item) {
		// Logic
		items.Add(item);

		// UI stuff
		int invIndex = FindEmptyInvIndex();
        //Debug.Log("add item index: " + invIndex);

        UIInventory[invIndex].SetImage(item.objSprite);
        UIInventory[invIndex].gameObject.SetActive(true);
        UIInventory[invIndex].IsEmpty = false;
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

	public bool HasItem(ObjectType type) {

		// Potential TODO: override == in InteractableObject
		foreach (InteractableObject invItem in items) {
			if (invItem.type == type) {
				return true;
			}
		}

		return false;
	}

	public bool RemoveItem(InteractableObject item) {
		var ind = -1;

		for (var i = 0; i < items.Count; i++) {
			if (items[i].type == item.type) {
				ind = i;
				break;
			}
		}

		if (ind != -1) {
			items.RemoveAt(ind);

			// TODO Index may be different?
			// UIInventory[index].gameObject.SetActive(false);
			// UIInventory[index].IsEmpty = true;

			return true;
		}

		Debug.Log("ERROR: Item " + item.type + " not in inventory!");
		return false;
	}

	public bool RemoveItem(ObjectType type) {
		var ind = -1;

		for (var i = 0; i < items.Count; i++) {
			if (items[i].type == type) {
				ind = i;
				break;
			}
		}

		if (ind != -1) {
			items.RemoveAt(ind);

			// TODO Index may be different?
			// UIInventory[index].gameObject.SetActive(false);
			// UIInventory[index].IsEmpty = true;

			return true;
		}

		Debug.Log("ERROR: Item " + type + " not in inventory!");
		return false;
	}

	public InteractableObject GetItem(ObjectType type) {

		foreach (InteractableObject invItem in items) {

			if (invItem.type == type) {
				return invItem;
			}
			
		}

		Debug.Log("ERROR: Item " + type + " not in inventory!");

		return null;

	}

	int FindEmptyInvIndex()//finds next empty index
    {
        int invIndex = 0;
        foreach (UIInvItem item in UIInventory)
        {
            if (UIInventory[invIndex].IsEmpty)
            {
                break;
            }
            invIndex++;
        }

        Debug.Log(invIndex);
        return invIndex;
    }

    public UIInvItem GetItemAtIndex(int i)
    {
        Debug.Log("Inventory object" + UIInventory[i] + " at " + i);
        return UIInventory[i];
    }
}
