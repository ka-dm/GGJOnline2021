using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionPlayer : MonoBehaviour
{
    MoveCar car;
    Inventory myInventory;


    // Start is called before the first frame update
    void Start()
    {
        car = FindObjectOfType<MoveCar>();
        myInventory = GetComponent<Inventory>();
    }

  

    public void OnAction(InputValue input)
    {
        if (Vector3.Distance( transform.position, car.carObj.transform.position) < 5)
        {
            car.ButtonCar(myInventory);
        }

    }
}
