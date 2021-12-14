using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz6_1 : MonoBehaviour
{
    public Rigidbody rb;
    public Renderer floorRenderer;
    public float force = 10f;
    public bool engineOn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
        if (Input.GetKey(KeyCode.Space))
        {
            engineOn = true;
        }
        else
        {
            engineOn = false;
        }
    }
    private void FixedUpdate()
    {
        // Debug.Log(Time.fixedDeltaTime);
        if (engineOn)
        {
            rb.AddForce(Vector3.up * force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.y > 10f)
        {
            floorRenderer.material.color = Color.red;
        }
        else
        {
            floorRenderer.material.color = Color.green;
        }
    }
}
