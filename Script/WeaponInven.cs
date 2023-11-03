using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInven : MonoBehaviour
{
    public static bool WeaponyActivated = false;

    // �ʿ��� ������Ʈ
    [SerializeField]
    private GameObject go_InventoryBase;

    void Update()
    {
    }

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

}
