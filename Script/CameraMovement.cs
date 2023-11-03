using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public PlayerMove playerMove;
    //public Texture2D curImg;
    public Transform objectTofollow;
    public float followSpeed = 10f;
    public float sensitivity = 100f;
    public float clamAngle = 70f;
    public float smoothness = 10f;

    private float rotX;
    private float rotY;

    public Transform realCamera;
    public Vector3 dirNormalized;
    public Vector3 finalDir;
    public float minDistance;
    public float maxDistance;
    public float finalDistance;


    void Start()
    {
        //Cursor.SetCursor(curImg, Vector3.zero, CursorMode.ForceSoftware);

        rotX = transform.localRotation.eulerAngles.x;
        rotY = transform.localRotation.eulerAngles.y;

        dirNormalized = realCamera.localPosition.normalized;
        finalDistance = realCamera.localPosition.magnitude;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    
    void Update()
    {
        if (!WeaponInven.WeaponyActivated && !PortionInven.PortionInvenActivated && !ArmorInven.ArmorActivated && !Inventory.inventoryActivated 
            && !SetSkillInven.SkillSetActivated && !StatInven.StatInvenActivated && !SettingInven.SettingActivated && playerMove.isQuest == false)
        {
            rotX += -(Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime;
            rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clamAngle, clamAngle);
            Quaternion rot = Quaternion.Euler(rotX, rotY, 0);
            transform.rotation = rot;
        }
    }

    void LateUpdate() 
    {
        transform.position = Vector3.MoveTowards(transform.position, objectTofollow.position, followSpeed * Time.deltaTime);
        finalDir = transform.TransformPoint(dirNormalized * maxDistance);

        RaycastHit hit;

        if(Physics.Linecast(transform.position, finalDir, out hit))
        {
            finalDistance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            finalDistance = maxDistance;
        }
        realCamera.localPosition = Vector3.Lerp(realCamera.localPosition, dirNormalized * finalDistance, Time.deltaTime * smoothness);
    }

    public void Sensetive(float num)
    {   
        //100 1->200 0.5 - l. 100
        sensitivity = num * 200f;
    }

}
