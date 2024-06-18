using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public GameObject particlePrefab; // ��ƼŬ �ý��� ������

    public void Activate()
    {
        if (particlePrefab == null)
        {
            Debug.LogError("��ƼŬ ������ ����");
            return;
        }

        // ��ƼŬ �ý��� �ν��Ͻ�ȭ
        GameObject particleInstance = Instantiate(particlePrefab, transform.position, transform.rotation);
        ParticleSystem particleSystem = particleInstance.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            particleSystem.Play();
            Debug.Log("����ǰ� �ִ� ��ƼŬ:  " + particleInstance.name);
        }
        else
        {
            Debug.LogError("��ƼŬ���� �������� ã�� �� ����");
        }

        // ���� �ð� �� ��ƼŬ �ý��� ����
        Destroy(particleInstance, particleSystem.main.duration + particleSystem.main.startLifetime.constantMax);
    }
}
