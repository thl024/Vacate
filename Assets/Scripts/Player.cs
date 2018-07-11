using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Inventory inventory;
	public InventoryObject itemHeld;

	// Use this for initialization
	void Start () {
		inventory = new Inventory();
		itemHeld = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}