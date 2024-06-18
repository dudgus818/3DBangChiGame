using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // �� ������ ����Ʈ
    public Transform playerTransform; // �÷��̾��� Transform
    public float spawnInterval = 5f; // �� ���� ����
    public float spawnDistance = 3f; // �÷��̾� �տ� ������ �Ÿ�
    public float spawnRangeX = 5f; // x�� ���� ����

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomEnemy();
        }
    }

    void SpawnRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, playerTransform.position.z + spawnDistance);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
