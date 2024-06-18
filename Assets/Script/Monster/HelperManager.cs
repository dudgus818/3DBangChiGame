using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelperManager : MonoBehaviour
{
    public GoldAdd goldAdd; // GoldAdd 스크립트 참조
    public List<Helper> helpers; // 도우미 리스트
    public Text[] helperDescriptions; // 도우미 설명 텍스트 배열
    public Button[] actionButtons; // 구매/업그레이드 버튼 배열
    public Text[] actionButtonTexts; // 버튼 텍스트 배열

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
        goldAdd.AddGold(-helper.buyCost); // 골드를 차감
        helper.instance = Instantiate(helper.helperPrefab, helper.spawnPoint.position, helper.spawnPoint.rotation);
        helper.isPurchased = true;
        UpdateUI(index);
    }

    void UpgradeHelper(int index)
    {
        Helper helper = helpers[index];
        goldAdd.AddGold(-helper.upgradeCost); // 골드를 차감
        // 도우미 업그레이드 로직 추가 (예: 레벨 증가, 능력 향상 등)
        UpdateUI(index);
    }
}
