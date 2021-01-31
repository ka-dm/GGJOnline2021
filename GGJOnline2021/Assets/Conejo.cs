using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conejo : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<Inventory>().wool++;
            Destroy(this.gameObject);
        }
    }
}
