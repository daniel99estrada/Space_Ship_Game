using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipActivator : MonoBehaviour
{   
    public bool isActive;
    Renderer rend;
    ShipMovement movement;
    Shoot shoot;

    void Start()
    {
        rend = GetComponent<Renderer>();
        movement = GetComponent<ShipMovement>();
        shoot = GetComponent<Shoot>();
    }
    void Update()
    {   
        activateShip();
    }
    
    public void activateShip()
    {
        rend.enabled = isActive;
        movement.enabled = isActive;
        shoot.enabled = isActive;
    }
}
