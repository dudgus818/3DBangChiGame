using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapSectionPrefab; // 맵 섹션 프리팹
    public int initialSections = 5; // 처음에 생성할 섹션 수
    public Transform playerTransform; // 플레이어의 Transform
    public float sectionLength = 10f; // 섹션의 길이

    private List<GameObject> activeSections = new List<GameObject>();
    private float spawnZ = 26f; // 다음 섹션의 z 위치

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
