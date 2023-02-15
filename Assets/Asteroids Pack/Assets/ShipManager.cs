using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public List<GameObject> children = new List<GameObject>();

    public int currentIndex = 0;
    public float baseSpeed;

    private GameObject current;

    void Start()
    {
        foreach (Transform child in transform)
        {   
            child.gameObject.GetComponent<ShipActivator>().isActive = false;
            children.Add(child.gameObject);
        }
        current = children[currentIndex];
        current.GetComponent<ShipActivator>().isActive = true;
    }

    public void CycleObjects()
    {   
        current.GetComponent<ShipActivator>().isActive = false;
        currentIndex = (currentIndex + 1) % children.Count;
        current = children[currentIndex];
        current.GetComponent<ShipActivator>().isActive = true;
    }

    public void Shoot()
    {
        current.GetComponent<Shoot>().ShootLaser();
    }
}
