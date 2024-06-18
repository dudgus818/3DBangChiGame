using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldAdd : MonoBehaviour
{
    public Text goldText; // UI에 골드를 표시할 텍스트
    public float goldIncreaseRate = 1f; // 골드 증가 주기 (초 단위)
    public int goldPerInterval = 10; // 주기마다 증가할 골드 양

    private double currentGold = 0; // 현재 골드
    private float timer = 0f;

    public double CurrentGold
    {
        get { return currentGold; }
    }

    void Start()
    {
        UpdateGoldText();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= goldIncreaseRate)
        {
            IncreaseGold();
            timer = 0f;
        }
    }

    void IncreaseGold()
    {
        currentGold += goldPerInterval;
        UpdateGoldText();
    }
    public void AddGold(double amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }
    void UpdateGoldText()
    {
        goldText.text = "  " + FormatGold(currentGold);
    }

    string FormatGold(double value)
    {
        if (value >= 1e9)
            return (value / 1e9).ToString("0.##") + "B";
        else if (value >= 1e6)
            return (value / 1e6).ToString("0.##") + "M";
        else if (value >= 1e3)
            return (value / 1e3).ToString("0.##") + "K";
        else
            return value.ToString("0");
    }
}
