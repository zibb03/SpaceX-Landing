using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public Renderer rd;

    /*private void Update()
    {
        rd.material.color = Color.red;
    }*/
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log(collision.relativeVelocity);
        if (collision.relativeVelocity.y > 70)
        {
            rd.material.color = Color.red;
        }
        if (collision.relativeVelocity.y > 0 && collision.relativeVelocity.y <= 70)
        {
            rd.material.color = Color.blue;
        }
    }
}
