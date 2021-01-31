using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour
{
    [SerializeField] Well nextWell;
    int accumulateWool = 0;
    int accumulateSeed = 0;

    public int AccumulateWool { get => accumulateWool; set => accumulateWool = value; }
    public int AccumulateSeed { get => accumulateSeed; set => accumulateSeed = value; }

    public void PassWoll()
    {
        nextWell.AccumulateWool++;
    }

    public void PassSeed()
    {
        nextWell.AccumulateSeed++;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró");
        if (other.transform.tag == "Player")
            other.gameObject.GetComponent<Inventory>().CurrentWell = this;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
            other.gameObject.GetComponent<Inventory>().CurrentWell = null;
    }
}