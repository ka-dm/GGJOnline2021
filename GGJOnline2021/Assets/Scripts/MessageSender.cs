using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void SendMessage(string message);

public class MessageSender : MonoBehaviour
{
    [SerializeField] TMP_InputField messageField;
    [SerializeField] int messagesAvailable = 3;
    public static event SendMessage sendMessage;
    public void OnSendMessage(InputValue input)
    {
        if(messageField.text != "")
        {
            HandleMessage();
        }

    }

    private void HandleMessage()
    {
        Debug.Log(messageField.text);
        sendMessage(messageField.text);
        messageField.text = "";
        messagesAvailable--;
        VerifyRemianingMessages();
    }

    private void VerifyRemianingMessages()
    {
        if (messagesAvailable == 0)
            messageField.interactable = false;
    }
}
