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
        Debug.Log(rb.velocity); //������ ���Ե� �ӵ�
        Debug.Log(rb.angularVelocity); //ȸ���ϰ� �ִ� �ӵ�
        Debug.Log(rb.IsSleeping());
    }
}
