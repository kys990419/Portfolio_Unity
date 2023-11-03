using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private PlayerMove PlayerMove;
    public StatInven statInven;
    public static bool inventoryActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    [SerializeField]
    private GameObject go_SlotsParent;

    // 슬롯들.
    public Slot[] slots;
    public Slot swordSlot;
    public Slot magicSlot;
    public Slot AccSlot;
    public Slot HeadSlot;
    public Slot clothSlot;
    public Slot shoesSlot;

    public int preHeal;
    public int preMana;
    public int preAD;
    public int preAP;
    public int preDefense;
    public float preSpeed;
    public float prePortionRate;

    public bool S0 = true;
    public bool S1;
    public bool S2;
    public bool S3;
    public bool S4;
    public bool S5;
    public bool S6;
    public bool S7;
    public bool M0 = true;
    public bool M1;
    public bool M2;
    public bool M3;
    public bool M4;
    public bool M5;
    public bool H0 = true;
    public bool H1;
    public bool H2;
    public bool H3;
    public bool H4;
    public bool H5;
    public bool A0 = true;
    public bool A1;
    public bool A2;
    public bool A3;
    public bool A4;
    public bool A5;
    public bool SH0 = true;
    public bool SH1;
    public bool SH2;
    public bool SH3;
    public bool SH4;
    public bool SH5;
    public bool Acc1;
    public bool Acc2;
    public bool Portion1;
    public bool Portion2;

    public bool GoblinGirl;

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        //현재 플레이어가 끼고 있는 장비 넣기 스텟
        //preHeal = 1;
        //preMana = 1;
        //preAD = 1;
        //preAP = 1;
        //preDefense = 1;
        //preSpeed = 1;
        //prePortionRate = 0;
    }
    void Update()
    {
        TryOpenInventory();
    }
    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[29]);
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory();
            else
                CloseInventory();
        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }
    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item, int _count = 1)
    {
        if (Item.ItemType.Sword != _item.itemType || Item.ItemType.Magic != _item.itemType || Item.ItemType.Acees != _item.itemType || Item.ItemType.head != _item.itemType
            || Item.ItemType.cloth != _item.itemType || Item.ItemType.shoes != _item.itemType)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotCount(_count);
                        return;
                    }
                }
            }
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                return;
            }
        }
    }
    public void SwordChange(Item item,Sprite _swordImg, int weaponindex, int damge, float speed, int health)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = swordSlot.itemImage.color;
        color.a = 1;
        swordSlot.itemImage.color = color;
        swordSlot.itemImage.sprite = _swordImg;
        PlayerMove.ChangeWeaponindex(weaponindex);
        swordSlot.AddItemSword(item, 1);
        PlayerMove.EqipAD += (damge - PlayerMove.EqipAD);
        statInven.ChangeWeaponUpdateStat();
    }
    public void MagicChange(Item item, Sprite _maigcImg, int weaponindex ,int damge, float speed, int Mana)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = magicSlot.itemImage.color;
        color.a = 1;
        magicSlot.itemImage.color = color;
        magicSlot.itemImage.sprite = _maigcImg;
        PlayerMove.ChangeWeaponindex(weaponindex);
        magicSlot.AddItemMagic(item, 1);

        PlayerMove.EqipAP += (damge - PlayerMove.EqipAP);
        statInven.ChangeWeaponUpdateStat();
    }
    public void AccChange(Item item, Sprite _maigcImg, int weaponindex, int damge, int PortionPlus)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = AccSlot.itemImage.color;
        color.a = 1;
        if (AccSlot.item != null && AccSlot.item.itemName == "체력 목걸이") PlayerMove.Acc1 = false;
        if (AccSlot.item != null && AccSlot.item.itemName == "마나 목걸이") PlayerMove.Acc2 = false;

        AccSlot.itemImage.color = color;
        AccSlot.itemImage.sprite = _maigcImg;
        AccSlot.AddItemAcc(item, 1);
        if (item.itemName == "체력 목걸이") PlayerMove.Acc1 = true;
        if (item.itemName == "마나 목걸이") PlayerMove.Acc2 = true;
    }
    public void headChange(Item item, Sprite _headImg, int defense)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = HeadSlot.itemImage.color;
        color.a = 1;
        HeadSlot.itemImage.color = color;
        HeadSlot.itemImage.sprite = _headImg;
        HeadSlot.AddItemSword(item, 1);
        PlayerMove.EqipDefense += (defense - PlayerMove.EqipDefense);
        statInven.ChangeWeaponUpdateStat();
    }
    public void clothChange(Item item, Sprite _clothImg, int health)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = clothSlot.itemImage.color;
        color.a = 1;
        clothSlot.itemImage.color = color;
        clothSlot.itemImage.sprite = _clothImg;
        clothSlot.AddItemSword(item, 1);
        PlayerMove.EqipHealth += (health - PlayerMove.EqipHealth);
        statInven.ChangeWeaponUpdateStat();
    }
    public void shoesChange(Item item, Sprite _shoseImg, float speed)
    {
        SoundManager.instace.SFXPlay("Melee", PlayerMove.clip[28]);
        Color color = shoesSlot.itemImage.color;
        color.a = 1;
        shoesSlot.itemImage.color = color;
        shoesSlot.itemImage.sprite = _shoseImg;
        shoesSlot.AddItemSword(item, 1);
        PlayerMove.Eqipspeed += (speed - PlayerMove.Eqipspeed);
        statInven.ChangeWeaponUpdateStat();
    }
}