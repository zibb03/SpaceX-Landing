using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Rigidbody rb;
    public AgentControler ac;
    public float force = 20f;
    public bool engineOn = false;

    public bool reset = false;
    public Renderer floorRenderer;
    public GameObject engineFx;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AgentControler>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetRocket()
    {
        reset = true;
    }

    public void OnEngine()
    {
        engineOn = true;
    }

    public void OffEngine()
    {
        engineOn = false;
    }
    private void FixedUpdate()
    {
        if (ac.episodeFinished)
        {
            return;
        }

        if (reset)
        {
            //월드 공간 좌표계로 되어 있어 환경을 복사했을 때 문제가 발생함 >> 로컬 좌표계로
            transform.localPosition = new Vector3(0, 25, 0);
            rb.velocity = Vector3.zero;

            reset = false;
            floorRenderer.material.color = Color.white;
            return;
        }

        if (engineOn)
        {
            rb.AddForce(Vector3.up * force);
            engineFx.SetActive(true);
        }
        else
        {
            engineFx.SetActive(false);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (ac.episodeFinished)
        {
            return;
        }

        //Debug.Log(collision.relativeVelocity);
        if (collision.relativeVelocity.y > 10f)
        {
            floorRenderer.material.color = Color.red;
            ac.EndEpisode(0f);
        }
        else
        {
            floorRenderer.material.color = Color.green;
            ac.EndEpisode(1f);
        }
    }
}