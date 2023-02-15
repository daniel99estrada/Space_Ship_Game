using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    public Joystick joystick;
    private float baseSpeed;
    private float speed;
    public float speedFactor;
    private Rigidbody rb;

    private float yaw;
    public float resetSpeed;

    public float yawAmount;
    public float rollAmount;
    public float pitchAmount;

    public float minYaw = -15f;
    public float maxYaw = 15f;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseSpeed = transform.parent.gameObject.GetComponent<ShipManager>().baseSpeed;
        speed = baseSpeed * speedFactor;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {   
        if (!canMove) return;
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 sideDirecion;
        Vector3 frontDirecion;

        if (horizontal > 0)
        {
            sideDirecion = Vector3.right;
        }
        else
        {
            sideDirecion = Vector3.left;
        }
        if (vertical > 0)
        {
            sideDirecion = Vector3.right;
        }
        else
        {
            sideDirecion = Vector3.left;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        transform.parent.gameObject.transform.position += movement;

        if (horizontal == 0)
        {
            yaw = Mathf.Lerp(yaw, 0, resetSpeed * Time.deltaTime);
        }
        else
        {
            yaw += horizontal * yawAmount * Time.deltaTime;
            yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
        }

        float pitch = Mathf.Lerp(0, pitchAmount, Mathf.Abs(vertical) * Mathf.Sign(vertical));
        float roll = Mathf.Lerp(0, rollAmount, Mathf.Abs(horizontal) * -Mathf.Sign(horizontal));
        transform.parent.gameObject.transform.localRotation = Quaternion.Euler(Vector3.up * yaw + sideDirecion * pitch + Vector3.forward * roll);
    }

    // void OnCollisionEnter(Collision other) 
    // {
    //     if (other.gameObject.tag == "Ground") 
    //     {   
    //         Debug.Log("Touched GROUND");
    //         rb.velocity = new Vector3(0f, 0f, 10f);
    //         canMove = false;
    //         Invoke("EnableMovement", 1f);
    //     }
    // }

    // void EnableMovement() {
    //     canMove = true;
    // }
}
