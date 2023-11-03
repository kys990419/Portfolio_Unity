using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternManager : MonoBehaviour
{
    public List<GameObject> patternObjects; // 스위치, 레버, 문, 열쇠 등의 오브젝트를 저장할 리스트
    public GameObject buttonClick; // 버튼 클릭 오브젝트

    private List<int> patternSequence; // 생성된 패턴의 순서를 저장할 리스트
    private int currentIndex; // 현재 플레이어가 진행해야 할 패턴의 인덱스
    private bool allPatternsClear = false; // 모든 패턴이 클리어되었는지 여부

    void Start()
    {
        GeneratePattern(); // 패턴 생성
        PlayPattern(); // 생성된 패턴 실행
        buttonClick = GameObject.FindObjectOfType<ButtonClick>()?.gameObject;

        if (buttonClick != null)
        {
            Debug.Log("buttonClick is not null");
        }
        else
        {
            Debug.LogError("ButtonClick script not found!");
        }
    }


    void GeneratePattern()
    {
        patternSequence = new List<int>();

        for (int i = 0; i < patternObjects.Count; i++)
        {
            patternSequence.Add(i);
        }
    }

    void PlayPattern()
    {
        currentIndex = 0;
        StartCoroutine(PlayPatternCoroutine());
    }

    IEnumerator PlayPatternCoroutine()
    {
        foreach (int index in patternSequence)
        {
            GameObject patternObject = patternObjects[index];

            // 패턴 오브젝트를 활성화하여 플레이어에게 보여줌
            Debug.Log("this is : " + patternObject);
            patternObject.SetActive(true);

            // 패턴 오브젝트에 대한 입력을 대기
            yield return WaitForPlayerInput(patternObject);

            // 패턴 오브젝트를 비활성화하여 플레이어에게 가려줌
            patternObject.SetActive(false);

            currentIndex++;

            if (currentIndex >= patternObjects.Count)
            {
                // 모든 패턴이 클리어되었음을 설정
                allPatternsClear = true;
                Debug.Log("All patterns cleared!");
                yield break;
            }
        }
    }

    IEnumerator WaitForPlayerInput(GameObject patternObject)
    {
        bool inputReceived = false;

        if (patternObject == buttonClick)
        {
            patternObject.SetActive(true);

            while (!inputReceived)
            {
                // 버튼 클릭이 완료된 경우
                if (buttonClick != null && buttonClick.GetComponent<ButtonClick>() != null && buttonClick.GetComponent<ButtonClick>().isClicked)
                {
                    inputReceived = true;
                    Debug.Log("Button Pattern Cleared!");

                    // 슬라이더 패턴 활성화
                    int nextIndex = (currentIndex + 1) % patternObjects.Count;
                    GameObject nextPatternObject = patternObjects[nextIndex];
                    if (nextPatternObject.GetComponent<SliderPattern>() != null)
                    {
                        nextPatternObject.SetActive(true);
                        Debug.Log("Slider Pattern Activated!");

                        // 슬라이더 패턴 클리어 대기
                        yield return WaitForSliderPattern(nextPatternObject);
                    }
                }

                yield return null;
            }
        }
        else if (patternObject.GetComponent<SliderPattern>() != null)
        {
            // 슬라이더 패턴이 패턴 오브젝트인 경우
            SliderPattern sliderPattern = patternObject.GetComponent<SliderPattern>();
            patternObject.SetActive(true);

            yield return WaitForSliderPattern(patternObject);

            // 슬라이더 패턴 클리어 후에만 다음 패턴으로 진행
            if (sliderPattern.IsPatternCompleted())
            {
                Debug.Log("Slider Pattern Cleared!");
            }
            else
            {
                Debug.Log("Slider Pattern Failed! Restarting pattern sequence.");
                currentIndex = 0;
            }
        }

        patternObject.SetActive(false);
    }


    IEnumerator WaitForSliderPattern(GameObject patternObject)
    {
        SliderPattern sliderPattern = patternObject.GetComponent<SliderPattern>();

        while (!sliderPattern.IsPatternCompleted())
        {
            yield return null;
        }

        patternObject.SetActive(false);
    }
}
