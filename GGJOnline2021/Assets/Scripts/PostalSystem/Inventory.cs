using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int wool;

    public void addWool()
    {
        wool++;
    }


    public void MoveToCar(MoveCar move)
    {
        move.inventoryCar = wool;
        wool = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wool"))
        {
            addWool();
            Destroy(other.gameObject);
        }
    }

}
