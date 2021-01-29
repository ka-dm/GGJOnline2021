using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        //if (Input.GetKeyUp("space")) SembrarSemilla(transform.position);
    }

    public void OnSembrarSemilla(InputValue input)
    {
        Vector3 pos = transform.position;
        Instantiate(arbol, pos, Quaternion.identity);

        contador++;
        print("Sembar semilla" + contador);
    }
}
