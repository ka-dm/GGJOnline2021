using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Tree lastTree;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<CreateLineAction>().nearestTree = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<CreateLineAction>().lastTree = this;
            other.gameObject.GetComponent<CreateLineAction>().nearestTree = null;
        }
    }
}
