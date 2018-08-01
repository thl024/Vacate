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

    Sprite objSprite;

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
        //get sprite renderer
        objSprite = GetComponent<SpriteRenderer>().sprite;
        
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