using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorInven : MonoBehaviour
{
    public static bool ArmorActivated = false;

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
    public void GetArmor(int num)
    {
        if(num == 0)
        {

        }
    }
}
