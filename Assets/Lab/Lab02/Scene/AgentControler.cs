using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AgentControler : Agent
{
    public RocketController rc;
    public bool episodeFInished = false;
    public override void Initialize()
    {
        rc = GetComponent<RocketController>();
    }
    public override void OnEpisodeBegin()
    {
        rc.ResetRocket();
        episodeFInished = false;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //������ ���¸� �˷��� �� �ִ� �� ����
        Vector3 rocketPosition = rc.transform.position;
        Vector3 rocketVelocity = rc.rb.velocity;

        sensor.AddObservation(rocketPosition.x);
        sensor.AddObservation(rocketPosition.y);
        sensor.AddObservation(rocketPosition.z);

        sensor.AddObservation(rocketVelocity.x);
        sensor.AddObservation(rocketVelocity.y);
        sensor.AddObservation(rocketVelocity.z);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 1)
        {
            rc.OnEngine();
        }
        else
        {
            rc.OffEngine();
        }
    }
    public void EndEpisode(float reward) //EndEpisode��� �Լ��� �ִµ� ���ڰ��� ��� overroad�� �� 
    {
        SetReward(reward);
        episodeFInished = true;
        StartCoroutine(WaitCoroutine()); //1�ʵڿ� EndEpisode �����ϵ��� �ϴ� �ڵ�
    }
    IEnumerator WaitCoroutine() //���ÿ� ����ǵ��� �ϴ°�
    {
        yield return new WaitForSeconds(1f);
        EndEpisode();
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.Space))
        {
           discreteActions[0] = 1;
        }
        else
        {
            discreteActions[0] = 0;
        }
    }
}
