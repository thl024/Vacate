using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    CameraMovement mainCam;

    public Transform[] roomsList = new Transform[4];
    int currentIndex = 0;

    private void Awake()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        mainCam.MoveCam(roomsList[currentIndex]);
    }


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
        Debug.Log(currentIndex);
    }
}
