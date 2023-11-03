using UnityEngine;
using UnityEngine.UI;

public class NumberPad : MonoBehaviour
{
    public Text inputText; // 입력된 숫자를 표시할 UI 텍스트

    private string currentInput = ""; // 현재 입력된 숫자

    // 숫자 패드 버튼 클릭 시 호출될 함수
    public void OnNumberButtonClick(Button button)
    {
        Debug.Log("gogo");
        string buttonText = button.GetComponentInChildren<Text>().text;
        currentInput += buttonText;
        inputText.text = currentInput;
    }

    // Enter 버튼 클릭 시 호출될 함수
    public void OnEnterButtonClick()
    {
        Debug.Log("Current Input: " + currentInput);
        if (currentInput == "1234")
        {
            Debug.Log("Clear!");
            currentInput = "";
            inputText.text = currentInput;
        }
        else
        {
            Debug.Log("Retry!");

        }
    }
    public void OnDelteButtonClick()
    {
        currentInput = "";
        inputText.text = currentInput;
    }
}
