using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InteractableObject {
	// Unique object ID
	public int ID;

	// Object Name
	public string name;

	// Object Type
	public ObjectType type;

	// Linked gameobject
	public GameObject gameObject;

	// Object Description
	public string description;

	// Pickupable or not
	public bool canPickUp;
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