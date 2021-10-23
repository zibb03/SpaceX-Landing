using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz2 : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            x +=1;
        }
        transform.position = new Vector3(x, 0, 0);
        //transform.rotation = Quaternion.Euler(45, 0, 0);
        //transform.localScale = new Vector3(2, 1, 1);
    }
}
