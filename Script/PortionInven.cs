using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortionInven : MonoBehaviour
{
    public static bool PortionInvenActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;

    public void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }
}
