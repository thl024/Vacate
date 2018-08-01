using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerObject : InteractableObject {
    #region Data
    [SerializeField]
    string password = "password";
    [SerializeField]
    string passwordHint = "It's a password";
    [SerializeField]
    string errorMessage = "Incorrect password";

    public bool isTesting = true;


    //Properties.    use like variables: ( Computer.IsOn = true. )
    [SerializeField]
    public bool IsON { get; set; }
    public bool HasPeripherals { get; set; }
    public bool IsPWCorrect { get; set; }
    public bool HasUSB { get; set; }

    Button pwInput, txtIcon;

    InputField pwField;

    Text hintText;
    
    Image compScreen, logIn, homeScreen, txtPopUp;

    GameObject Testing;
    #endregion

    #region SetUp
    void Awake()
    {
        compScreen = transform.Find("Computer Screen").gameObject.GetComponent<Image>();
        logIn = transform.Find("Computer Screen/LogInScreen").gameObject.GetComponent<Image>();
        homeScreen = transform.Find("Computer Screen/HomeScreen").gameObject.GetComponent<Image>();
        txtPopUp = homeScreen.transform.Find("pw.txtPopUp").gameObject.GetComponent<Image>();

        pwField = logIn.transform.Find("PWInputField").gameObject.GetComponent<InputField>();
        hintText = logIn.transform.Find("HintText").gameObject.GetComponent<Text>();

        pwInput = logIn.transform.Find("PassWordEnterButton").gameObject.GetComponent<Button>();
        txtIcon = homeScreen.transform.Find("pw.txtUI").gameObject.GetComponent<Button>();

        Testing = transform.Find("Testing Buttons").gameObject;

        IsON = false;
        HasPeripherals = false;
        IsPWCorrect = false;
        HasUSB = false;

        logIn.gameObject.SetActive(false);
        homeScreen.gameObject.SetActive(false);
        txtPopUp.gameObject.SetActive(false);

        Testing.gameObject.SetActive(isTesting);

    }
    #endregion


    #region Functionality

    void PrintProperties()
    {
        Debug.Log("IsOn: " + IsON);
        Debug.Log("HasPeripherals: " + HasPeripherals);
        Debug.Log("IsPWCorrect: " + IsPWCorrect);
        Debug.Log("HasUSB: " + HasUSB);
    }

    public void CheckPW() //to be hooked up to the pwcheck button
    {
        if (pwField.text == password) { IsPWCorrect = true;  }
        else
        {
            hintText.text = errorMessage;
        }
        PrintProperties();

        
    }

    public void RunComputer()
    {
        PrintProperties();
        if (IsON)
        {
            logIn.gameObject.SetActive(true);

            if (HasPeripherals)
            {
                pwField.interactable = true;
                pwInput.interactable = true;
                HomeScreen();
            }

            else //if computer does not have peripherals, cannot interact w/stuff
            {
                pwInput.interactable = false;
                pwField.interactable = false ;
            }
           
        }
        else
        {
            logIn.gameObject.SetActive(false);
            homeScreen.gameObject.SetActive(false);
        }
    }

    public void HomeScreen()
    {
        if (IsPWCorrect) { 
            logIn.gameObject.SetActive(false);
            homeScreen.gameObject.SetActive(true);
            if (HasUSB)
            {
                txtIcon.gameObject.SetActive(true);
            }
            else
            {
                txtIcon.gameObject.SetActive(false);
            }
        }
    }

    public void TxtIcon()
    {
        txtPopUp.gameObject.SetActive(true);
    }

    public void closeTxtPopUp()
    {
        txtPopUp.gameObject.SetActive(false);
    }
    #endregion

}
