using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldAdd : MonoBehaviour
{
    public Text goldText; // UI�� ��带 ǥ���� �ؽ�Ʈ
    public float goldIncreaseRate = 1f; // ��� ���� �ֱ� (�� ����)
    public int goldPerInterval = 10; // �ֱ⸶�� ������ ��� ��

    private double currentGold = 0; // ���� ���
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
