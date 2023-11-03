using System.Collections;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    Camera mainCamera;
    Vector3 camerPos;
    [SerializeField]
    [Range(0.01f, 0.1f)] float shakeRange = 0.05f;
    [SerializeField]
    float duration = 1.5f;

    private void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    public void Shake()
    {
        camerPos = mainCamera.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", duration);
    }

    void StartShake()
    {
        float cameraPosX = Random.value * shakeRange * 3 - shakeRange;
        float cameraPosY = Random.value * shakeRange * 3 - shakeRange;
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x += cameraPosX;
        cameraPos.y += cameraPosY;
        mainCamera.transform.position = cameraPos;
    }
    void StopShake()
    {
        CancelInvoke("StartShake");
        mainCamera.transform.position = camerPos;
    }
}