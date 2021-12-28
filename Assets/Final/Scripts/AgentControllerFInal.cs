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
        //start �Լ��� ��ü�ϴ� ��
        rc = GetComponent<RocketControllerFinal>();
    }

    public override void OnEpisodeBegin()
    {
        //���� ���۵� �� �ٽ� ȯ���� �缳���ϰ� �������ִ� �Լ�
        rc.ResetRocket();
        //���� �ʱ�ȭ
        episodeFinished = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //���� ���� ���¸� �˷��ִ� �Լ� (12����)
        //Vector3 rocketPosition = rc.transform.localPosition;
        //�������� ������ ���������µ�, ������ �ƴϱ� ������ �׳� position�� �ص� ��
        Vector3 rocketPosition = rc.transform.position;
        //rotation�� ��������
        Vector3 rocketRotation = rc.transform.rotation.eulerAngles;
        //�ӵ�
        Vector3 rocketVelocity = rc.rb.velocity;
        //���ӵ�(ȸ��)
        Vector3 rocketAngularVelocity = rc.rb.angularVelocity;

        //�޾ƿ� sensor��� ���ڿ� �����
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
        
        //���� ���� ���� ���� �����̸� �ִ� �۾�
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        //1�ʵ��� ����
        yield return new WaitForSeconds(1f);

        //�⺻������ �ִ� EndEpisode. ���� EndEpisode�� ���� ���� ��
        EndEpisode();
    }

    public override void Heuristic(in ActionBuffers actionsBuffers)
    {
        //�������� �����ϴ� ���
        //Monobehavior�� Update �Լ��� ������ ���
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