using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelperManager : MonoBehaviour
{
    public GoldAdd goldAdd; // GoldAdd ��ũ��Ʈ ����
    public List<Helper> helpers; // ����� ����Ʈ
    public Text[] helperDescriptions; // ����� ���� �ؽ�Ʈ �迭
    public Button[] actionButtons; // ����/���׷��̵� ��ư �迭
    public Text[] actionButtonTexts; // ��ư �ؽ�Ʈ �迭

    void Start()
    {
        for (int i = 0; i < helpers.Count; i++)
        {
            int index = i; // Capture the current index for the delegate
            actionButtons[i].onClick.AddListener(() => OnActionButtonClick(index));
            UpdateUI(index);
        }
    }

    void Update()
    {
        for (int i = 0; i < helpers.Count; i++)
        {
            UpdateUI(i);
        }
    }

    void UpdateUI(int index)
    {
        Helper helper = helpers[index];
        double currentGold = goldAdd.CurrentGold;

        if (!helper.isPurchased)
        {
            actionButtonTexts[index].text = "Buy";
            actionButtons[index].interactable = currentGold >= helper.buyCost;
            helperDescriptions[index].text = $"Buy Cost : {helper.buyCost} gold.";
        }
        else
        {
            actionButtonTexts[index].text = "Upgrade";
            actionButtons[index].interactable = currentGold >= helper.upgradeCost;
            helperDescriptions[index].text = $"Upgrade Cost : {helper.upgradeCost} gold.";
        }
    }

    void OnActionButtonClick(int index)
    {
        Helper helper = helpers[index];
        double currentGold = goldAdd.CurrentGold;

        if (!helper.isPurchased && currentGold >= helper.buyCost)
        {
            PurchaseHelper(index);
        }
        else if (helper.isPurchased && currentGold >= helper.upgradeCost)
        {
            UpgradeHelper(index);
        }
    }

    void PurchaseHelper(int index)
    {
        Helper helper = helpers[index];
        goldAdd.AddGold(-helper.buyCost); // ��带 ����
        helper.instance = Instantiate(helper.helperPrefab, helper.spawnPoint.position, helper.spawnPoint.rotation);
        helper.isPurchased = true;
        UpdateUI(index);
    }

    void UpgradeHelper(int index)
    {
        Helper helper = helpers[index];
        goldAdd.AddGold(-helper.upgradeCost); // ��带 ����
        // ����� ���׷��̵� ���� �߰� (��: ���� ����, �ɷ� ��� ��)
        UpdateUI(index);
    }
}
