using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public GameObject particlePrefab; // 파티클 시스템 프리팹

    public void Activate()
    {
        if (particlePrefab == null)
        {
            Debug.LogError("파티클 프리팹 없음");
            return;
        }

        // 파티클 시스템 인스턴스화
        GameObject particleInstance = Instantiate(particlePrefab, transform.position, transform.rotation);
        ParticleSystem particleSystem = particleInstance.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            particleSystem.Play();
            Debug.Log("재생되고 있는 파티클:  " + particleInstance.name);
        }
        else
        {
            Debug.LogError("파티클에서 프리팹을 찾을 수 없음");
        }

        // 일정 시간 후 파티클 시스템 제거
        Destroy(particleInstance, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
    }
}
