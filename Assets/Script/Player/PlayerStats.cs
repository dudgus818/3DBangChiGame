using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int mana = 50;
    public int maxMana = 100; // ���� �ִ밪
    public int attackPower = 10;

    private int healthUpgradeCost = 50;
    private int manaUpgradeCost = 30;
    private int attackPowerUpgradeCost = 40;

    public Text healthText;
    public Text manaText;
    public Text attackPowerText;
    public Button healthUpgradeButton;
    public Button manaUpgradeButton;
    public Button attackPowerUpgradeButton;

    public Text healthUpgradeCostText;
    public Text manaUpgradeCostText;
    public Text attackPowerUpgradeCostText;

    public Slider healthSlider;
    public Slider manaSlider;

    private GoldAdd goldAdd;

    void Start()
    {
        goldAdd = FindObjectOfType<GoldAdd>();
        UpdateUI();
        StartCoroutine(RegenerateMana()); // ���� ȸ�� �ڷ�ƾ ����
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + health;
        manaText.text = "Mana: " + mana;
        attackPowerText.text = "Attack Power: " + attackPower;

        healthUpgradeCostText.text = "  " + healthUpgradeCost;
        manaUpgradeCostText.text = "  " + manaUpgradeCost;
        attackPowerUpgradeCostText.text = "  " + attackPowerUpgradeCost;

        healthUpgradeButton.interactable = goldAdd.CurrentGold >= healthUpgradeCost;
        manaUpgradeButton.interactable = goldAdd.CurrentGold >= manaUpgradeCost;
        attackPowerUpgradeButton.interactable = goldAdd.CurrentGold >= attackPowerUpgradeCost;

        healthSlider.maxValue = health;
        healthSlider.value = health;

        manaSlider.maxValue = maxMana; // ���� �����̴��� �ִ밪�� maxMana�� ����
        manaSlider.value = mana;
    }

    public void UpgradeHealth()
    {
        if (goldAdd.CurrentGold >= healthUpgradeCost)
        {
            goldAdd.AddGold(-healthUpgradeCost);
            health += 10;
            healthUpgradeCost = Mathf.CeilToInt(healthUpgradeCost * 1.2f); // ���׷��̵� ��� ����
            UpdateUI();
        }
    }

    public void UpgradeMana()
    {
        if (goldAdd.CurrentGold >= manaUpgradeCost)
        {
            goldAdd.AddGold(-manaUpgradeCost);
            maxMana += 10; // ���� �ִ밪 ����
            mana += 5;
            manaUpgradeCost = Mathf.CeilToInt(manaUpgradeCost * 1.2f); // ���׷��̵� ��� ����
            UpdateUI();
        }
    }

    public void UpgradeAttackPower()
    {
        if (goldAdd.CurrentGold >= attackPowerUpgradeCost)
        {
            goldAdd.AddGold(-attackPowerUpgradeCost);
            attackPower += 2;
            attackPowerUpgradeCost = Mathf.CeilToInt(attackPowerUpgradeCost * 1.2f); // ���׷��̵� ��� ����
            UpdateUI();
        }
    }

    public bool ConsumeMana(int amount)
    {
        if (mana >= amount)
        {
            mana -= amount;
            UpdateUI();
            return true;
        }
        return false;
    }

    private IEnumerator RegenerateMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (mana < maxMana)
            {
                mana = Mathf.Min(mana + 10, maxMana); // ������ 10�� ȸ��, �ִ밪�� ���� �ʵ���
                UpdateUI();
            }
        }
    }
}

