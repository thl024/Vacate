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

    // Determines whether gameobject is enabled or disabled at start
    public bool initiallyActive;

    // No functionalities for now...
    #endregion


    #region getters
    ObjectType GetObjectType() { return type; }
    string GetDescription() { return description; }
    public Sprite GetObjSprite() { return objSprite;  }
    #endregion


    #region functionality

    private void Start() {

        // Register gameobject to item database
        ObjectDB.Instance.RegisterObject(this.type, gameObject);

        GameObject o = ObjectDB.Instance.GetObject(this.type);
        Debug.Log(o);

        gameObject.SetActive(initiallyActive);

    }

    private void Awake()
    {

        // Set object sprite equal to the sprite renderer's
        objSprite = GetComponent<SpriteRenderer>().sprite;
        
    }

    private void OnDestroy() {

        // Unregister gameobject from item database
        ObjectDB.Instance.UnregisterObject(this.type);

    }

    public void ChangeSprite(Sprite sprite) {

        // TODO make more specific for openable, burnable, etc.
        GetComponent<SpriteRenderer>().sprite = sprite;

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