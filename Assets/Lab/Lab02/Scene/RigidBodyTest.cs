using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyTest : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity); //방향이 포함된 속도
        Debug.Log(rb.angularVelocity); //회전하고 있는 속도
        Debug.Log(rb.IsSleeping());
    }
}
