using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderPattern : MonoBehaviour
{
    public Slider slider; // 슬라이더 컴포넌트

    private bool patternCompleted; // 패턴 완료 여부

    void Start()
    {
        patternCompleted = false;
    }

    void Update()
    {
        // 슬라이더 값이 최대값 이상인 경우 패턴 완료
        if (slider.value >= slider.maxValue)
        {
            patternCompleted = true;
        }
    }

    public bool IsPatternCompleted()
    {
        return patternCompleted;
    }
}
