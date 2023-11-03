using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBtnClick : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;
    public PlayerMove playerMove;
    public UI ui;
    public Item item;
    public int num;
    bool flag;
    public void GetWeapon()
    {
        if (num == 1 && playerMove.Gold >= 1000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {  
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {   
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 1000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S1 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 2 && playerMove.Gold >= 2000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 2000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 3 && playerMove.Gold >= 3000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 3000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S3 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 4 && playerMove.Gold >= 4000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 4000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S4 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 5 && playerMove.Gold >= 5000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 5000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S5 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 6 && playerMove.Gold >= 6000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 6000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S6 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 7 && playerMove.Gold >= 10000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 10000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.S7 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 8 && playerMove.Gold >= 1000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 1000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.M1 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 9 && playerMove.Gold >= 2000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 2000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.M2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 10 && playerMove.Gold >= 3000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 3000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.M3 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 11 && playerMove.Gold >= 4000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 4000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.M4 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        if (num == 12 && playerMove.Gold >= 8000)
        {
            for (int i = 0; i < theInventory.slots.Length; i++)
            {
                if (theInventory.slots[i].item != null)
                {
                    if (theInventory.slots[i].item.itemName == item.itemName)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 8000;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.M5 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
    }
}
