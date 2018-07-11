using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Camera pos
	public Transform Target;

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

		// Ensures that the game manager does not get destroyed across scenes
		DontDestroyOnLoad(gameObject);

		// Initialization of event manager
		eventManager = new EventManager();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))
        {
            CamMovement(Target);
        }

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

	void CamMovement(Transform inTarget)
    {
        transform.position = inTarget.position;
    }
}
