using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // 적 프리팹 리스트
    public Transform playerTransform; // 플레이어의 Transform
    public float spawnInterval = 5f; // 적 생성 간격
    public float spawnDistance = 3f; // 플레이어 앞에 생성될 거리
    public float spawnRangeX = 5f; // x축 랜덤 범위

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
