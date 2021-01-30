using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStats : MonoBehaviour
{
    public int content = -1;
    public int x = 0;
    public int y = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //print("["+x+","+y+"]" + " collisionInfo = " + collisionInfo.gameObject.name);
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
