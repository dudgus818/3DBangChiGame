using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLevelManager : MonoBehaviour
{
    public Slider levelSlider; // ���� ������ �����̴�
    public Text levelText; // �÷��̾� ���� �ؽ�Ʈ
    public float levelIncreaseRate = 1f; // ���� ������ ���� �ֱ� (�� ����)
    public float experiencePerInterval = 10f; // �ֱ⸶�� ������ ����ġ ��
    public int maxLevel = 100; // �ִ� ����
    public float experienceMultiplier = 1.1f; // ����ġ ������

    private int currentLevel = 1; // ���� ����
    private float currentExperience = 0f; // ���� ����ġ
    private float experienceToNextLevel = 100f; // ���� �������� �ʿ��� ����ġ

    void Start()
    {
        UpdateLevelText();
        levelSlider.maxValue = experienceToNextLevel;
        levelSlider.value = currentExperience;
        StartCoroutine(IncreaseExperienceOverTime());
    }

    IEnumerator IncreaseExperienceOverTime()
    {
        while (currentLevel < maxLevel)
        {
            yield return new WaitForSeconds(levelIncreaseRate);
            IncreaseExperience(experiencePerInterval);
        }
    }

    void IncreaseExperience(float amount)
    {
        currentExperience += amount;
        if (currentExperience >= experienceToNextLevel)
        {
            currentExperience -= experienceToNextLevel;
            LevelUp();
        }
        UpdateLevelUI();
    }

    void LevelUp()
    {
        currentLevel++;
        experienceToNextLevel *= experienceMultiplier; // ���� ���� ������ �ʿ��� ����ġ�� ������Ŵ
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        levelText.text = "LV. " + currentLevel;
    }

    void UpdateLevelUI()
    {
        levelSlider.maxValue = experienceToNextLevel;
        levelSlider.value = currentExperience;
    }
}
