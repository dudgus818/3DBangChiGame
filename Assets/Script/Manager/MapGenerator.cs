using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapSectionPrefab; // �� ���� ������
    public int initialSections = 5; // ó���� ������ ���� ��
    public Transform playerTransform; // �÷��̾��� Transform
    public float sectionLength = 10f; // ������ ����

    private List<GameObject> activeSections = new List<GameObject>();
    private float spawnZ = 26f; // ���� ������ z ��ġ

    void Start()
    {
        for (int i = 0; i < initialSections; i++)
        {
            SpawnSection();
        }
    }

    void Update()
    {
        if (playerTransform.position.z > (spawnZ - initialSections * sectionLength))
        {
            SpawnSection();
            DeleteSection();
        }
    }

    void SpawnSection()
    {
        GameObject section = Instantiate(mapSectionPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);
        activeSections.Add(section);
        spawnZ += sectionLength;
    }

    void DeleteSection()
    {
        Destroy(activeSections[0]);
        activeSections.RemoveAt(0);
    }
}
