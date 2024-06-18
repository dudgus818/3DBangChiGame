using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLevelManager : MonoBehaviour
{
    public Slider levelSlider; // 레벨 게이지 슬라이더
    public Text levelText; // 플레이어 레벨 텍스트
    public float levelIncreaseRate = 1f; // 레벨 게이지 증가 주기 (초 단위)
    public float experiencePerInterval = 10f; // 주기마다 증가할 경험치 양
    public int maxLevel = 100; // 최대 레벨
    public float experienceMultiplier = 1.1f; // 경험치 증가율

    private int currentLevel = 1; // 현재 레벨
    private float currentExperience = 0f; // 현재 경험치
    private float experienceToNextLevel = 100f; // 다음 레벨까지 필요한 경험치

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
        experienceToNextLevel *= experienceMultiplier; // 레벨 업할 때마다 필요한 경험치를 증가시킴
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
