using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InteractableObject {
	// Object Type
    public ObjectType type;

	// Object Name
	public string name;

	// Linked gameobject
	public GameObject gameObject;

	// Object Description
	public string description;

	// Pickupable or not
	public bool canPickUp;

    // How many am I holding?
    public int count;
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