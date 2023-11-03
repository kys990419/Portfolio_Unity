using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCName : MonoBehaviour
{
    Animation anim;
    public Camera cam;
    public Transform NPCname;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(NPCname.position - cam.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(NPCname.rotation, q_hp, 200).eulerAngles;
        NPCname.rotation = Quaternion.Euler(0, hp_angle.y, 0);
    }
}
