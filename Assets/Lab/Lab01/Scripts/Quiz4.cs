using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz4 : MonoBehaviour
{
    public float x = 0;
    //public int y = 0;
    public float z = 0;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                z += speed;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                z -= speed;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                x -= speed;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                x += speed;
            }
        }
        
        transform.position = new Vector3(x, 0, z);
    }
}
