using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvItem : MonoBehaviour {

    Sprite image;
    public Sprite testImage;

    void Awake()
    {
        image = GetComponent<Image>().sprite;
        Debug.Log(image);
    }

    void SetImage(Sprite inSprite)
    {
        image = inSprite;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetImage(testImage);
        }
    }

}
