using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string name;
    public int buyCost;
    public int upgradeCost;
    public int manaCost; // 마나 비용
    public GameObject skillPrefab; // 스킬 프리팹
    public GameObject skillIconPrefab; // 스킬 아이콘 프리팹
    public GameObject particlePrefab; // 파티클 프리팹
    public Transform spawnPoint; // 스폰 포인트
    public bool isPurchased = false;
    [HideInInspector]
    public GameObject instance;
}
