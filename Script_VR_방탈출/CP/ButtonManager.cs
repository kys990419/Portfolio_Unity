using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button[] buttons; // 버튼들의 배열
    public Color[] buttonColors; // 각 버튼에 할당할 색상들의 배열

    private void Start()
    {
        // 각 버튼에 대해 클릭 이벤트 설정과 색상 할당
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i; // 클로저에서 사용하기 위해 인덱스를 저장

            // 버튼 클릭 이벤트 설정
            buttons[i].onClick.AddListener(() => HandleButtonClick(buttonIndex));

            // 버튼에 색상 할당
            Image buttonImage = buttons[i].image;
            buttonImage.color = buttonColors[i];
        }
    }

    private void HandleButtonClick(int buttonIndex)
    {
        UserInput userInput = GetComponent<UserInput>();
        if (userInput != null)
        {
            Button clickedButton = buttons[buttonIndex];
            Image buttonImage = clickedButton.image;
            Color buttonColor = buttonImage.color;
            userInput.AddToUserInputPattern(buttonColor);
        }
    }
}
