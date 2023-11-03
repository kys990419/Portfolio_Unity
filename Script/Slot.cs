using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler,  IPointerEnterHandler,IPointerExitHandler
{   //IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler,
    public Item item; // ȹ���� ������.
    public int itemCount; // ȹ���� �������� ����.
    public Image itemImage; // �������� �̹���.
    Color newColor;

    // �ʿ��� ������Ʈ.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    Inventory Inventory;
    private void Start()
    {
        Inventory = GetComponentInParent<Inventory>();
    }
    // �̹����� ���� ����.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    // ������ ȹ��
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Sword && item.itemType != Item.ItemType.Magic && item.itemType != Item.ItemType.Acees && item.itemType != Item.ItemType.head
            && item.itemType != Item.ItemType.cloth && item.itemType != Item.ItemType.shoes)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        { 
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }
    public void AddItemSword(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;
        text_Count.text = "0";
        go_CountImage.SetActive(false);

        SetColor(1);
    }
    public void AddItemMagic(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;
        text_Count.text = "0";
        go_CountImage.SetActive(false);

        SetColor(1);
    }
    public void AddItemAcc(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;
        text_Count.text = "0";
        go_CountImage.SetActive(false);

        SetColor(1);
    }

    // ������ ���� ����.
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }
    public void SetSlotCount2(Slot slot)
    {
        slot.text_Count.text = slot.itemCount.ToString();

        if (slot.itemCount <= 0)
            slot.ClearSlot();
    }

    // ���� �ʱ�ȭ.
    public void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }
    public void ClearSlot2(Slot slot)
    {
        slot.item = null;
        slot.itemCount = 0;
        slot.itemImage.sprite = null;
        slot.SetColor(0);

        slot.text_Count.text = "0";
        slot.go_CountImage.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            if (SetSkillInven.SkillSetActivated)
            {
                SkillInvenSlot.Skillinstance.ItemSlot = this;
                SkillInvenSlot.Skillinstance.Itemimg.sprite = item.itemImage; // ���ֺ���
                if (item.itemName == "ȸ�� ����" || item.itemName == "���� ��ǳ")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#4AFF00>" + item.rank + "</color>" + "�̻�";
                }
                if (item.itemName == "��� ����" || item.itemName == "���̽� ������")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FFAB00>" + item.rank + "</color>" + "�̻�";
                }
                if (item.itemName == "�ż�ȭ" || item.itemName == "����� ������ ��Ʈ����ũ")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FF00ED>" + item.rank + "</color>" + "�̻�";
                }
                if (item.itemName == "�� ��")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FF0000>" + item.rank + "</color>" + "�̻�";
                }

                SkillInvenSlot.Skillinstance.damge.text = "" + item.SkillInfo;
                int dmg = item.skillDamge + 50;
                int dmg2 = item.skillDamge + 100;
                int dmg3 = item.skillDamge + 25;
                int dmg4 = item.skillDamge + 50;
                int col = item.skillcoolTIme - 2;
                int col2 = item.skillcoolTIme - 4;
                int mana = item.SkillMana - 10;
                int mana2 = item.SkillMana - 20;
                if (item.itemType == Item.ItemType.SwordSkill)
                {   
                    SkillInvenSlot.Skillinstance.speed.text = "������ : " + item.skillDamge + " / " + dmg + " / " + dmg2;
                }
                else if (item.itemType == Item.ItemType.MagicSkill)
                {
                    SkillInvenSlot.Skillinstance.speed.text = "������ : " + item.skillDamge + " / " + dmg + " / " + dmg2;
                    if (item.itemName == "���̽� ������") SkillInvenSlot.Skillinstance.speed.text = "������ : " + item.skillDamge + "/ 0 / 0";
                    if (item.itemName == "���� ��ǳ") SkillInvenSlot.Skillinstance.speed.text = "������ : " + item.skillDamge + " / " + dmg3 + " / " + dmg4;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                {
                    SkillInvenSlot.Skillinstance.speed.text = "";
                }
                if (item.itemType == Item.ItemType.SwordSkill || item.itemType == Item.ItemType.MagicSkill)
                {
                    SkillInvenSlot.Skillinstance.Health.text = "��Ÿ�� :  " + item.skillcoolTIme + " / " + col + " / " + col2;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                { 
                    SkillInvenSlot.Skillinstance.Health.text = "��Ÿ�� : " + item.skillcoolTIme;
                }
                if (item.itemType == Item.ItemType.SwordSkill || item.itemType == Item.ItemType.MagicSkill)
                {   
                    SkillInvenSlot.Skillinstance.Mana.text = "�����Ҹ� :  " + item.SkillMana + " / " + mana + " / " + mana2;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                {
                    SkillInvenSlot.Skillinstance.Mana.text = "�����Ҹ� : 0";
                }
                SkillInvenSlot.Skillinstance.ShowItemInfo(itemImage);
                SkillInvenSlot.Skillinstance.transform.position = eventData.position;
            }
            else if (WeaponInven.WeaponyActivated)
            {
                ItemInfoSlot.instance.ItemSlot = this;
                ItemInfoSlot.instance.Itemimg.sprite = item.itemImage;
                if (item.itemName == "���� ��ö �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //ȸ
                if (item.itemName == "���� ������ �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>"; //��
                if (item.itemName == "������ �ڼ��� �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ���޶��� �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ��� �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // ��
                if (item.itemName == "�������� ���������� �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#00FFC4>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ���� ���� �ҵ�") ItemInfoSlot.instance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // ��

                if (item.itemName == "10��� ������� ������") ItemInfoSlot.instance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";//ȸ
                if (item.itemName == "30��� ��ī�þƳ��� ������") ItemInfoSlot.instance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>";//��
                if (item.itemName == "50��� ���۳��� ������") ItemInfoSlot.instance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";//��
                if (item.itemName == "70��� �ָ� ������") ItemInfoSlot.instance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";//��
                if (item.itemName == "100��� ���ѳ��� ������") ItemInfoSlot.instance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";//��

                ItemInfoSlot.instance.SwordType.text = item.weaponTypeTxt;
                if (item.itemType == Item.ItemType.Sword) ItemInfoSlot.instance.damge.text = "";
                else if (item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.damge.text = "";

                if (item.itemType == Item.ItemType.Sword || item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.speed.text = "";

                if (item.itemType == Item.ItemType.Sword) ItemInfoSlot.instance.Health.text = "���ݷ� + " + item.damage;
                else if (item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.Health.text = "������ + " + item.damage;

                if (item.itemType == Item.ItemType.ETC) ItemInfoSlot.instance.speed.text = "" + item.ETCInfo;

                ItemInfoSlot.instance.ShowItemInfo(itemImage);
                ItemInfoSlot.instance.transform.position = eventData.position;
            }
            else if (Inventory.inventoryActivated)
            {
                InvenSlot.Invenstance.ItemSlot = this;
                InvenSlot.Invenstance.Itemimg.sprite = item.itemImage;

                InvenSlot.Invenstance.SwordName.text = item.itemName + "";
                if (item.itemName == "���� ��ö �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //ȸ
                if (item.itemName == "���� ������ �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>"; //��
                if (item.itemName == "������ �ڼ��� �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ���޶��� �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ��� �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // ��
                if (item.itemName == "�������� ���������� �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#00FFC4>" + item.itemName + "</color>"; // ��
                if (item.itemName == "������ ���� ���� �ҵ�") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "10��� ������� ������") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";//ȸ
                if (item.itemName == "30��� ��ī�þƳ��� ������") InvenSlot.Invenstance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>";//��
                if (item.itemName == "50��� ���۳��� ������") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";//��
                if (item.itemName == "70��� �ָ� ������") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";//��
                if (item.itemName == "100��� ���ѳ��� ������") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";//��
                if (item.itemName == "���� ���� ���") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //ȸ
                if (item.itemName == "Ǫ�� ��ö ���") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "�ڼ��� ���� ���") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "���� ���� ���޶��� ���") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; //��
                if (item.itemName == "������ ���̾Ƹ�� ���") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // ��
                if (item.itemName == "���� �Ұ��� �Ƹ�") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "������ ��ö ����") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "�Ž� �����̾� �Ƹ�") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "������ ����� �Ƹ�") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "������ �������̾� �Ƹ�") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                if (item.itemName == "���۳� ���� ����") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "�簡��  ����") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "�߰��� �µ��� ����") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "������ ������ ����") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "������ ��� ����") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";

                InvenSlot.Invenstance.SwordType.text = item.weaponTypeTxt;

                if (item.itemType == Item.ItemType.Sword)
                {
                    InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                    InvenSlot.Invenstance.speed.text = "���ݷ� + " + item.damage;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.Magic)
                {
                    InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                    InvenSlot.Invenstance.speed.text = "������ + " + item.damage;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.ETC)
                {
                    InvenSlot.Invenstance.damge.text = "";
                    InvenSlot.Invenstance.speed.text = "" + item.ETCInfo;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.shoes)
                {
                    InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                    InvenSlot.Invenstance.speed.text = "�̵��ӵ� + " + item.Speed;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.head)
                {
                    InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                    InvenSlot.Invenstance.speed.text = "���� + " + item.Defense;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.cloth)
                {
                    InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                    InvenSlot.Invenstance.speed.text = "ü�� + " + item.Health;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.Acees)
                {
                    if (item.Weaponindex == 0)
                    {
                        InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                        InvenSlot.Invenstance.speed.text = "�ʴ� ü��ȸ�� + " + item.HealManaPlus;
                        InvenSlot.Invenstance.Health.text = "";
                    }
                    else if (item.Weaponindex == 1)
                    {
                        InvenSlot.Invenstance.damge.text = "��Ŭ���� �ڵ�����";
                        InvenSlot.Invenstance.speed.text = "�ʴ� ����ȸ�� + " + item.HealManaPlus;
                        InvenSlot.Invenstance.Health.text = "";
                    }
                }
                else if (item.itemType == Item.ItemType.Used)
                {
                    InvenSlot.Invenstance.damge.text = "";
                    if (item.Weaponindex == 0) InvenSlot.Invenstance.speed.text = "ü�� + " + item.PortionPlus + "ȸ��";
                    else if (item.Weaponindex == 1) InvenSlot.Invenstance.speed.text = "���� + " + item.PortionPlus + "ȸ��";
                    InvenSlot.Invenstance.Health.text = "";
                }

                InvenSlot.Invenstance.ShowItemInfo(itemImage);
                InvenSlot.Invenstance.transform.position = eventData.position;
            }
            else if (PortionInven.PortionInvenActivated)
            {
                PortionSlot.Portioninstance.ItemSlot = this;
                PortionSlot.Portioninstance.Itemimg.sprite = item.itemImage;
                PortionSlot.Portioninstance.SwordName.text = item.itemName + "";
                PortionSlot.Portioninstance.SwordType.text = item.weaponTypeTxt;
                if (item.itemType == Item.ItemType.Used)
                {
                    PortionSlot.Portioninstance.speed.text = "ü�� + " + item.PortionPlus + "ȸ��";
                }
                else if (item.itemType == Item.ItemType.Acees)
                {
                    if (item.Weaponindex == 0)
                    {
                        PortionSlot.Portioninstance.damge.text = "";
                        PortionSlot.Portioninstance.speed.text = "�ʴ� ü��ȸ�� + " + item.HealManaPlus;
                    }
                    else
                    {
                        PortionSlot.Portioninstance.damge.text = "";
                        PortionSlot.Portioninstance.speed.text = "�ʴ� ����ȸ�� + " + item.HealManaPlus;
                    }
                }
                PortionSlot.Portioninstance.ShowItemInfo(itemImage);
                PortionSlot.Portioninstance.transform.position = eventData.position;
            }
            else if (ArmorInven.ArmorActivated)
            {
                ArmorSlot.Armorinstance.ItemSlot = this;
                ArmorSlot.Armorinstance.Itemimg.sprite = item.itemImage;
                if(item.itemName == "���� ���� ���") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //ȸ
                if (item.itemName == "Ǫ�� ��ö ���") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "�ڼ��� ���� ���") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // ��
                if (item.itemName == "���� ���� ���޶��� ���") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; //��
                if (item.itemName == "������ ���̾Ƹ�� ���") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // ��

                if (item.itemName == "���� �Ұ��� �Ƹ�") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "������ ��ö ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "�Ž� �����̾� �Ƹ�") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "������ ����� �Ƹ�") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "������ �������̾� �Ƹ�") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";

                if (item.itemName == "���۳� ���� ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "�簡��  ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "�߰��� �µ��� ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "������ ������ ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "������ ��� ����") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                ArmorSlot.Armorinstance.SwordType.text = item.weaponTypeTxt;
                if(item.itemType == Item.ItemType.head)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "���� + " + item.Defense;
                    ArmorSlot.Armorinstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.cloth)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "ü�� + " + item.Health;
                    ArmorSlot.Armorinstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.shoes)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "�̵��ӵ� + " + item.Speed;
                    ArmorSlot.Armorinstance.Health.text = "";
                }
                ArmorSlot.Armorinstance.ShowItemInfo(itemImage);
                ArmorSlot.Armorinstance.transform.position = eventData.position;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(item != null)
        {
            if (SetSkillInven.SkillSetActivated)
            {
                SkillInvenSlot.Skillinstance.OutItemInfo(itemImage);
                SkillInvenSlot.Skillinstance.ItemSlot = null;
            }
            else if (WeaponInven.WeaponyActivated)
            {
                ItemInfoSlot.instance.OutItemInfo(itemImage);
                ItemInfoSlot.instance.ItemSlot = null;
            }
            else if (Inventory.inventoryActivated)
            {
                InvenSlot.Invenstance.OutItemInfo(itemImage);
                InvenSlot.Invenstance.ItemSlot = null;
            }
            else if (PortionInven.PortionInvenActivated)
            {
                PortionSlot.Portioninstance.OutItemInfo(itemImage);
                PortionSlot.Portioninstance.ItemSlot = null;
            }
            else if (ArmorInven.ArmorActivated)
            {
                ArmorSlot.Armorinstance.OutItemInfo(itemImage);
                ArmorSlot.Armorinstance.ItemSlot = null;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                if(item.itemType == Item.ItemType.Sword)
                {
                    Inventory.SwordChange(item,item.itemImage, item.Weaponindex, item.damage,item.Speed, item.Health);
                }
                if (item.itemType == Item.ItemType.Magic)
                {
                    Inventory.MagicChange(item,item.itemImage, item.Weaponindex, item.damage, item.Speed, item.Mana);
                }
                if (item.itemType == Item.ItemType.Acees)
                {
                    Inventory.AccChange(item, item.itemImage, item.Weaponindex, item.damage, item.HealManaPlus);
                }
                if (item.itemType == Item.ItemType.head)
                {
                    Inventory.headChange(item, item.itemImage, item.Defense);
                }
                if (item.itemType == Item.ItemType.cloth)
                {
                    Inventory.clothChange(item, item.itemImage, item.Health);
                }
                if (item.itemType == Item.ItemType.shoes)
                {
                    Inventory.shoesChange(item, item.itemImage, item.Speed);
                }
            }
        }
    }
    /*
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {   
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);

            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
            ChangeSlot();
    }
    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        else
            DragSlot.instance.dragSlot.ClearSlot();
    }
    */
}
