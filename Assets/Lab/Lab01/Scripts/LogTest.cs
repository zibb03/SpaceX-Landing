using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LogTest Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LogTest Update");
    }

    // 물리엔진이 연산을 수행할 때마다 실행
    private void FixedUpdate()
    {

    }
}
