using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movFantasma : MonoBehaviour
{
    public Transform objectFollow;
    public float velocidadMovimiento;
    Vector3 movimiento = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        int enemigoSeguir = Random.Range(0, 2);

        if (enemigoSeguir == 1)
        {
            objectFollow = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>();
        }
        else{
            objectFollow = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(objectFollow.position);
        transform.Translate(0.0f, 0.0f, velocidadMovimiento*Time.deltaTime);

        }

    public void OnTriggerEnter(Collider collision) 
    {
       // if (collision.tag == "base")
            Destroy(gameObject);
    }
}

