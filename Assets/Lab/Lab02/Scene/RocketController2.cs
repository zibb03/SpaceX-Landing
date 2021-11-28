using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController2 : MonoBehaviour
{
    public Rigidbody rb;
    public AgentControler2 ac;
    public float force = 20f;
    public bool engineOn = false;
    
    public float cnt = 0;

    public bool reset = false;
    public Renderer floorRenderer;
    public GameObject engineFx;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AgentControler2>();
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
        cnt++;
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
            //���� ���� ��ǥ��� �Ǿ� �־� ȯ���� �������� �� ������ �߻��� >> ���� ��ǥ���
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
            //1f >> unity������ ��κ��� �Ǽ� ���꿡 float�� ���� �����
            ac.EndEpisode(1f);
        }
    }
}