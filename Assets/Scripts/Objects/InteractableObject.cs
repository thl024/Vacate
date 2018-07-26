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

    // No functionalities for now...
    #endregion


    #region getters
    ObjectType GetObjectType() { return type; }
    string GetDescription() { return description; }




    #endregion


    #region functionality

    

#endregion 

}

public enum ObjectType { 
    DrawerKey,
    TrunkKey, 
    Compass, 
    TeddyBear, 
    USB, 
    Scissors, 
    KeyCard, 
    Screwdriver,
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