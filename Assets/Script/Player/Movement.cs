using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Movement : MonoBehaviour
{
    public NavMeshAgent agent; // NavMeshAgent 컴포넌트
    public bool isMoving = false; // 이동 여부를 제어하는 플래그

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
