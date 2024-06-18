using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Helper
{
    public string name;
    public int buyCost;
    public int upgradeCost;
    public GameObject helperPrefab;
    public Transform spawnPoint; // 스폰 포인트
    public bool isPurchased = false;
    [HideInInspector]
    public GameObject instance;
}
