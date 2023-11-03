using UnityEngine;
using UnityEngine.UI;

public class PatternGenerator : MonoBehaviour
{
    // public Color[] colors; // 사용할 색상 배열
    public int patternLength = 4; // 패턴의 길이
    private Color[] generatedPattern; // 생성된 패턴
    public Text messageText; // 입력 메시지를 표시할 UI Text 컴포넌트

    private void Start()
    {
        GeneratePattern();
        DisplayGeneratedPattern();
        ShowInputMessage();
    }
    public Color[] GetGeneratedPattern()
    {
        return generatedPattern;
    }
    private void GeneratePattern()
    {
        generatedPattern = new Color[patternLength];

        // 지정된 몇 가지 색상 배열
        Color[] specifiedColors = new Color[]
        {
        Color.green,
        Color.red,
        Color.blue,
        Color.yellow
        };

        for (int i = 0; i < patternLength; i++)
        {
            // 지정된 색상 배열에서 랜덤한 색상 선택
            int randomIndex = Random.Range(0, specifiedColors.Length);
            Color randomColor = specifiedColors[randomIndex];
            randomColor.a = 1f; // 알파 값을 1로 설정하여 투명하지 않게 함
            generatedPattern[i] = randomColor;
        }
        if (generatedPattern[3] != null)
        {
            Debug.Log("Push Button!");
        }
        Debug.Log("Generated Pattern: " + string.Join(", ", generatedPattern));
    }

    private void DisplayGeneratedPattern()
    {
        PatternDisplay patternDisplay = FindObjectOfType<PatternDisplay>();
        if (patternDisplay != null)
        {
            patternDisplay.DisplayPattern(generatedPattern);
        }
        else
        {
            Debug.LogWarning("PatternDisplay not found in the scene.");
        }
    }
    private void ShowInputMessage()
    {
        if (messageText != null)
        {
            messageText.text = "Please input your pattern";
        }
    }
}
