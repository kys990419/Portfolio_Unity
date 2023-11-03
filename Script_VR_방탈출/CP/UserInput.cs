using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    public Color[] userInputPattern; // 사용자 입력 패턴

    private void ComparePatterns()
    {
        Debug.Log("Call This Function: ComparePattern");
        PatternGenerator patternGenerator = FindObjectOfType<PatternGenerator>();
        if (patternGenerator != null)
        {
            Color[] generatedPattern = patternGenerator.GetGeneratedPattern(); // 생성된 패턴을 가져옴

            if (userInputPattern.Length == generatedPattern.Length)
            {
                bool isCorrect = true;
                Debug.Log("user: " + userInputPattern.Length);
                Debug.Log("Generator: " + generatedPattern.Length);

                for (int i = 0; i < userInputPattern.Length; i++)
                {
                    if (!ApproximatelyEqual(userInputPattern[i], generatedPattern[i]))
                    {
                        isCorrect = false;
                        Debug.Log("isCorrect index is " + i);
                        Debug.Log("userInput is: " + userInputPattern[i]);
                        Debug.Log("generator is: " + generatedPattern[i]);
                        break;
                    }
                }

                if (isCorrect)
                {
                    Debug.Log("Pattern is correct!");
                }
                else
                {
                    Debug.Log("Pattern is incorrect!");
                }
            }
            else
            {
                Debug.Log("Pattern length does not match!");
            }
        }
    }
    private bool ApproximatelyEqual(Color a, Color b, float tolerance = 0.1f)
    {
        return Mathf.Abs(a.r - b.r) <= tolerance &&
               Mathf.Abs(a.g - b.g) <= tolerance &&
               Mathf.Abs(a.b - b.b) <= tolerance &&
               Mathf.Abs(a.a - b.a) <= tolerance;
    }
    public void AddToUserInputPattern(Color color)
    {
        Debug.Log("Call This function!");

        if (userInputPattern != null)
        {
            Color[] updatedPattern = new Color[userInputPattern.Length + 1];

            for (int i = 0; i < userInputPattern.Length; i++)
            {
                updatedPattern[i] = userInputPattern[i];
            }

            updatedPattern[userInputPattern.Length] = color;

            userInputPattern = updatedPattern;

            if (userInputPattern.Length == 4)
            {
                ComparePatterns();
            }
        }
    }
    public void DeleteInputPattern()
    {
        userInputPattern = new Color[0];
        Debug.Log("Input pattern deleted!");
    }

}
