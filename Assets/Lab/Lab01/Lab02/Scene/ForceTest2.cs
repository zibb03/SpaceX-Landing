using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest2 : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 1f;
    public Transform rightcube;
    public Transform leftcube;
    public Transform downcube;
    public Transform upcube;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force);
            //rb.AddForce(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rb.AddForceAtPosition(Vector3.right, transform.position);
            rb.AddForceAtPosition(new Vector3(1, 0, 0) * force / 5, transform.position);
            //rb.AddForceAtPosition(new Vector3(1, 0, 0) * force / 5, rightcube.position);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForceAtPosition(new Vector3(-1, 0, 0) * force / 5, transform.position);
            //rb.AddForceAtPosition(new Vector3(-1, 0, 0) * force / 5, leftcube.position);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForceAtPosition(new Vector3(0, 0, 1) * force / 5, transform.position);
            //rb.AddForceAtPosition(new Vector3(0, 0, 1) * force / 5, upcube.position);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForceAtPosition(new Vector3(0, 0, -1) * force / 5, transform.position);
            //rb.AddForceAtPosition(new Vector3(0, 0, -1) * force / 5, downcube.position);
        }
    }
}
