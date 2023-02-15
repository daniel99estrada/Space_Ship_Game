using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public bool ray;
    public float scaleFactor;
    public Vector3 targetScale;
    public float scaleSpeed;

    void Update()
    {   
        this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Destroy(this.gameObject, 10f);

        if(ray) ScaleRay();
    }

    void ScaleRay()
    {   
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "actor" && ray)
        {
            collision.gameObject.GetComponent<ReturnToShip>().contact = true;
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
