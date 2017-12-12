using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public Canvas m_Canvas;
    public InputField m_UserNameInput;
    public InputField m_PasswordInput;
    public Button m_RegisterButton;
    public Button m_LoginButton;
    public Text m_MessageText;
    public GoWorldManager m_GoWorldManager;


    // Use this for initialization
    void Start()
    {
        m_Canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        m_UserNameInput = GameObject.Find("UserName").GetComponent<InputField>();
        m_PasswordInput = GameObject.Find("Password").GetComponent<InputField>();
        m_RegisterButton = GameObject.Find("Register").GetComponent<Button>();
        m_LoginButton = GameObject.Find("Login").GetComponent<Button>();
        m_MessageText = GameObject.Find("Message").GetComponent<Text>();

        m_RegisterButton.onClick.AddListener(OnRegister);
        m_LoginButton.onClick.AddListener(OnLogin);

        m_GoWorldManager = GameObject.FindObjectOfType<GoWorldManager>();
        m_MessageText.text = "";
        m_UserNameInput.ActivateInputField();
    }

    public void OnRegister()
    {
        Debug.Log("Register " + m_UserNameInput.text + ", " + m_PasswordInput.text);
        string username = m_UserNameInput.text.Trim();
        string password = m_PasswordInput.text;
        if (username == "")
        {
            showMessage("Username is empty!");
            return;
        }
        if (password == "")
        {
            showMessage("Password is empty!");
            return;
        }

        m_GoWorldManager.GetPlayer().CallServer("Register", username, password);
    }

    public void OnLogin()
    {
        Debug.Log("Login " + m_UserNameInput.text + ", " + m_PasswordInput.text);
        string username = m_UserNameInput.text.Trim();
        string password = m_PasswordInput.text;
        if (username == "")
        {
            showMessage("Username is empty!");
            return;
        }
        if (password == "")
        {
            showMessage("Password is empty!");
            return;
        }

        m_GoWorldManager.GetPlayer().CallServer("Login", username, password);
    }

    public void showMessage(string msg)
    {
        m_MessageText.text = msg;
    }
}
