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

    int roomIndex = 0;

    int invIndex = 0;

    public UIInvItem[] UIInventory;

    #endregion

    #region functionality
    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        roomIndex = startingIndex;
        mainCam.MoveCam(roomsList[roomIndex]);
        backButton.gameObject.SetActive(false);

        foreach (UIInvItem j in UIInventory)
        {
            j.gameObject.SetActive(false);
        }

    }

 #region movementButtons

    public void RightButton()
    {
        roomIndex += 1;
        roomIndex = roomIndex % 4;
        mainCam.MoveCam(roomsList[roomIndex]); 
    }

    public void LeftButton()
    {
        
        if(roomIndex == 0)
        {
            roomIndex = 4;
        }
        roomIndex -= 1;
        roomIndex = roomIndex % 4;
        mainCam.MoveCam(roomsList[roomIndex]); 
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
        mainCam.MoveCam(roomsList[roomIndex]);
        //Debug.Log(roomsList[currentIndex]);
        SetButtonsActive();
    }
    #endregion

    #region Inventory UI

    public void AddItem(Sprite itemImg)
    {
        UIInventory[invIndex].SetImage(itemImg);
        UIInventory[invIndex].gameObject.SetActive(true);
        invIndex++;
    }

    public void RemoveItem(int index)
    {

    }

    #endregion 
    #endregion
}
