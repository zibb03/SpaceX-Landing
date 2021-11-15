using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Rigidbody rb;
    public AgentControler ac;
    public Renderer floorRenderer;
    public GameObject engineFx;
    public float force = 20f;
    public bool engineOn = false;
    public bool reset = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AgentControler>();
    } 
    // Update is called once per frame
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
        if (ac.episodeFInished)
        {
            return;
        }
        if (reset)
        {
            transform.position = new Vector3(0, 20, 0);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (ac.episodeFInished)
        {
            return;
        }
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
