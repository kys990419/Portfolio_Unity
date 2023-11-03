using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingInven : MonoBehaviour
{
    [SerializeField]
    private PlayerMove PlayerMove;
    public static bool SettingActivated = false;
    [SerializeField]
    private GameObject go_InventoryBase;
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[29]);
            SettingActivated = !SettingActivated;

            if (SettingActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }
    void Update()
    {
        TryOpenInventory();
    }
    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }
    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }
}
