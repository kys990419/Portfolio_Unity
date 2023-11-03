using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camchagne : MonoBehaviour
{
    public Camera MainCamera;
    public Camera[] Npc1Camera;

    public void ShowNpc1(int num)
    {
        Npc1Camera[num].enabled = true;
        MainCamera.enabled = false;
    }

    public void ShowMain(int num) 
    {
        MainCamera.enabled = true;
        Npc1Camera[num].enabled = false;
    }
}
