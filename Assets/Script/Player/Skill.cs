using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public string name;
    public int buyCost;
    public int upgradeCost;
    public int manaCost; // ���� ���
    public GameObject skillPrefab; // ��ų ������
    public GameObject skillIconPrefab; // ��ų ������ ������
    public GameObject particlePrefab; // ��ƼŬ ������
    public Transform spawnPoint; // ���� ����Ʈ
    public bool isPurchased = false;
    [HideInInspector]
    public GameObject instance;
}
