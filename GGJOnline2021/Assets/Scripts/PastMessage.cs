using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PastMessage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI message;
    // Start is called before the first frame update
    void Start()
    {
        MessageSender.sendMessage += (string s) => message.text = s;
    }

    private void OnDestroy()
    {
        
    }
}
