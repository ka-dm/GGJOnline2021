using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejoTrigger : MonoBehaviour
{
    bool active = false;
    [SerializeField] float speed = 0.75F;
    float t = 0f;
    Vector3 currentPos;
    Vector3 randomPos;
    Transform originSpawn;


    private void Start()
    {
        originSpawn = FindObjectOfType<spawnRabbit>().transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            randomPos = new Vector3(Random.Range(-15F, 15F), 0, Random.Range(-15F, 15F));
            currentPos = originSpawn.position + randomPos;
            currentPos.y = 0;
            active = true;
            t = 0f;
        }
    }

    private void Update()
    {
        if(active)
        {  
            transform.position = Vector3.Lerp(transform.position, currentPos, t);
            transform.LookAt(currentPos);
            t += speed * Time.deltaTime;
        }
        if(t >= 1F)
        {
            t = 0F;
            active = false;
        }
    }
}
