using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AccionesPasado : MonoBehaviour
{
    [SerializeField] GameObject semilla;
    [SerializeField] GameObject arbol;
    [SerializeField] Grid grid;
    [SerializeField] float distanciaEntrePlataformas;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp("space")) SembrarSemilla(transform.position);
    }

    public void OnSembrar(InputValue input)
    {
        Vector3 pos = grid.GetNearestPointOnGrid(transform.position);
        Instantiate(semilla, pos, Quaternion.identity);

        var treePos = new Vector3(distanciaEntrePlataformas, 0, 0);
        Vector3 pos2 = grid.GetNearestPointOnGrid(pos + treePos);
        var arb = Instantiate(arbol);
        arb.transform.position = pos2;

    }
}
