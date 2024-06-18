using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public GoldAdd goldAdd; // GoldAdd 스크립트 참조
    public PlayerStats playerStats; // PlayerStats 스크립트 참조
    public List<Skill> skills; // 스킬 리스트
    public Text[] skillDescriptions; // 스킬 설명 텍스트 배열
    public Button[] skillButtons; // 스킬 버튼 배열
    public Text[] skillButtonTexts; // 버튼 텍스트 배열
    public Transform skillLayoutGroup; // 스킬 아이콘이 추가될 레이아웃 그룹

    void Start()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            int index = i; // Capture the current index for the delegate
            skillButtons[i].onClick.AddListener(() => OnSkillButtonClick(index));
            UpdateUI(index);
        }
    }

    void Update()
    {
        for (int i = 0; i < skills.Count; i++)
        {
            UpdateUI(i);
        }
    }

    void UpdateUI(int index)
    {
        Skill skill = skills[index];
        double currentGold = goldAdd.CurrentGold;

        if (!skill.isPurchased)
        {
            skillButtonTexts[index].text = "Buy";
            skillButtons[index].interactable = currentGold >= skill.buyCost;
            skillDescriptions[index].text = $"Buy Cost : {skill.buyCost} gold.";
        }
        else
        {
            skillButtonTexts[index].text = "Upgrade";
            skillButtons[index].interactable = currentGold >= skill.upgradeCost;
            skillDescriptions[index].text = $"Upgrade Cost : {skill.upgradeCost} gold.";
        }
    }

    void OnSkillButtonClick(int index)
    {
        Skill skill = skills[index];
        double currentGold = goldAdd.CurrentGold;

        if (!skill.isPurchased && currentGold >= skill.buyCost)
        {
            PurchaseSkill(index);
        }
        else if (skill.isPurchased && currentGold >= skill.upgradeCost)
        {
            UpgradeSkill(index);
        }
    }

    void PurchaseSkill(int index)
    {
        Skill skill = skills[index];
        goldAdd.AddGold(-skill.buyCost); // 골드를 차감
        skill.isPurchased = true;
        AddSkillToUI(skill);
        UpdateUI(index);
    }

    void UpgradeSkill(int index)
    {
        Skill skill = skills[index];
        goldAdd.AddGold(-skill.upgradeCost); // 골드를 차감
        // 스킬 업그레이드 로직 추가 (예: 레벨 증가, 능력 향상 등)
        UpdateUI(index);
    }

    void AddSkillToUI(Skill skill)
    {
        if (skill.skillIconPrefab == null)
        {
            Debug.LogError("SkillIconPrefab is null for skill: " + skill.name);
            return;
        }
        if (skillLayoutGroup == null)
        {
            Debug.LogError("SkillLayoutGroup is not assigned in SkillManager.");
            return;
        }

        GameObject skillIconObj = Instantiate(skill.skillIconPrefab, skillLayoutGroup);
        Button skillButton = skillIconObj.GetComponent<Button>();
        if (skillButton != null)
        {
            skillButton.onClick.AddListener(() => ShowSkillEffect(skill));
        }
        else
        {
            Debug.LogError("No Button component found on SkillIconPrefab for skill: " + skill.name);
        }
    }

    public void ShowSkillEffect(Skill skill)
    {
        Debug.Log("Skill icon clicked: " + skill.name);
        if (playerStats.ConsumeMana(skill.manaCost))
        {
            if (skill.instance != null)
            {
                Destroy(skill.instance); // 이전에 생성된 인스턴스가 있으면 제거
            }
            skill.instance = Instantiate(skill.skillPrefab, skill.spawnPoint.position, skill.spawnPoint.rotation);
            SkillEffect skillEffect = skill.instance.GetComponent<SkillEffect>();
            if (skillEffect != null)
            {
                skillEffect.particlePrefab = skill.particlePrefab; // 파티클 프리팹 설정
                skillEffect.Activate(); // 스킬 효과 활성화
            }
            else
            {
                Debug.LogError("No SkillEffect component found on SkillPrefab for skill: " + skill.name);
            }
        }
        else
        {
            Debug.Log("Not enough mana to use skill: " + skill.name);
        }
    }
}
