using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInvenSlot : MonoBehaviour
{
    static public SkillInvenSlot Skillinstance;

    public Slot ItemSlot;
    public GameObject ItemInfo;
    public Image Itemimg;
    public Text SwordName;
    public Text SwordType;
    public Text damge;
    public Text speed;
    public Text Health;
    public Text Mana;

    void Start()
    {
        Skillinstance = this;
    }

    public void ShowItemInfo(Image _itemImage)
    {
        ItemInfo.gameObject.SetActive(true);
    }
    public void OutItemInfo(Image _itemImage)
    {
        ItemInfo.gameObject.SetActive(false);
    }
}
