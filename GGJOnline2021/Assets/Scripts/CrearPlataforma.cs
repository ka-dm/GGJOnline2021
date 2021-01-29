using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPlataforma : MonoBehaviour
{
    [SerializeField] GameObject BlockPrefab;
    int n, m, scale;
    Vector3 leftBottomLocation = new Vector3(0,0,0);
    [SerializeField] Vector3 finalLocation;

    // Start is called before the first frame update
    void Start()
    {
        n = 15;
        m = 15;
        scale = 1;

        CrearCuadricula();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void CrearCuadricula()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                GameObject obj = Instantiate(
                    BlockPrefab,
                    new Vector3(leftBottomLocation.x + scale * i, leftBottomLocation.y, leftBottomLocation.z + scale * j),
                    Quaternion.identity);

                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStats>().x = i;
                obj.GetComponent<GridStats>().y = j;
            }
        }

        transform.position = finalLocation;
    }

}
