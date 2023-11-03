using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortionAccBtnClick : MonoBehaviour
{
    [SerializeField]
    private Inventory theInventory;
    [SerializeField]
    private PlayerMove playerMove;
    [SerializeField]
    private UI ui;

    public Item item;
    public int num;
    bool flag;

    public void GetWeapon()
    {   
        if (num == 1 && playerMove.Gold >= 200)
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
            playerMove.HealPortion++;
            ui.curHealNum(playerMove.HealPortion);
            playerMove.Gold -= 200;
            ui.goldText.text = playerMove.Gold + "";
            theInventory.AcquireItem(item);
            theInventory.Portion1 = true;
        }
        else if (num == 2 && playerMove.Gold >= 200)
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
            playerMove.ManaPortion++;
            ui.curManaNum(playerMove.ManaPortion);
            playerMove.Gold -= 200;
            ui.goldText.text = playerMove.Gold + "";
            theInventory.AcquireItem(item);
            theInventory.Portion2 = true;
        }
        else if (num == 3 && playerMove.Gold >= 3000)
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
                theInventory.Acc1 = true;
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
                theInventory.Acc2 = true;
            }
            else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
        else
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
        }
    }
}
