using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Button battleButton;
    public Movement movement;
    public MapGenerator mapGenerator;
    public EnemySpawner enemySpawner;

    void Start()
    {
        battleButton.onClick.AddListener(StartBattle);
    }

    public void StartBattle()
    {
        movement.enabled = true;
        mapGenerator.enabled = true;
        enemySpawner.enabled = true;
        battleButton.gameObject.SetActive(false);
    }
}
