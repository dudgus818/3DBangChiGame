using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int baseHealth = 100; // 기본 체력
    private int currentHealth; // 현재 체력
    public Slider healthSlider; // 체력을 표시할 UI 슬라이더
    public GameObject damageTextPrefab; // 데미지 텍스트 프리팹
    public int level = 1; // 적의 초기 레벨

    void Start()
    {
        currentHealth = baseHealth * level;
        UpdateHealthUI();
    }

    // 적이 데미지를 받을 때 호출되는 메소드
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();
        ShowDamageText(damage);

        if (currentHealth <= 0)
        {
            LevelUp();
        }
    }

    // 체력 UI를 업데이트하는 메소드
    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / (baseHealth * level);
    }

    // 데미지 텍스트를 표시하는 메소드
    void ShowDamageText(int damage)
    {
        GameObject textObject = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform);
        DamageText damageText = textObject.GetComponent<DamageText>();
        damageText.SetText(damage);
    }

    // 적의 레벨을 증가시키고 체력을 회복하는 메소드
    void LevelUp()
    {
        level++;
        currentHealth = baseHealth * level;
        UpdateHealthUI();
    }
}
