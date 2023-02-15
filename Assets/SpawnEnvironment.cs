using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : MonoBehaviour
{   
    public float speed;
    public float interval;
    public float xMin;
    public float xMax;
    public List<GameObject> prefabs;
    public float z;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateActors", interval, interval);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void InstantiateActors()
    {   
        GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];
        float y = prefab.transform.position.y;
        float x = Random.Range(xMin, xMax);
        Vector3 position = new Vector3(x + player.position.x, 0, z);
        GameObject pawn = Instantiate(prefab, position, Quaternion.identity);
        pawn.transform.SetParent(this.transform);
        pawn.AddComponent<DeleteEnvironment>();
    }

    void Update()
    {   
        Vector3 direction = new Vector3(0,0,-1);
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
