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
        //로켓의 상태를 알려줄 수 있는 값 넣음
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
    public void EndEpisode(float reward) //EndEpisode라는 함수가 있는데 인자값이 없어서 overroad한 것 
    {
        SetReward(reward);
        episodeFInished = true;
        StartCoroutine(WaitCoroutine()); //1초뒤에 EndEpisode 실행하도록 하는 코드
    }
    IEnumerator WaitCoroutine() //동시에 실행되도록 하는것
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
