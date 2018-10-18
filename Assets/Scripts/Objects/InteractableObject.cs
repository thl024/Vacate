using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    #region data
    public ObjectType type;
	public string description;

	public bool canPickUp;

    // Default object sprite is 1st.
    public Sprite[] sprites; 

    // Determines whether gameobject is enabled or disabled at start
    public bool initiallyActive = true;

    // No functionalities for now...
    #endregion


    #region getters
    ObjectType GetObjectType() { return type; }
    string GetDescription() { return description; }
    public Sprite[] Getsprites() { return sprites;  }
    #endregion


    #region functionality

    private void Start() {

        // Register gameobject to item database
        ObjectDB.Instance.RegisterObject(this.type, gameObject);

        GameObject o = ObjectDB.Instance.GetObject(this.type);
        //Debug.Log(o);

        gameObject.SetActive(initiallyActive);

    }

    private void Awake()
    {

        // Set object sprite equal to the sprite renderer's
        sprites[0] = GetComponent<SpriteRenderer>().sprite;
        //initiallyActive = true;
        
    }

    private void OnDestroy() {

        // Unregister gameobject from item database
        ObjectDB.Instance.UnregisterObject(this.type);

    }

    public void ChangeSprite(int i) {

        // TODO make more specific for openable, burnable, etc.
        GetComponent<SpriteRenderer>().sprite = sprites[i];

    }

    public void ChangeSpriteOpacity(float op)
    {
        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a = op;
        GetComponent<SpriteRenderer>().color = temp;
    }

    public void Lift(Transform location)
    {
       //changes sprite & moves obj to location
    }

    public void PutitBack()
    {
        //puts it back?
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
    BedCovers,
    Pillow,
    Vent,
    TopDeskDrawer,
    BotDeskDrawer,
    DeskDrawer,
    Computer,
    TopDresserDrawer,
    MidDresserDrawer,
    BotDresserDrawer,
    Trunk,
    ExitDoor,
    NightstandDrawer,
    Plant,
    Candle
};