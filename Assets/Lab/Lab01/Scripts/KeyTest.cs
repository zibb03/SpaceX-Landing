using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("스페이스 바 눌림");
        }
    }
}
