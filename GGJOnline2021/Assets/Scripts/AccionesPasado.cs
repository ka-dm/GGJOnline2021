using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesPasado : MonoBehaviour
{
    [SerializeField] GameObject arbol;
    public bool sembrar;
    int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        sembrar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space")) SembrarSemilla(transform.position);
    }

    public void SembrarSemilla(Vector3 pos)
    {
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            Instantiate(arbol, pos, rot);

            contador++;
            print("Sembar semilla" + contador);
    }



}
