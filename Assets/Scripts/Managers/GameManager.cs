using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Singleton; keep a single global instance of the Game Manager
	public static GameManager instance = null;

	// Event Manager 
	public EventManager eventManager;

	// Buttons & cam view changing mechanics
    public CameraMovement mainCameraMover;

	public Button rightButton;
    public Button leftButton;
    public Button backButton;

    int startingIndex = 1;

    public Transform[] roomsList = new Transform[4];

    int roomIndex = 0;

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

		// Get camera script to change cam when necessary
        // mainCameraMover = GameObject.Find("Main Camera").GetComponent<CameraMovement>();

		roomIndex = startingIndex;
        mainCameraMover.MoveCam(roomsList[roomIndex]);
        backButton.gameObject.SetActive(false);

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

                // Check if object is a zoomable space
				ZoomSpace space = gameObject.GetComponent(typeof(ZoomSpace)) as ZoomSpace;
				if (space != null) {

					Debug.Log("Zoom space clicked");

					// Move main camera to the space

					HelperFunctions.printTransform(space.camTarget.transform);
					mainCameraMover.MoveCam(space.camTarget.transform);

					//adjust UI
					UIManager uiManager = GameObject.Find("UI").GetComponent<UIManager>();
					uiManager.DeactivateButtons();

					return;
				}

                // Use EventManager to perform an event
                eventManager.PerformEvent(hit.collider.gameObject);

            } else {
                Debug.Log("Empty click");
            }

        } else if (Input.GetKeyDown(KeyCode.S)) {

        	// Perform equip/unequip action with screwdriver
        	eventManager.PerformEquip(ObjectType.Screwdriver);

        }
	}

	public void RightButton()
    {
        roomIndex += 1;
        roomIndex = roomIndex % 4;
        mainCameraMover.MoveCam(roomsList[roomIndex]); 
    }

    public void LeftButton()
    {
        
        if(roomIndex == 0)
        {
            roomIndex = 4;
        }
        roomIndex -= 1;
        roomIndex = roomIndex % 4;
        mainCameraMover.MoveCam(roomsList[roomIndex]); 
    }

    public void BackButton()
    {
        mainCameraMover.MoveCam(roomsList[roomIndex]);
        //Debug.Log(roomsList[currentIndex]);
        SetButtonsActive();
    }

    public void SetButtonsActive() //reactivates movement buttons; deactivates zoomin Back button
    {
        rightButton.gameObject.SetActive(true);
        leftButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(false);
    }

    public void DeactivateButtons() //deactivates movement buttons; acatvates zoominBack button
    {
        rightButton.gameObject.SetActive(false);
        leftButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(true);
    }
}
