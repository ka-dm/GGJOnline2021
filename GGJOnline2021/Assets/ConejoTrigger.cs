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


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            currentPos = this.transform.position;
            randomPos = new Vector3(Random.Range(-20F, 20F), 0, Random.Range(-20F, 20F));
            active = true;
            t = 0f;
        }
    }

    private void Update()
    {
        if(active)
        {  
            transform.position = Vector3.Lerp(currentPos, currentPos + randomPos, t);
            t += speed * Time.deltaTime;
        }
        if(t >= 1F)
        {
            t = 0F;
            active = false;
        }
    }
}
