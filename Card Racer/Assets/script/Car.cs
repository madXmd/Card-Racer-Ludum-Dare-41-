using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Car : MonoBehaviour {

    public new Rigidbody rigidbody;
    public double currentSpeed;
    public double maxCurrentSpeed;

  


    //Stats 
    public float health;
    public float speedForce;
    public float maxSpeed;
    public float acceleration;


    // Use this for initialization
    void Start () {
        
        health = 100;
        speedForce = 1000;
        maxSpeed = 50;
        acceleration = 10;

        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;


    }

    private void FixedUpdate()
    {
        currentSpeed = rigidbody.velocity.magnitude * 3.6;
        if(currentSpeed <= maxCurrentSpeed && maxCurrentSpeed != 0)
        {
            rigidbody.AddForce(transform.forward * speedForce * Time.deltaTime);
        }
        if (currentSpeed > maxCurrentSpeed && maxCurrentSpeed != 0)
        {
            rigidbody.AddForce(transform.forward * -1 * speedForce * Time.deltaTime);
        }

    }

    public void useGas()
    {
        maxCurrentSpeed += acceleration;
        speedForce += acceleration * 100;
        if (maxCurrentSpeed >= maxSpeed)
            maxCurrentSpeed = maxSpeed;
    }

    public void useBreak()
    {
        maxCurrentSpeed -= acceleration;
        speedForce -= acceleration * 100;
        if (maxCurrentSpeed <= 0)
            maxCurrentSpeed = 0;
    }

    public void useTrun(Vector3 eulerAngleVelocity)
    {
        StartCoroutine(Rotate(eulerAngleVelocity, 1.0f));
    }

    IEnumerator Rotate(Vector3 angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
    }


}
