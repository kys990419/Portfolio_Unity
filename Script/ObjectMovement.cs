using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도

    void Update()
    {
        // 수평 방향 입력
        float horizontalInput = Input.GetAxis("Horizontal");
        // 수직 방향 입력
        float verticalInput = Input.GetAxis("Vertical");

        // 이동 방향 계산
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        movement.Normalize(); // 이동 방향 벡터를 정규화하여 일정한 속도로 이동하도록 합니다.

        // 이동 처리
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
