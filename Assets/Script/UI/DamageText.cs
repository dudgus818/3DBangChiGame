using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour
{
    public Text damageText;
    private Vector3 randomOffset;

    public void SetText(int damage)
    {
        damageText.text = damage.ToString();
        randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1.5f), 0);
        StartCoroutine(FadeAndDestroy());
    }

    private IEnumerator FadeAndDestroy()
    {
        float duration = 1f;
        float elapsed = 0f;
        Color originalColor = damageText.color;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            damageText.color = Color.Lerp(originalColor, Color.clear, elapsed / duration);
            transform.position += randomOffset * Time.deltaTime; // 텍스트 이동
            yield return null;
        }

        Destroy(gameObject);
    }
}
