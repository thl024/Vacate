﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Currently does not need to inherit MonoBehavior but could be useful later
public class EventManager : MonoBehaviour {

    // Currently held item
    public GameObject itemHeld;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    // Determines the event upon gameobject selection
    public void PerformEvent(GameObject gameObject) {
        Debug.Log("Event Manager Logic");
        // TODO -- lots of logic goes here

        // User holding item or not?
        // Interacted object pickupable or not?
        // etc.
    }
}