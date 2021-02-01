using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conejo : MonoBehaviour
{
    [HideInInspector] public spawnRabbit rabbitSpawn;

    private void Start()
    {
        rabbitSpawn = FindObjectOfType<spawnRabbit>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<Inventory>().wool++;
            rabbitSpawn.currentRabbit--;
            Destroy(this.gameObject);
        }
    }
}
