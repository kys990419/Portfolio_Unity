using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName; // �������� �̸�.
    public ItemType itemType; // �������� ����.
    public int Weaponindex;
    public Sprite itemImage; // �������� �̹���.
    public GameObject itemPrefab; // �������� ������.
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
    public string weaponType; // ���� ����.
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
