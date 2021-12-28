using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AgentControllerFinal : Agent
{
    public RocketControllerFinal rc;
    public bool episodeFinished = false;

    public override void Initialize()
    {
        //start 함수를 대체하는 것
        rc = GetComponent<RocketControllerFinal>();
    }

    public override void OnEpisodeBegin()
    {
        //매판 시작될 때 다시 환경을 재설정하고 실행해주는 함수
        rc.ResetRocket();
        //로켓 초기화
        episodeFinished = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //나의 현재 상태를 알려주는 함수 (12가지)
        //Vector3 rocketPosition = rc.transform.localPosition;
        //예전에는 발판이 여러개였는데, 지금은 아니기 때문에 그냥 position로 해도 됨
        Vector3 rocketPosition = rc.transform.position;
        //rotation도 마찬가지
        Vector3 rocketRotation = rc.transform.rotation.eulerAngles;
        //속도
        Vector3 rocketVelocity = rc.rb.velocity;
        //각속도(회전)
        Vector3 rocketAngularVelocity = rc.rb.angularVelocity;

        //받아온 sensor라는 인자에 기록함
        sensor.AddObservation(rocketPosition.x);
        sensor.AddObservation(rocketPosition.y);
        sensor.AddObservation(rocketPosition.z);

        sensor.AddObservation(rocketRotation.x);
        sensor.AddObservation(rocketRotation.y);
        sensor.AddObservation(rocketRotation.z);

        sensor.AddObservation(rocketVelocity.x);
        sensor.AddObservation(rocketVelocity.y);
        sensor.AddObservation(rocketVelocity.z);

        sensor.AddObservation(rocketAngularVelocity.x);
        sensor.AddObservation(rocketAngularVelocity.y);
        sensor.AddObservation(rocketAngularVelocity.z);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        rc.SetMainEngine(actionBuffers.DiscreteActions[0]);
        rc.SetLeftEngine(actionBuffers.DiscreteActions[1]);
        rc.SetRightEngine(actionBuffers.DiscreteActions[2]);
        rc.SetForwardEngine(actionBuffers.DiscreteActions[3]);
        rc.SetBackwardEngine(actionBuffers.DiscreteActions[4]);
    }

    public void EndEpisode(float reward)
    {
        SetReward(reward);

        episodeFinished = true;
        
        //끝난 것을 보기 위해 딜레이를 주는 작업
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        //1초동안 정지
        yield return new WaitForSeconds(1f);

        //기본적으로 있는 EndEpisode. 위의 EndEpisode는 직접 만든 것
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsBuffers)
    {
        //수동으로 동작하는 모드
        //Monobehavior의 Update 함수와 유사한 기능
        var actionsOut = actionsBuffers.DiscreteActions;
        if (Input.GetKey(KeyCode.Space))
        {
            actionsOut[0] = 1;
        }
        else
        {
            actionsOut[0] = 0;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[1] = 1;
        }
        else
        {
            actionsOut[1] = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[2] = 1;
        }
        else
        {
            actionsOut[2] = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[3] = 1;
        }
        else
        {
            actionsOut[3] = 0;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            actionsOut[4] = 1;
        }
        else
        {
            actionsOut[4] = 0;
        }
    }
}