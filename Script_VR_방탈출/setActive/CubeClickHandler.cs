using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    public GameObject targetObject1; // 활성화/비활성화할 오브젝트
    public GameObject targetObject2;
    private int clickCount = 0; // 클릭 횟수

    private void OnMouseDown()
    {
        clickCount++;

        if (clickCount == 1 && targetObject1 != null)
        {
            bool isActive1 = targetObject1.activeSelf;
            targetObject1.SetActive(!isActive1);
        }
        else if (clickCount == 2 && targetObject2 != null)
        {
            bool isActive2 = targetObject2.activeSelf;
            targetObject2.SetActive(!isActive2);
        }
        if(clickCount == 2)
        {
            clickCount = 0;
        }
    }
}
