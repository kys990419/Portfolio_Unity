using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public Transform character;
    public float cameraDistance = 5f;
    public LayerMask collisionMask;

    private void LateUpdate()
    {
        Vector3 desiredCameraPos = character.position - transform.forward * cameraDistance;
        RaycastHit hit;

        if (Physics.Raycast(character.position, -transform.forward, out hit, cameraDistance, collisionMask))
        {
            desiredCameraPos = hit.point;
        }

        transform.position = desiredCameraPos;
        transform.LookAt(character);
    }
}