using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Movement : MonoBehaviour
{
    public NavMeshAgent agent; // NavMeshAgent ������Ʈ
    public bool isMoving = false; // �̵� ���θ� �����ϴ� �÷���

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isMoving)
        {
            agent.destination = transform.position + Vector3.forward * 10f;
        }
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
