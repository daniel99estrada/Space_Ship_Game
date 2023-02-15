using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTumble : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float amplitudeY;
    public float timeY;
    public float amplitudeZ;
    public float timeZ;
    public float rotationX; 

    void Update()
    {
        timeY += Time.deltaTime;
        timeZ += Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.x, Mathf.Sin(timeY) * amplitudeY, Mathf.Sin(timeZ) * amplitudeZ);
    }
}
