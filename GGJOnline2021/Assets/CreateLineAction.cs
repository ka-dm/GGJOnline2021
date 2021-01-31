using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateLineAction : MonoBehaviour
{
    public bool Active { get; set; }
    [SerializeField] GameObject linePrefab;
    LineRenderer currentLine;
    Vector3 currentPoint;
    [SerializeField] Inventory inventory;
    [SerializeField] Grid grid;
    public Tree nearestTree;
    public Tree lastTree;
    int contador = 2;
    [SerializeField] GameObject ganaste;
    Vector3 plus = new Vector3(0, 2.2F, 0);


    private void Start()
    {
        grid = (Grid)FindObjectOfType(typeof(Grid));
    }
    private void DrawLine()
    {
        if(currentLine == null && inventory.wool > 0 && nearestTree != null)
        {
            inventory.wool--;
            currentLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
            currentPoint = grid.GetNearestPointOnGrid(nearestTree.gameObject.transform.position);
        }
        else if (currentLine != null && nearestTree != null)
        {
            nearestTree.lastTree = this.lastTree;
            var points = new Vector3[2];
            points[0] = currentPoint + plus;
            points[1] = grid.GetNearestPointOnGrid(nearestTree.gameObject.transform.position) + plus;

            currentLine.SetPositions(points);

            var meshCollider = currentLine.gameObject.AddComponent<MeshCollider>();
            Mesh mesh = new Mesh();
            currentLine.BakeMesh(mesh, true);
            meshCollider.sharedMesh = mesh;
            meshCollider.convex = true;

            VerificarEncierro();

            currentLine = null;
        } 
    }

    public void VerificarEncierro()
    {
        var listaArboles = new List<Tree>();
        var fistArbolito = nearestTree;
        Tree arbolito = nearestTree;
        while(arbolito.lastTree != null)
        {       
            listaArboles.Add(arbolito.lastTree);
            arbolito = arbolito.lastTree;
            if (arbolito == fistArbolito)
            {
                inventory.wool += 3;
                contador--;
                break;
            }
        }

        if(contador == 0)
        {
            ganaste.gameObject.SetActive(true);
        }
        
    }

    public void OnCreateLine(InputValue input)
    {
        DrawLine();
    }

    private void Update()
    {
        if(currentLine != null)
        {
            var points = new Vector3[2];
            points[0] = currentPoint + plus;
            points[1] = this.gameObject.transform.position + plus;

            currentLine.SetPositions(points);
        }
    }
}
