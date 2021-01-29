using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MessageSender : MonoBehaviour
{
    [SerializeField] TMP_InputField messageField;
    public void OnSendMessage(InputValue input)
    {
        Debug.Log(messageField.text);
        messageField.text = "";
    }
}
