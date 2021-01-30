using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageOrbe : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<MessageSender>().MessagesAvailable++;
            Destroy(this.gameObject);
        }
            
    }
}
