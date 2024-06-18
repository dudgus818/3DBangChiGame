using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int baseHealth = 100; // �⺻ ü��
    private int currentHealth; // ���� ü��
    public Slider healthSlider; // ü���� ǥ���� UI �����̴�
    public GameObject damageTextPrefab; // ������ �ؽ�Ʈ ������
    public int level = 1; // ���� �ʱ� ����

    void Start()
    {
        currentHealth = baseHealth * level;
        UpdateHealthUI();
    }

    // ���� �������� ���� �� ȣ��Ǵ� �޼ҵ�
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

    // ü�� UI�� ������Ʈ�ϴ� �޼ҵ�
    void UpdateHealthUI()
    {
        healthSlider.value = (float)currentHealth / (baseHealth * level);
    }

    // ������ �ؽ�Ʈ�� ǥ���ϴ� �޼ҵ�
    void ShowDamageText(int damage)
    {
        GameObject textObject = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform);
        DamageText damageText = textObject.GetComponent<DamageText>();
        damageText.SetText(damage);
    }

    // ���� ������ ������Ű�� ü���� ȸ���ϴ� �޼ҵ�
    void LevelUp()
    {
        level++;
        currentHealth = baseHealth * level;
        UpdateHealthUI();
    }
}
