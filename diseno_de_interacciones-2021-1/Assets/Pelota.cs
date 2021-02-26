using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : Interactable
{
    public Vector3 direction;
    public Vector3 torque;
    public float speed;
    public float magnusScale = 10;
    private Rigidbody rb;
    private float intensity;

    void Start()
    {
        // Debug.Log("Hola crayola!");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //muevete 1 unidad de distancia cada frame
        //transform.Translate(direction * Time.deltaTime * speed);
        Vector3 velocity = rb.velocity;
        Vector3 angularVelocity = rb.angularVelocity;
        intensity = 2 * Mathf.PI * magnusScale;
        Vector3 magnus = Vector3.Cross(velocity, angularVelocity * intensity);
        rb.AddForce(magnus);
    }

    public override void Interact()
    {
        rb.AddForce(direction*speed, ForceMode.Force);
        rb.AddTorque(torque);
    }
}
