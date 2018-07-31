using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Data
    CameraMovement mainCam;

    public Button rightButton;
    public Button leftButton;
    public Button backButton;

    [SerializeField]
    int startingIndex = 1;

    public Transform[] roomsList = new Transform[4];

    int currentIndex = 0;

    

    #endregion

    #region functionality
    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        currentIndex = startingIndex;
        mainCam.MoveCam(roomsList[currentIndex]);
        backButton.gameObject.SetActive(false);
    }

        #region movementButtons

    public void RightButton()
    {
        currentIndex += 1;
        currentIndex = currentIndex % 4;
        mainCam.MoveCam(roomsList[currentIndex]);
        Debug.Log(currentIndex);
        Debug.Log(roomsList[currentIndex]);
    }

    public void LeftButton()
    {
        
        if(currentIndex == 0)
        {
            currentIndex = 4;
        }
        currentIndex -= 1;
        currentIndex = currentIndex % 4;
        mainCam.MoveCam(roomsList[currentIndex]);
        
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

    public void BackButton()
    {
        mainCam.MoveCam(roomsList[currentIndex]);
        //Debug.Log(roomsList[currentIndex]);
        SetButtonsActive();
    }
    #endregion

        #region Inventory UI
    //nothing yet lol
    #endregion 
    #endregion
}
