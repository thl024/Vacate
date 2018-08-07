using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    #region data
    // Object Type
    public ObjectType type;

	// Object Description
	public string description;

	// Pickupable or not
	public bool canPickUp;

    // Default object sprite
    public Sprite objSprite;

    // No functionalities for now...
    #endregion


    #region getters
    ObjectType GetObjectType() { return type; }
    string GetDescription() { return description; }
    public Sprite GetObjSprite() { return objSprite;  }
    #endregion


    #region functionality

    private void Awake()
    {

        // Register gameobject to item database
        ObjectDB.Instance.RegisterItem(this.type, gameObject);

        // Set object sprite equal to the sprite renderer's
        objSprite = GetComponent<SpriteRenderer>().sprite;
        
    }

    private void onDestroy() {

        // Unregister gameobject from item database
        ObjectDB.Instance.UnregisterItem(this.type);

    }

    #endregion

}

public enum ObjectType { 
    NightstandKey,
    Matches,
    TrunkKey, 
    Compass, 
    TeddyBear, 
    USB, 
    Scissors, 
    KeyCard, 
    Screwdriver,
    ComputerPeripherals,
    Bed,
    Vent,
    DeskDrawer,
    Computer,
    DeskDrawer1,
    DeskDrawer2,
    DeskDrawer3,
    Trunk,
    ExitDoor,
    Nightstand,
    Plant,
    Candle
};