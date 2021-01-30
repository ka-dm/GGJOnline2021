using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    [SerializeField] GameObject Wool;
    [SerializeField] Transform WoolPos;
    [SerializeField] Transform[] points;
    public Transform carObj;
    [SerializeField] bool goMove;
    [SerializeField] float speed;
    [SerializeField] float minRange;
    public int inventoryCar;
    bool ejectInventory;

    int currenNumb;

    void Start()
    {
        carObj.transform.position = points[0].transform.position;
    }

    void Update()
    {
        MovementCar();
    }

    public void ButtonCar(Inventory inventory)
    {
        if (inventory.wool > 0)
        {
            inventory.MoveToCar(this);
            goMove = !goMove;

        }
    }




    private void MovementCar()
    {
        if (goMove)
        {
            if (Vector3.Distance(points[currenNumb].position, carObj.position) < minRange)
            {
                currenNumb++;
                if (currenNumb >= points.Length)
                {
                    currenNumb = 0;
                }
                goMove = false;
                ejectInventory = false;
            }
        }


        if (Vector3.Distance(points[currenNumb].position, carObj.position) > minRange)
        {
            carObj.transform.position = Vector3.MoveTowards(carObj.transform.position, points[currenNumb].position, speed * Time.deltaTime);
        }
        else
        {
            if (inventoryCar > 0 && !ejectInventory)
            {
                for (int i = 0; i < inventoryCar; i++)
                {
                    Instantiate(Wool, WoolPos.position, Quaternion.identity);
                }
                inventoryCar = 0;
                ejectInventory = true;
            }

        }
        

    }

}
