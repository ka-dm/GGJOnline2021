using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearFantasmas : MonoBehaviour
{
    public GameObject fantasma;
    public float timer;
    public float inicioTimer;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            int cantidadEnemigos = Random.Range(0, 4);
            
            for (int i = 0; i < cantidadEnemigos; i++)
            {
                Instantiate(fantasma, transform.position, Quaternion.identity);
            }

            timer = inicioTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
