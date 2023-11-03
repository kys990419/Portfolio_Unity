using UnityEngine;
using UnityEngine.UI;

public class PatternDisplay : MonoBehaviour
{
    public Image[] patternSlots; // 패턴을 표시할 UI 이미지 슬롯
    public float displayDuration = 1f; // 패턴 표시 시간

    private Color[] pattern; // 표시할 패턴

    public void DisplayPattern(Color[] pattern)
    {
        this.pattern = pattern;
        StartCoroutine(DisplayPatternCoroutine());
    }

    private System.Collections.IEnumerator DisplayPatternCoroutine()
    {
        for (int i = 0; i < pattern.Length; i++)
        {
            patternSlots[i].color = pattern[i];
            yield return new WaitForSeconds(displayDuration);
            patternSlots[i].color = Color.white; // 표시를 지우기 위해 기본 색상으로 변경
        }
    }
}
