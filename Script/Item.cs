using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName; // 아이템의 이름.
    public ItemType itemType; // 아이템의 유형.
    public int Weaponindex;
    public Sprite itemImage; // 아이템의 이미지.
    public GameObject itemPrefab; // 아이템의 프리팹.
    public string weaponTypeTxt;
    public int damage;
    public float Speed;
    public int Health;
    public string ETCInfo;
    public string SkillInfo;
    public int skillcoolTIme;
    public int skillDamge;
    public int SkillMana;
    public int HealManaPlus;
    public string weaponType; // 무기 유형.
    public int PortionPlus;
    public string rank;
    public int Mana;
    public int Defense;
    public enum ItemType
    {   
        Sword,
        Magic,
        Used,
        Ingredient,
        ETC,
        SwordSkill,
        MagicSkill,
        AckSkill,
        Acees,
        shoes,
        cloth,
        head
    }

}
