using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public static float currentHealth;
    public static int increase = 20;
    public static int decrease = 20;
    public static int maxHealth = 100;

    public static float healthDecreaseInterval = 4.0f;

    void Start()
    {
        currentHealth = 50;

        // InvokeRepeating("Decrease", healthDecreaseInterval, healthDecreaseInterval);
    }

    void Update()
    {
        currentHealth -=   1.2f* Time.deltaTime;
    }

    public static void Inscrease()
    {
        currentHealth += increase;

        if(maxHealth < currentHealth)
        {   
            currentHealth = maxHealth;
        }
    }

    public void Decrease()
    {   
        Debug.Log("Decrease");
        currentHealth -= decrease;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
}
