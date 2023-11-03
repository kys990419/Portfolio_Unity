using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler,  IPointerEnterHandler,IPointerExitHandler
{   //IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler,
    public Item item; // 획득한 아이템.
    public int itemCount; // 획득한 아이템의 개수.
    public Image itemImage; // 아이템의 이미지.
    Color newColor;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;

    Inventory Inventory;
    private void Start()
    {
        Inventory = GetComponentInParent<Inventory>();
    }
    // 이미지의 투명도 조절.
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    // 아이템 획득
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

    // 아이템 개수 조정.
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

    // 슬롯 초기화.
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
                SkillInvenSlot.Skillinstance.Itemimg.sprite = item.itemImage; // 초주보빨
                if (item.itemName == "회전 베기" || item.itemName == "얼음 폭풍")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#4AFF00>" + item.rank + "</color>" + "이상";
                }
                if (item.itemName == "용암 지진" || item.itemName == "아이스 에이지")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FFAB00>" + item.rank + "</color>" + "이상";
                }
                if (item.itemName == "신성화" || item.itemName == "디바인 에너지 스트라이크")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FF00ED>" + item.rank + "</color>" + "이상";
                }
                if (item.itemName == "각 성")
                {
                    SkillInvenSlot.Skillinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                    SkillInvenSlot.Skillinstance.SwordType.text = "<color=#FF0000>" + item.rank + "</color>" + "이상";
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
                    SkillInvenSlot.Skillinstance.speed.text = "데미지 : " + item.skillDamge + " / " + dmg + " / " + dmg2;
                }
                else if (item.itemType == Item.ItemType.MagicSkill)
                {
                    SkillInvenSlot.Skillinstance.speed.text = "데미지 : " + item.skillDamge + " / " + dmg + " / " + dmg2;
                    if (item.itemName == "아이스 에이지") SkillInvenSlot.Skillinstance.speed.text = "데미지 : " + item.skillDamge + "/ 0 / 0";
                    if (item.itemName == "얼음 폭풍") SkillInvenSlot.Skillinstance.speed.text = "데미지 : " + item.skillDamge + " / " + dmg3 + " / " + dmg4;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                {
                    SkillInvenSlot.Skillinstance.speed.text = "";
                }
                if (item.itemType == Item.ItemType.SwordSkill || item.itemType == Item.ItemType.MagicSkill)
                {
                    SkillInvenSlot.Skillinstance.Health.text = "쿨타임 :  " + item.skillcoolTIme + " / " + col + " / " + col2;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                { 
                    SkillInvenSlot.Skillinstance.Health.text = "쿨타임 : " + item.skillcoolTIme;
                }
                if (item.itemType == Item.ItemType.SwordSkill || item.itemType == Item.ItemType.MagicSkill)
                {   
                    SkillInvenSlot.Skillinstance.Mana.text = "마나소모 :  " + item.SkillMana + " / " + mana + " / " + mana2;
                }
                else if (item.itemType == Item.ItemType.AckSkill)
                {
                    SkillInvenSlot.Skillinstance.Mana.text = "마나소모 : 0";
                }
                SkillInvenSlot.Skillinstance.ShowItemInfo(itemImage);
                SkillInvenSlot.Skillinstance.transform.position = eventData.position;
            }
            else if (WeaponInven.WeaponyActivated)
            {
                ItemInfoSlot.instance.ItemSlot = this;
                ItemInfoSlot.instance.Itemimg.sprite = item.itemImage;
                if (item.itemName == "낡은 강철 소드") ItemInfoSlot.instance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //회
                if (item.itemName == "구식 토파즈 소드") ItemInfoSlot.instance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>"; //노
                if (item.itemName == "빛나는 자수정 소드") ItemInfoSlot.instance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; // 보
                if (item.itemName == "찬란한 에메랄드 소드") ItemInfoSlot.instance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // 초
                if (item.itemName == "영광의 루비 소드") ItemInfoSlot.instance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // 빨
                if (item.itemName == "전설적인 대장장이의 소드") ItemInfoSlot.instance.SwordName.text = "<color=#00FFC4>" + item.itemName + "</color>"; // 민
                if (item.itemName == "무한한 힘을 가진 소드") ItemInfoSlot.instance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // 주

                if (item.itemName == "10년된 사과나무 스태프") ItemInfoSlot.instance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";//회
                if (item.itemName == "30년된 아카시아나무 스태프") ItemInfoSlot.instance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>";//노
                if (item.itemName == "50년된 자작나무 스태프") ItemInfoSlot.instance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";//초
                if (item.itemName == "70년된 주목 스태프") ItemInfoSlot.instance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";//보
                if (item.itemName == "100년된 딱총나무 스태프") ItemInfoSlot.instance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";//빨

                ItemInfoSlot.instance.SwordType.text = item.weaponTypeTxt;
                if (item.itemType == Item.ItemType.Sword) ItemInfoSlot.instance.damge.text = "";
                else if (item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.damge.text = "";

                if (item.itemType == Item.ItemType.Sword || item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.speed.text = "";

                if (item.itemType == Item.ItemType.Sword) ItemInfoSlot.instance.Health.text = "공격력 + " + item.damage;
                else if (item.itemType == Item.ItemType.Magic) ItemInfoSlot.instance.Health.text = "마법력 + " + item.damage;

                if (item.itemType == Item.ItemType.ETC) ItemInfoSlot.instance.speed.text = "" + item.ETCInfo;

                ItemInfoSlot.instance.ShowItemInfo(itemImage);
                ItemInfoSlot.instance.transform.position = eventData.position;
            }
            else if (Inventory.inventoryActivated)
            {
                InvenSlot.Invenstance.ItemSlot = this;
                InvenSlot.Invenstance.Itemimg.sprite = item.itemImage;

                InvenSlot.Invenstance.SwordName.text = item.itemName + "";
                if (item.itemName == "낡은 강철 소드") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //회
                if (item.itemName == "구식 토파즈 소드") InvenSlot.Invenstance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>"; //노
                if (item.itemName == "빛나는 자수정 소드") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; // 보
                if (item.itemName == "찬란한 에메랄드 소드") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // 초
                if (item.itemName == "영광의 루비 소드") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // 빨
                if (item.itemName == "전설적인 대장장이의 소드") InvenSlot.Invenstance.SwordName.text = "<color=#00FFC4>" + item.itemName + "</color>"; // 민
                if (item.itemName == "무한한 힘을 가진 소드") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // 주
                if (item.itemName == "10년된 사과나무 스태프") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";//회
                if (item.itemName == "30년된 아카시아나무 스태프") InvenSlot.Invenstance.SwordName.text = "<color=#FFED00>" + item.itemName + "</color>";//노
                if (item.itemName == "50년된 자작나무 스태프") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";//초
                if (item.itemName == "70년된 주목 스태프") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";//보
                if (item.itemName == "100년된 딱총나무 스태프") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";//빨
                if (item.itemName == "구제 전사 헬멧") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //회
                if (item.itemName == "푸른 강철 헬멧") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // 초
                if (item.itemName == "자수정 솜털 헬멧") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // 주
                if (item.itemName == "붉은 깃털 에메랄드 헬멧") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; //보
                if (item.itemName == "찬란한 다이아몬드 헬멧") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // 빨
                if (item.itemName == "헤진 소가죽 아머") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "오래된 강철 갑옷") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "신식 데마이어 아머") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "위대한 세라믹 아머") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "찬란한 블루사파이어 아머") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                if (item.itemName == "구멍난 갈색 슈즈") InvenSlot.Invenstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "양가죽  슈즈") InvenSlot.Invenstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "견고한 온도금 슈즈") InvenSlot.Invenstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "빛나는 적갈색 슈즈") InvenSlot.Invenstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "찬란한 루비 슈즈") InvenSlot.Invenstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";

                InvenSlot.Invenstance.SwordType.text = item.weaponTypeTxt;

                if (item.itemType == Item.ItemType.Sword)
                {
                    InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                    InvenSlot.Invenstance.speed.text = "공격력 + " + item.damage;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.Magic)
                {
                    InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                    InvenSlot.Invenstance.speed.text = "마법력 + " + item.damage;
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
                    InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                    InvenSlot.Invenstance.speed.text = "이동속도 + " + item.Speed;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.head)
                {
                    InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                    InvenSlot.Invenstance.speed.text = "방어력 + " + item.Defense;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.cloth)
                {
                    InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                    InvenSlot.Invenstance.speed.text = "체력 + " + item.Health;
                    InvenSlot.Invenstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.Acees)
                {
                    if (item.Weaponindex == 0)
                    {
                        InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                        InvenSlot.Invenstance.speed.text = "초당 체력회복 + " + item.HealManaPlus;
                        InvenSlot.Invenstance.Health.text = "";
                    }
                    else if (item.Weaponindex == 1)
                    {
                        InvenSlot.Invenstance.damge.text = "우클릭시 자동장착";
                        InvenSlot.Invenstance.speed.text = "초당 마나회복 + " + item.HealManaPlus;
                        InvenSlot.Invenstance.Health.text = "";
                    }
                }
                else if (item.itemType == Item.ItemType.Used)
                {
                    InvenSlot.Invenstance.damge.text = "";
                    if (item.Weaponindex == 0) InvenSlot.Invenstance.speed.text = "체력 + " + item.PortionPlus + "회복";
                    else if (item.Weaponindex == 1) InvenSlot.Invenstance.speed.text = "마나 + " + item.PortionPlus + "회복";
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
                    PortionSlot.Portioninstance.speed.text = "체력 + " + item.PortionPlus + "회복";
                }
                else if (item.itemType == Item.ItemType.Acees)
                {
                    if (item.Weaponindex == 0)
                    {
                        PortionSlot.Portioninstance.damge.text = "";
                        PortionSlot.Portioninstance.speed.text = "초당 체력회복 + " + item.HealManaPlus;
                    }
                    else
                    {
                        PortionSlot.Portioninstance.damge.text = "";
                        PortionSlot.Portioninstance.speed.text = "초당 마나회복 + " + item.HealManaPlus;
                    }
                }
                PortionSlot.Portioninstance.ShowItemInfo(itemImage);
                PortionSlot.Portioninstance.transform.position = eventData.position;
            }
            else if (ArmorInven.ArmorActivated)
            {
                ArmorSlot.Armorinstance.ItemSlot = this;
                ArmorSlot.Armorinstance.Itemimg.sprite = item.itemImage;
                if(item.itemName == "구제 전사 헬멧") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>"; //회
                if (item.itemName == "푸른 강철 헬멧") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>"; // 초
                if (item.itemName == "자수정 솜털 헬멧") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>"; // 주
                if (item.itemName == "붉은 깃털 에메랄드 헬멧") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>"; //보
                if (item.itemName == "찬란한 다이아몬드 헬멧") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>"; // 빨

                if (item.itemName == "헤진 소가죽 아머") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "오래된 강철 갑옷") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "신식 데마이어 아머") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "위대한 세라믹 아머") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "찬란한 블루사파이어 아머") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";

                if (item.itemName == "구멍난 갈색 슈즈") ArmorSlot.Armorinstance.SwordName.text = "<color=#C3C3C3>" + item.itemName + "</color>";
                if (item.itemName == "양가죽  슈즈") ArmorSlot.Armorinstance.SwordName.text = "<color=#4AFF00>" + item.itemName + "</color>";
                if (item.itemName == "견고한 온도금 슈즈") ArmorSlot.Armorinstance.SwordName.text = "<color=#FFAB00>" + item.itemName + "</color>";
                if (item.itemName == "빛나는 적갈색 슈즈") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF00ED>" + item.itemName + "</color>";
                if (item.itemName == "찬란한 루비 슈즈") ArmorSlot.Armorinstance.SwordName.text = "<color=#FF0000>" + item.itemName + "</color>";
                ArmorSlot.Armorinstance.SwordType.text = item.weaponTypeTxt;
                if(item.itemType == Item.ItemType.head)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "방어력 + " + item.Defense;
                    ArmorSlot.Armorinstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.cloth)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "체력 + " + item.Health;
                    ArmorSlot.Armorinstance.Health.text = "";
                }
                else if (item.itemType == Item.ItemType.shoes)
                {
                    ArmorSlot.Armorinstance.damge.text = "";
                    ArmorSlot.Armorinstance.speed.text = "이동속도 + " + item.Speed;
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
