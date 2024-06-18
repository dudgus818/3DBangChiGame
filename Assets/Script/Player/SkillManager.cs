using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour
{
    public GoldAdd goldAdd; // GoldAdd ��ũ��Ʈ ����
    public PlayerStats playerStats; // PlayerStats ��ũ��Ʈ ����
    public List<Skill> skills; // ��ų ����Ʈ
    public Text[] skillDescriptions; // ��ų ���� �ؽ�Ʈ �迭
    public Button[] skillButtons; // ��ų ��ư �迭
    public Text[] skillButtonTexts; // ��ư �ؽ�Ʈ �迭
    public Transform skillLayoutGroup; // ��ų �������� �߰��� ���̾ƿ� �׷�

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
        goldAdd.AddGold(-skill.buyCost); // ��带 ����
        skill.isPurchased = true;
        AddSkillToUI(skill);
        UpdateUI(index);
    }

    void UpgradeSkill(int index)
    {
        Skill skill = skills[index];
        goldAdd.AddGold(-skill.upgradeCost); // ��带 ����
        // ��ų ���׷��̵� ���� �߰� (��: ���� ����, �ɷ� ��� ��)
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
                Destroy(skill.instance); // ������ ������ �ν��Ͻ��� ������ ����
            }
            skill.instance = Instantiate(skill.skillPrefab, skill.spawnPoint.position, skill.spawnPoint.rotation);
            SkillEffect skillEffect = skill.instance.GetComponent<SkillEffect>();
            if (skillEffect != null)
            {
                skillEffect.particlePrefab = skill.particlePrefab; // ��ƼŬ ������ ����
                skillEffect.Activate(); // ��ų ȿ�� Ȱ��ȭ
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
