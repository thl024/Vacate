using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Singleton; keep a single global instance of the Game Manager
	public static GameManager instance = null;

	// Event Manager 
	public EventManager eventManager;

	// Use this for initialization
	void Awake () {

		// Singleton instantiation
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		// Initialization of event manager
		eventManager = new EventManager();

	}
	
	
	void Update () {

		// Check for mouse click
        if (Input.GetMouseButtonDown(0)) {
            
            Debug.Log("Mouse clicked");

            // Obtain mouse position in 3d and convert to 2d coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            // Generate a raycast from the current mouse position
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // Check if raycast is targeted towards another game object
            if (hit.collider != null) {

                Debug.Log(hit.collider.gameObject.name + " clicked");

                // Use EventManager to perform an event
                eventManager.PerformEvent(hit.collider.gameObject);

            } else {
                Debug.Log("Empty click");
            }

        }
	}
}
