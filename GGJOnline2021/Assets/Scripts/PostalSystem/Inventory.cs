using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public int wool = 1;
    public int seed = 5;
    Well currentWell;

    public Well CurrentWell { get => currentWell; set => currentWell = value; }

    public void addWool()
    {
        wool++;
    }

    public void OnSendWool(InputValue input)
    {
        if (currentWell.AccumulateSeed > 0)
        {
            seed++;
            currentWell.AccumulateSeed--;
        }
        else if (CurrentWell != null && wool > 0)
        {
            wool--;
            CurrentWell.PassWoll();
        }
    }

    public void OnSendSeed(InputValue input)
    {
        if(currentWell.AccumulateWool > 0)
        {
            wool++;
            currentWell.AccumulateWool--;
        }
        else if (CurrentWell != null && seed > 0)
        {
            seed--;
            CurrentWell.PassSeed();
        }
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
