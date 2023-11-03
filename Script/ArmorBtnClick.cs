using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBtnClick : MonoBehaviour
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
        if(num == 1 && playerMove.Gold >= 500)
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
            if(!flag)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
                playerMove.Gold -= 500;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.H1 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 2 && playerMove.Gold >= 1000)
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
                theInventory.H2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 3 && playerMove.Gold >= 2000)
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
                theInventory.H3 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 4 && playerMove.Gold >= 3000)
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
                theInventory.H4 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 5 && playerMove.Gold >= 4000)
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
                theInventory.H5 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 6 && playerMove.Gold >= 1000)
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
                theInventory.A1 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 7 && playerMove.Gold >= 2000)
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
                theInventory.A2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 8 && playerMove.Gold >= 4000)
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
                theInventory.A3 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 9 && playerMove.Gold >= 6000)
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
                theInventory.A4 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 10 && playerMove.Gold >= 8000)
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
                theInventory.A5 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 11 && playerMove.Gold >= 500)
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
                playerMove.Gold -= 500;
                ui.goldText.text = playerMove.Gold + "";
                theInventory.AcquireItem(item);
                theInventory.SH1 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 12 && playerMove.Gold >= 1000)
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
                theInventory.SH2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 13 && playerMove.Gold >= 2000)
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
                theInventory.SH3 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 14 && playerMove.Gold >= 3000)
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
                theInventory.SH4 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else if (num == 15 && playerMove.Gold >= 4000)
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
                theInventory.SH5 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
    }
}
