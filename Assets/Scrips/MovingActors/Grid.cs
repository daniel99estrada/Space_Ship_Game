using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid : MonoBehaviour
{   
    private int ROWS;
    private int COLS;
    private float WIDTH;
    private float HEIGHT;
    private float YOFFSET;
    private float XOFFSET;
    private int ROW_RATIO;
    private int COL_RATIO;
    private GameObject PREFAB;

    // bool canBuild = true;

    public void InstantiateActors(GameObject prefab, int rows, int cols, float width, float height, int rowRatio, int colRatio)
    {   
        PREFAB = prefab;
        ROWS = rows;
        COLS = cols;
        HEIGHT = height;
        WIDTH = width;
        XOFFSET = - ROWS / 2;
        YOFFSET = - COLS / 2;
        ROW_RATIO = rowRatio;
        COL_RATIO = colRatio;

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        XOFFSET = - rows /2 + player.position.x;
        YOFFSET = - cols /2 + player.position.y;
        SpawnActors();
    }

    public void SpawnActors()
    {       
        int n = ROWS;
        int[] pickedRows = Enumerable.Range(0, ROWS).OrderBy(x => Random.value).Take(n).ToArray();

        foreach (int row in pickedRows)
        {   
            n = COLS;
            int[] pickedColumns = Enumerable.Range(0, COLS).OrderBy(x => Random.value).Take(n).ToArray();

            foreach (int col in pickedColumns)
            {     
                float x = (row * WIDTH) + XOFFSET;
                float y = (col * HEIGHT) + YOFFSET;
                Vector3 position = new Vector3(x, y, transform.position.z);
                GameObject cell = Instantiate(PREFAB, position, Quaternion.identity);
                cell.transform.SetParent(this.transform);
            }
        }
    }

    // void Update()
    // {
    //     if (transform.position.z <= 0 && canBuild) 
    //     {
    //         transform.parent.GetComponent<ActorManager>().SpawnGrid();
    //         canBuild = false;
    //     }
    // }
}
