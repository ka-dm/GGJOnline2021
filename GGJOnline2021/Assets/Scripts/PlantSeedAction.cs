using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public delegate void NotifySeedNumber(int num);

public class PlantSeedAction : MonoBehaviour
{
    [SerializeField] GameObject semilla;
    [SerializeField] GameObject arbol;
    [SerializeField] Grid grid;
    [SerializeField] float distanciaEntrePlataformas;

    [SerializeField] Inventory inventory;

    [SerializeField] List<GameObject> listSeed = new List<GameObject>();


    public static event NotifySeedNumber updateSeedNumber;

    private void Start()
    {
        grid = (Grid)FindObjectOfType(typeof(Grid));
        if (updateSeedNumber != null)
        updateSeedNumber(inventory.seed);
    }

    public void OnSembrar(InputValue input)
    {

        for (int i = 0; i < listSeed.Count; i++)
        {
            if (listSeed[i].transform.position == grid.GetNearestPointOnGrid(transform.position))
                return;
        }

        if(inventory.seed > 0)
        {
            inventory.seed--;
            if (updateSeedNumber != null)
                updateSeedNumber(inventory.seed);
            Vector3 pos = grid.GetNearestPointOnGrid(transform.position);
            GameObject seed = Instantiate(semilla, pos, Quaternion.identity);
            listSeed.Add(seed);
            MakeTree(pos);
        }
    }

    private void MakeTree(Vector3 pos)
    {
        var treePos = new Vector3(distanciaEntrePlataformas, 0, 0);
        Vector3 pos2 = grid.GetNearestPointOnGrid(pos + treePos);
        Vector3 rotation = new Vector3(-90F, 0, Random.Range(-180f, 180f));
        var arb = Instantiate(arbol, pos2, Quaternion.Euler(rotation));
    }
}
