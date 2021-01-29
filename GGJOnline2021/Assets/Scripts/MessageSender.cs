using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void SendMessage(string message);

public class MessageSender : MonoBehaviour
{
    [SerializeField] TMP_InputField messageField;
    [SerializeField] TextMeshProUGUI characterCounter;
    [SerializeField] int messagesAvailable = 3;
    public static event SendMessage sendMessage;

    [SerializeField] GameObject availableMessagesCounter;
    [SerializeField] GameObject mailIconPrefab;

    private void Start()
    {
        messageField.onValueChanged.AddListener(delegate { UpdateCharacterCounter(); });
        messageField.onSelect.AddListener(delegate { SwitchToMessageInputMode(); });
        messageField.onDeselect.AddListener(delegate { SwitchToGameplayMode(); });

        UpdateCharacterCounter();
        UpdateAvailableMessagesCounter();
    }
    public void OnSendMessage(InputValue input)
    {
        if(messageField.text != "")
        {
            HandleMessage();
            SwitchToGameplayMode();
            UpdateAvailableMessagesCounter();
        }

    }

    private void HandleMessage()
    {
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

    private void UpdateCharacterCounter()
    {
        characterCounter.text = string.Format("{0} / {1}", messageField.text.Length, messageField.characterLimit);
    }

    private void UpdateAvailableMessagesCounter()
    {
        RemoveEveryAvailableMessageCounter();
        for (int i = 0; i < messagesAvailable; i++)
        {
            var go = Instantiate(mailIconPrefab);
            go.transform.parent = availableMessagesCounter.transform;
        }   
    }

    private void RemoveEveryAvailableMessageCounter()
    {
        foreach (Transform child in availableMessagesCounter.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void SwitchToMessageInputMode()
    {
        this.gameObject.GetComponent<Movement>().enabled = false;
    }

    private void SwitchToGameplayMode()
    {
        this.gameObject.GetComponent<Movement>().enabled = true;
    }
}
