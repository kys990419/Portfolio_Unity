using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public bool isClicked = false; // 스위치가 클릭되었는지 여부

    private void OnMouseDown()
    {
        if (!isClicked)
        {
            // 스위치가 처음 클릭된 경우에만 올바른 동작으로 처리
            isClicked = true;
            // 여기에 올바른 동작을 수행했을 때의 처리를 추가할 수 있습니다.
            Debug.Log("Button clicked! Correct action!");
        }
    }
}
