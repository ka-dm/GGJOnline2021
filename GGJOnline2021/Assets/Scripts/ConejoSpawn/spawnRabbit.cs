using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRabbit : MonoBehaviour
{
    [SerializeField] bool spawn;
    [SerializeField] GameObject rabbit;
    [SerializeField] int limitRabbit;

    [SerializeField] Vector2Int timeSpawnRabbit;

    [HideInInspector] public int currentRabbit;
    void Start()
    {
        StartCoroutine(Spawn());
    }



    IEnumerator Spawn()
    {
        while (spawn)
        {

            yield return new WaitForSeconds(Random.Range(timeSpawnRabbit.x, timeSpawnRabbit.y));

            if (currentRabbit < limitRabbit)
            {
                GameObject rabbitGO = Instantiate(rabbit, rabbitSpawn(), Quaternion.identity, transform);
                currentRabbit++;
            }

        }

    }

    Vector3 rabbitSpawn()
    {
        Vector3 randomPos = new Vector3(Random.Range(-15F, 15F), 0, Random.Range(-15F, 15F));
        Vector3 currentPos = transform.position + randomPos;
        currentPos.y = 0;
        return currentPos;

    }
}
