using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public bool endLoad;
    public Item[] items;
    public Inventory inventory;
    public PlayerMove playerMove;
    public UI ui;
    public SetSkillInven setSkillInven;
    public GameObject NOsave;
    public QuestManager questManager;
    public QuestMark questMark;
    void Start()
    {
    }

    void Update()
    {

    }
    public void GameSave()
    {   
        if(!playerMove.inTown)
        {
            NOsave.gameObject.SetActive(true);
            return;
        }
        PlayerPrefs.SetFloat("PlayerX", playerMove.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerMove.gameObject.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerMove.gameObject.transform.position.z);
        PlayerPrefs.SetInt("Gold", playerMove.Gold);
        PlayerPrefs.SetInt("curTown", playerMove.curTown);
        PlayerPrefs.SetInt("Level", playerMove.Level);
        PlayerPrefs.SetInt("Stat", playerMove.Stat);
        PlayerPrefs.SetInt("HealPortion", playerMove.HealPortion);
        PlayerPrefs.SetInt("ManaPortion", playerMove.ManaPortion);
        PlayerPrefs.SetInt("SkillPoint", playerMove.SkillPoint);
        PlayerPrefs.SetFloat("maxHealth", playerMove.maxHealth);
        PlayerPrefs.SetFloat("maxMp", playerMove.maxMp);
        PlayerPrefs.SetInt("AD", playerMove.AD);
        PlayerPrefs.SetInt("AP", playerMove.AP);
        PlayerPrefs.SetInt("Defense", playerMove.Defense);
        PlayerPrefs.SetFloat("speed", playerMove.speed);
        PlayerPrefs.SetFloat("PortionRate", playerMove.PortionRate);
        PlayerPrefs.SetInt("Sword1SkillPoint", setSkillInven.Sword1SkillPoint);
        PlayerPrefs.SetInt("Sword2SkillPoint", setSkillInven.Sword2SkillPoint);
        PlayerPrefs.SetInt("Sword3SkillPoint", setSkillInven.Sword3SkillPoint);
        PlayerPrefs.SetInt("Magic1SkillPoint", setSkillInven.Magic1SkillPoint);
        PlayerPrefs.SetInt("Magic2SkillPoint", setSkillInven.Magic2SkillPoint);
        PlayerPrefs.SetInt("Magic3SkillPoint", setSkillInven.Magic3SkillPoint);
        PlayerPrefs.SetInt("AckSkillPoint", setSkillInven.AckSkillPoint);
        PlayerPrefs.SetFloat("Sword1Skillcool", playerMove.Sword1Skillcool);
        PlayerPrefs.SetFloat("Sword2Skillcool", playerMove.Sword2Skillcool);
        PlayerPrefs.SetFloat("Sword3Skillcool", playerMove.Sword3Skillcool);
        PlayerPrefs.SetFloat("Magic1Skillcool", playerMove.Magic1Skillcool);
        PlayerPrefs.SetFloat("IceEnemySkillcool", playerMove.IceEnemySkillcool);
        PlayerPrefs.SetFloat("Magic3Skillcool", playerMove.Magic3Skillcool);
        PlayerPrefs.SetFloat("AckSkillcool", playerMove.AckSkillcool);
        PlayerPrefs.SetFloat("AckUsingSkillcool", playerMove.AckUsingSkillcool);
        PlayerPrefs.SetFloat("Sword1SkillDmg", playerMove.Sword1SkillDmg);
        PlayerPrefs.SetFloat("Sword2SkillDmg", playerMove.Sword2SkillDmg);
        PlayerPrefs.SetFloat("Sword3SkillDmg", playerMove.Sword3SkillDmg);
        PlayerPrefs.SetFloat("Magic1SkillDmg", playerMove.Magic1SkillDmg);
        PlayerPrefs.SetFloat("IceEnemySkillDmg", playerMove.IceEnemySkillDmg);
        PlayerPrefs.SetFloat("Magic3SkillDmg", playerMove.Magic3SkillDmg);
        PlayerPrefs.SetFloat("Sword1SkillMana", playerMove.Sword1SkillMana);
        PlayerPrefs.SetFloat("Sword2SkillMana", playerMove.Sword2SkillMana);
        PlayerPrefs.SetFloat("Sword3SkillMana", playerMove.Sword3SkillMana);
        PlayerPrefs.SetFloat("Magic1SkillMana", playerMove.Magic1SkillMana);
        PlayerPrefs.SetFloat("IceEnemySkillMana", playerMove.IceEnemySkillMana);
        PlayerPrefs.SetFloat("Magic3SkillMana", playerMove.Magic3SkillMana);
        PlayerPrefs.SetFloat("Magic1SkillMana", playerMove.Magic1SkillMana);
        PlayerPrefs.SetFloat("Magic1SkillMana", playerMove.Magic1SkillMana);
        PlayerPrefs.SetFloat("Magic1SkillMana", playerMove.Magic1SkillMana);
        PlayerPrefs.SetFloat("Magic1SkillMana", playerMove.Magic1SkillMana);
        PlayerPrefs.SetInt("EqipHealth", playerMove.EqipHealth);
        PlayerPrefs.SetInt("EqipMp", playerMove.EqipMp);
        PlayerPrefs.SetInt("EqipAD", playerMove.EqipAD);
        PlayerPrefs.SetInt("EqipAP", playerMove.EqipAP);
        PlayerPrefs.SetInt("EqipDefense", playerMove.EqipDefense);
        PlayerPrefs.SetFloat("Eqipspeed", playerMove.Eqipspeed);
        PlayerPrefs.SetFloat("EqipPortionRate", playerMove.EqipPortionRate);

        PlayerPrefs.SetInt("QuestAcceptNumber", questManager.QuestAcceptNumber);
        PlayerPrefs.SetInt("MyQuestAcceptNumber ", questManager.MyQuestAcceptNumber);
        PlayerPrefs.SetInt("MyQuestCompleteNumber ", questManager.MyQuestCompleteNumber);

        PlayerPrefs.SetInt("index ", questMark.index);

        PlayerPrefs.SetInt("curBoss ", playerMove.curBoss);

        if (playerMove.Sword1Rock == true) PlayerPrefs.SetInt("Sword1Rock", 0);
        else PlayerPrefs.SetInt("Sword1Rock", 1);
        if (playerMove.Sword2Rock == true) PlayerPrefs.SetInt("Sword2Rock", 0);
        else PlayerPrefs.SetInt("Sword2Rock", 1);
        if (playerMove.Sword3Rock == true) PlayerPrefs.SetInt("Sword3Rock", 0);
        else PlayerPrefs.SetInt("Sword3Rock", 1);
        if (playerMove.Magic1Rock == true) PlayerPrefs.SetInt("Magic1Rock", 0);
        else PlayerPrefs.SetInt("Magic1Rock", 1);
        if (playerMove.Magic2Rock == true) PlayerPrefs.SetInt("Magic2Rock", 0);
        else PlayerPrefs.SetInt("Magic2Rock", 1);
        if (playerMove.Magic3Rock == true) PlayerPrefs.SetInt("Magic3Rock", 0);
        else PlayerPrefs.SetInt("Magic3Rock", 1);
        if (playerMove.AckRock == true) PlayerPrefs.SetInt("AckRock", 0);
        else PlayerPrefs.SetInt("AckRock", 1);

        if(inventory.S0 == true) PlayerPrefs.SetInt("S0", 1);
        else PlayerPrefs.SetInt("S0", 0);
        if (inventory.S1 == true) PlayerPrefs.SetInt("S1", 1);
        else PlayerPrefs.SetInt("S1", 0);
        if (inventory.S2 == true) PlayerPrefs.SetInt("S2", 1);
        else PlayerPrefs.SetInt("S2", 0);
        if (inventory.S3 == true) PlayerPrefs.SetInt("S3", 1);
        else PlayerPrefs.SetInt("S3", 0);
        if (inventory.S4 == true) PlayerPrefs.SetInt("S4", 1);
        else PlayerPrefs.SetInt("S4", 0);
        if (inventory.S5 == true) PlayerPrefs.SetInt("S5", 1);
        else PlayerPrefs.SetInt("S5", 0);
        if (inventory.S6 == true) PlayerPrefs.SetInt("S6", 1);
        else PlayerPrefs.SetInt("S6", 0);
        if (inventory.S7 == true) PlayerPrefs.SetInt("S7", 1);
        else PlayerPrefs.SetInt("S7", 0);

        if (inventory.M0 == true) PlayerPrefs.SetInt("M0", 1);
        else PlayerPrefs.SetInt("M0", 0);
        if (inventory.M1 == true) PlayerPrefs.SetInt("M1", 1);
        else PlayerPrefs.SetInt("M1", 0);
        if (inventory.M2 == true) PlayerPrefs.SetInt("M2", 1);
        else PlayerPrefs.SetInt("M2", 0);
        if (inventory.M3 == true) PlayerPrefs.SetInt("M3", 1);
        else PlayerPrefs.SetInt("M3", 0);
        if (inventory.M4 == true) PlayerPrefs.SetInt("M4", 1);
        else PlayerPrefs.SetInt("M4", 0);
        if (inventory.M5 == true) PlayerPrefs.SetInt("M5", 1);
        else PlayerPrefs.SetInt("M5", 0);

        if (inventory.H0 == true) PlayerPrefs.SetInt("H0", 1);
        else PlayerPrefs.SetInt("H0", 0);
        if (inventory.H1 == true) PlayerPrefs.SetInt("H1", 1);
        else PlayerPrefs.SetInt("H1", 0);
        if (inventory.H2 == true) PlayerPrefs.SetInt("H2", 1);
        else PlayerPrefs.SetInt("H2", 0);
        if (inventory.H3 == true) PlayerPrefs.SetInt("H3", 1);
        else PlayerPrefs.SetInt("H3", 0);
        if (inventory.H4 == true) PlayerPrefs.SetInt("H4", 1);
        else PlayerPrefs.SetInt("H4", 0);
        if (inventory.H5 == true) PlayerPrefs.SetInt("H5", 1);
        else PlayerPrefs.SetInt("H5", 0);

        if (inventory.A0 == true) PlayerPrefs.SetInt("A0", 1);
        else PlayerPrefs.SetInt("A0", 0);
        if (inventory.A1 == true) PlayerPrefs.SetInt("A1", 1);
        else PlayerPrefs.SetInt("A1", 0);
        if (inventory.A2 == true) PlayerPrefs.SetInt("A2", 1);
        else PlayerPrefs.SetInt("A2", 0);
        if (inventory.A3 == true) PlayerPrefs.SetInt("A3", 1);
        else PlayerPrefs.SetInt("A3", 0);
        if (inventory.A4 == true) PlayerPrefs.SetInt("A4", 1);
        else PlayerPrefs.SetInt("A4", 0);
        if (inventory.A5 == true) PlayerPrefs.SetInt("A5", 1);
        else PlayerPrefs.SetInt("A5", 0);

        if (inventory.SH0 == true) PlayerPrefs.SetInt("SH0", 1);
        else PlayerPrefs.SetInt("SH0", 0);
        if (inventory.SH1 == true) PlayerPrefs.SetInt("SH1", 1);
        else PlayerPrefs.SetInt("SH1", 0);
        if (inventory.SH2 == true) PlayerPrefs.SetInt("SH2", 1);
        else PlayerPrefs.SetInt("SH2", 0);
        if (inventory.SH3 == true) PlayerPrefs.SetInt("SH3", 1);
        else PlayerPrefs.SetInt("SH3", 0);
        if (inventory.SH4 == true) PlayerPrefs.SetInt("SH4", 1);
        else PlayerPrefs.SetInt("SH4", 0);
        if (inventory.SH5 == true) PlayerPrefs.SetInt("SH5", 1);
        else PlayerPrefs.SetInt("SH5", 0);

        if (inventory.Acc1 == true) PlayerPrefs.SetInt("Acc1", 1);
        else PlayerPrefs.SetInt("Acc1", 0);
        if (inventory.Acc2 == true) PlayerPrefs.SetInt("Acc2", 1);
        else PlayerPrefs.SetInt("Acc2", 0);

        if (inventory.Portion1 == true) PlayerPrefs.SetInt("Portion1", 1);
        else PlayerPrefs.SetInt("Portion1", 0);
        if (inventory.Portion2 == true) PlayerPrefs.SetInt("Portion2", 1);
        else PlayerPrefs.SetInt("Portion2", 0);

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "고블린 궁수 전리템")
                {
                    PlayerPrefs.SetInt("Obj1", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "검은망령의 전리품")
                {
                    PlayerPrefs.SetInt("Obj2", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "고블린 왕의 두골")
                {
                    PlayerPrefs.SetInt("Obj3", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "고블린 행동대장의 척추")
                {
                    PlayerPrefs.SetInt("Obj4", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "뒤틀린 사신의 모래시계")
                {
                    PlayerPrefs.SetInt("Obj5", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "뒤틀린 주술사의 목걸이")
                {
                    PlayerPrefs.SetInt("Obj6", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "불로초")
                {
                    PlayerPrefs.SetInt("Obj7", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "신비로운 약")
                {
                    PlayerPrefs.SetInt("Obj8", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "암석거인의 파편")
                {
                    PlayerPrefs.SetInt("Obj9", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "해골 기사의 갈비뼈")
                {
                    PlayerPrefs.SetInt("Obj10", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "해골궁수의 뿔")
                {
                    PlayerPrefs.SetInt("Obj11", inventory.slots[i].itemCount);
                }
            }
        }
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "지옥 수문장의 전리품 책")
                {
                    PlayerPrefs.SetInt("Obj12", inventory.slots[i].itemCount);
                }
            }
        }

        PlayerPrefs.Save();
    }
    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
        {
            endLoad = true;
            return;
        }

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        float z = PlayerPrefs.GetFloat("PlayerZ");
        int Gold = PlayerPrefs.GetInt("Gold");
        int Stat = PlayerPrefs.GetInt("Stat");
        int HealPortion = PlayerPrefs.GetInt("HealPortion");
        int ManaPortion = PlayerPrefs.GetInt("ManaPortion");
        int SkillPoint = PlayerPrefs.GetInt("SkillPoint");
        float maxHealth = PlayerPrefs.GetFloat("maxHealth");
        float maxMp = PlayerPrefs.GetFloat("maxMp");
        int AD = PlayerPrefs.GetInt("AD");
        int AP = PlayerPrefs.GetInt("AP");
        int Defense = PlayerPrefs.GetInt("Defense");
        float speed = PlayerPrefs.GetFloat("speed");
        float PortionRate = PlayerPrefs.GetFloat("PortionRate");
        int Sword1SkillPoint = PlayerPrefs.GetInt("Sword1SkillPoint");
        int Sword2SkillPoint = PlayerPrefs.GetInt("Sword2SkillPoint");
        int Sword3SkillPoint = PlayerPrefs.GetInt("Sword3SkillPoint");
        int Magic1SkillPoint = PlayerPrefs.GetInt("Magic1SkillPoint");
        int Magic2SkillPoint = PlayerPrefs.GetInt("Magic2SkillPoint");
        int Magic3SkillPoint = PlayerPrefs.GetInt("Magic3SkillPoint");
        int AckSkillPoint = PlayerPrefs.GetInt("AckSkillPoint");
        int Sword1Rock = PlayerPrefs.GetInt("Sword1Rock");
        int Sword2Rock = PlayerPrefs.GetInt("Sword2Rock");
        int Sword3Rock = PlayerPrefs.GetInt("Sword3Rock");
        int AckRock = PlayerPrefs.GetInt("AckRock");
        int Level = PlayerPrefs.GetInt("Level");
        int curTown = PlayerPrefs.GetInt("curTown");
        float Sword1Skillcool = PlayerPrefs.GetFloat("Sword1Skillcool");
        float Sword2Skillcool = PlayerPrefs.GetFloat("Sword2Skillcool");
        float Sword3Skillcool = PlayerPrefs.GetFloat("Sword3Skillcool");
        float Magic1Skillcool = PlayerPrefs.GetFloat("Magic1Skillcool");
        float IceEnemySkillcool = PlayerPrefs.GetFloat("IceEnemySkillcool");
        float Magic3Skillcool = PlayerPrefs.GetFloat("Magic3Skillcool");
        float AckSkillcool = PlayerPrefs.GetFloat("AckSkillcool");
        float AckUsingSkillcool = PlayerPrefs.GetFloat("AckUsingSkillcool");
        float Sword1SkillDmg = PlayerPrefs.GetFloat("Sword1SkillDmg");
        float Sword2SkillDmg = PlayerPrefs.GetFloat("Sword2SkillDmg");
        float Sword3SkillDmg = PlayerPrefs.GetFloat("Sword3SkillDmg");
        float Magic1SkillDmg = PlayerPrefs.GetFloat("Magic1SkillDmg");
        float IceEnemySkillDmg = PlayerPrefs.GetFloat("IceEnemySkillDmg");
        float Magic3SkillDmg = PlayerPrefs.GetFloat("Magic3SkillDmg");
        float Sword1SkillMana = PlayerPrefs.GetFloat("Sword1SkillMana");
        float Sword2SkillMana = PlayerPrefs.GetFloat("Sword2SkillMana");
        float Sword3SkillMana = PlayerPrefs.GetFloat("Sword3SkillMana");
        float Magic1SkillMana = PlayerPrefs.GetFloat("Magic1SkillMana");
        float IceEnemySkillMana = PlayerPrefs.GetFloat("IceEnemySkillMana");
        float Magic3SkillMana = PlayerPrefs.GetFloat("Magic3SkillMana");
        int EqipHealth = PlayerPrefs.GetInt("EqipHealth");
        int EqipMp = PlayerPrefs.GetInt("EqipMp");
        int EqipAD = PlayerPrefs.GetInt("EqipAD");
        int EqipAP = PlayerPrefs.GetInt("EqipAP");
        int EqipDefense = PlayerPrefs.GetInt("EqipDefense");
        float Eqipspeed = PlayerPrefs.GetFloat("Eqipspeed");
        float EqipPortionRate = PlayerPrefs.GetFloat("EqipPortionRate");
        int S0 = PlayerPrefs.GetInt("S0");
        int S1 = PlayerPrefs.GetInt("S1");
        int S2 = PlayerPrefs.GetInt("S2");
        int S3 = PlayerPrefs.GetInt("S3");
        int S4 = PlayerPrefs.GetInt("S4");
        int S5 = PlayerPrefs.GetInt("S5");
        int S6 = PlayerPrefs.GetInt("S6");
        int S7 = PlayerPrefs.GetInt("S7");

        int M0 = PlayerPrefs.GetInt("M0");
        int M1 = PlayerPrefs.GetInt("M1");
        int M2 = PlayerPrefs.GetInt("M2");
        int M3 = PlayerPrefs.GetInt("M3");
        int M4 = PlayerPrefs.GetInt("M4");
        int M5 = PlayerPrefs.GetInt("M5");

        int A0 = PlayerPrefs.GetInt("A0");
        int A1 = PlayerPrefs.GetInt("A1");
        int A2 = PlayerPrefs.GetInt("A2");
        int A3 = PlayerPrefs.GetInt("A3");
        int A4 = PlayerPrefs.GetInt("A4");
        int A5 = PlayerPrefs.GetInt("A5");

        int H0 = PlayerPrefs.GetInt("H0");
        int H1 = PlayerPrefs.GetInt("H1");
        int H2 = PlayerPrefs.GetInt("H2");
        int H3 = PlayerPrefs.GetInt("H3");
        int H4 = PlayerPrefs.GetInt("H4");
        int H5 = PlayerPrefs.GetInt("H5");

        int SH0 = PlayerPrefs.GetInt("SH0");
        int SH1 = PlayerPrefs.GetInt("SH1");
        int SH2 = PlayerPrefs.GetInt("SH2");
        int SH3 = PlayerPrefs.GetInt("SH3");
        int SH4 = PlayerPrefs.GetInt("SH4");
        int SH5 = PlayerPrefs.GetInt("SH5");

        int Acc1 = PlayerPrefs.GetInt("Acc1");
        int Acc2 = PlayerPrefs.GetInt("Acc2");

        int Portion1 = PlayerPrefs.GetInt("Portion1");
        int Portion2 = PlayerPrefs.GetInt("Portion2");

        int QuestAcceptNumber = PlayerPrefs.GetInt("QuestAcceptNumber");
        int MyQuestAcceptNumber = PlayerPrefs.GetInt("MyQuestAcceptNumber");
        int MyQuestCompleteNumber = PlayerPrefs.GetInt("MyQuestCompleteNumber");

        int index = PlayerPrefs.GetInt("index");

        int Obj1 = PlayerPrefs.GetInt("Obj1");
        int Obj2 = PlayerPrefs.GetInt("Obj2");
        int Obj3 = PlayerPrefs.GetInt("Obj3");
        int Obj4 = PlayerPrefs.GetInt("Obj4");
        int Obj5 = PlayerPrefs.GetInt("Obj5");
        int Obj6 = PlayerPrefs.GetInt("Obj6");
        int Obj7 = PlayerPrefs.GetInt("Obj7");
        int Obj8 = PlayerPrefs.GetInt("Obj8");
        int Obj9 = PlayerPrefs.GetInt("Obj9");
        int Obj10 = PlayerPrefs.GetInt("Obj10");
        int Obj11 = PlayerPrefs.GetInt("Obj11");
        int Obj12 = PlayerPrefs.GetInt("Obj12");

        int curBoss = PlayerPrefs.GetInt("curBoss");

        playerMove.curBoss = curBoss;

        questManager.QuestAcceptNumber = QuestAcceptNumber;
        questManager.MyQuestAcceptNumber = QuestAcceptNumber;
        questManager.MyQuestCompleteNumber = QuestAcceptNumber;

        questMark.index = QuestAcceptNumber - 1;

        inventory.AcquireItem(items[36], Obj1);
        inventory.AcquireItem(items[37], Obj2);
        inventory.AcquireItem(items[38], Obj3);
        inventory.AcquireItem(items[39], Obj4);
        inventory.AcquireItem(items[40], Obj5);
        inventory.AcquireItem(items[41], Obj6);
        inventory.AcquireItem(items[42], Obj7);
        inventory.AcquireItem(items[43], Obj8);
        inventory.AcquireItem(items[44], Obj9);
        inventory.AcquireItem(items[45], Obj10);
        inventory.AcquireItem(items[46], Obj11);
        inventory.AcquireItem(items[47], Obj12);


        playerMove.gameObject.transform.position = new Vector3(x, y, z);
        playerMove.Gold = Gold;
        playerMove.Level = Level;
        playerMove.HealPortion = HealPortion;
        playerMove.ManaPortion = ManaPortion;
        playerMove.SkillPoint = SkillPoint;
        playerMove.maxHealth = maxHealth;
        playerMove.maxMp = maxMp;
        playerMove.AD = AD;
        playerMove.AP = AP;
        playerMove.Defense = Defense;
        playerMove.speed = speed;
        playerMove.PortionRate = PortionRate;
        playerMove.Stat = Stat;
        playerMove.curTown = curTown;
        playerMove.Sword1Skillcool = Sword1Skillcool;
        playerMove.Sword2Skillcool = Sword2Skillcool;
        playerMove.Sword3Skillcool = Sword3Skillcool;
        playerMove.Magic1Skillcool = Magic1Skillcool;
        playerMove.IceEnemySkillcool = IceEnemySkillcool;
        playerMove.Magic3Skillcool = Magic3Skillcool;
        playerMove.AckSkillcool = AckSkillcool;
        playerMove.AckUsingSkillcool = AckUsingSkillcool;
        playerMove.Sword1SkillDmg = Sword1SkillDmg;
        playerMove.Sword2SkillDmg = Sword2SkillDmg;
        playerMove.Sword3SkillDmg = Sword3SkillDmg;
        playerMove.Magic1SkillDmg = Magic1SkillDmg;
        playerMove.IceEnemySkillDmg = IceEnemySkillDmg;
        playerMove.Magic3SkillDmg = Magic3SkillDmg;
        playerMove.Sword1SkillMana = Sword1SkillMana;
        playerMove.Sword2SkillMana = Sword2SkillMana;
        playerMove.Sword3SkillMana = Sword3SkillMana;
        playerMove.Magic1SkillMana = Magic1SkillMana;
        playerMove.IceEnemySkillMana = IceEnemySkillMana;
        playerMove.Magic3SkillMana = Magic3SkillMana;
        playerMove.EqipHealth = EqipHealth;
        playerMove.EqipMp = EqipMp;
        playerMove.EqipAD = EqipAD;
        playerMove.EqipAP = EqipAP;
        playerMove.EqipDefense = EqipDefense;
        playerMove.Eqipspeed = Eqipspeed;
        playerMove.EqipPortionRate = EqipPortionRate;

        setSkillInven.Sword1SkillPoint = Sword1SkillPoint;
        setSkillInven.Sword2SkillPoint = Sword2SkillPoint;
        setSkillInven.Sword3SkillPoint = Sword3SkillPoint;
        setSkillInven.Magic1SkillPoint = Magic1SkillPoint;
        setSkillInven.Magic2SkillPoint = Magic2SkillPoint;
        setSkillInven.Magic3SkillPoint = Magic3SkillPoint;
        setSkillInven.AckSkillPoint = AckSkillPoint;

        setSkillInven.setSkillPoint();

        if (Sword1Rock == 0) playerMove.Sword1Rock = true;
        else
        {
            playerMove.Sword1Rock = false;
            playerMove.Magic1Rock = false;
            setSkillInven.Sword1Rock.gameObject.SetActive(false);
            setSkillInven.Sword1Rock1.gameObject.SetActive(false);
            setSkillInven.Magic1Rock.gameObject.SetActive(false);
            setSkillInven.Magic1Rock1.gameObject.SetActive(false);
        }
        if (Sword2Rock == 0) playerMove.Sword2Rock = true;
        else
        {
            playerMove.Sword2Rock = false;
            playerMove.Magic2Rock = false;
            setSkillInven.Sword2Rock.gameObject.SetActive(false);
            setSkillInven.Sword2Rock2.gameObject.SetActive(false);
            setSkillInven.Magic2Rock.gameObject.SetActive(false);
            setSkillInven.Magic2Rock2.gameObject.SetActive(false);
        }
        if (Sword3Rock == 0) playerMove.Sword3Rock = true;
        else
        {
            playerMove.Sword3Rock = false;
            playerMove.Magic3Rock = false;
            setSkillInven.Sword3Rock.gameObject.SetActive(false);
            setSkillInven.Sword3Rock3.gameObject.SetActive(false);
            setSkillInven.Magic3Rock.gameObject.SetActive(false);
            setSkillInven.Magic3Rock3.gameObject.SetActive(false);
        }
        if (AckRock == 0) playerMove.AckRock = true;
        else
        {
            playerMove.AckRock = false;
            setSkillInven.AacRock.gameObject.SetActive(false);
            setSkillInven.AacRock1.gameObject.SetActive(false);
        }

        if(S0 == 1)
        {
            inventory.AcquireItem(items[0], 1);
            inventory.S0 = true;
        }
        if (S1 == 1)
        {
            inventory.AcquireItem(items[1], 1);
            inventory.S1 = true;
        }
        if (S2 == 1)
        {
            inventory.AcquireItem(items[2], 1);
            inventory.S2 = true;
        }
        if (S3 == 1)
        {
            inventory.AcquireItem(items[3], 1);
            inventory.S3 = true;
        }
        if (S4 == 1)
        {
            inventory.AcquireItem(items[4], 1);
            inventory.S4 = true;
        }
        if (S5 == 1)
        {
            inventory.AcquireItem(items[5], 1);
            inventory.S5 = true;
        }
        if (S6 == 1)
        {
            inventory.AcquireItem(items[6], 1);
            inventory.S6 = true;
        }
        if (S7 == 1)
        {
            inventory.AcquireItem(items[7], 1);
            inventory.S7 = true;
        }
        if (M0 == 1)
        {
            inventory.AcquireItem(items[8], 1);
            inventory.M0 = true;
        }
        if (M1 == 1)
        {
            inventory.AcquireItem(items[9], 1);
            inventory.M1 = true;
        }
        if (M2 == 1)
        {
            inventory.AcquireItem(items[10], 1);
            inventory.M2 = true;
        }
        if (M3 == 1)
        {
            inventory.AcquireItem(items[11], 1);
            inventory.M3 = true;
        }
        if (M4 == 1)
        {
            inventory.AcquireItem(items[12], 1);
            inventory.M4 = true;
        }
        if (M5 == 1)
        {
            inventory.AcquireItem(items[13], 1);
            inventory.M5 = true;
        }
        if (H0 == 1)
        {
            inventory.AcquireItem(items[14], 1);
            inventory.H0 = true;
        }
        if (H1 == 1)
        {
            inventory.AcquireItem(items[15], 1);
            inventory.H1 = true;
        }
        if (H2 == 1)
        {
            inventory.AcquireItem(items[16], 1);
            inventory.H2 = true;
        }
        if (H3 == 1)
        {
            inventory.AcquireItem(items[17], 1);
            inventory.H3 = true;
        }
        if (H4 == 1)
        {
            inventory.AcquireItem(items[18], 1);
            inventory.H4 = true;
        }
        if (H5 == 1)
        {
            inventory.AcquireItem(items[19], 1);
            inventory.H5 = true;
        }
        if (A0 == 1)
        {
            inventory.AcquireItem(items[20], 1);
            inventory.A0 = true;
        }
        if (A1 == 1)
        {
            inventory.AcquireItem(items[21], 1);
            inventory.A1 = true;
        }
        if (A2 == 1)
        {
            inventory.AcquireItem(items[22], 1);
            inventory.A2 = true;
        }
        if (A3 == 1)
        {
            inventory.AcquireItem(items[23], 1);
            inventory.A3 = true;
        }
        if (A4 == 1)
        {
            inventory.AcquireItem(items[24], 1);
            inventory.A4 = true;
        }
        if (A5 == 1)
        {
            inventory.AcquireItem(items[25], 1);
            inventory.A5 = true;
        }
        if (SH0 == 1)
        {
            inventory.AcquireItem(items[26], 1);
            inventory.SH0 = true;
        }
        if (SH1 == 1)
        {
            inventory.AcquireItem(items[27], 1);
            inventory.SH1 = true;
        }
        if (SH2 == 1)
        {
            inventory.AcquireItem(items[28], 1);
            inventory.SH2 = true;
        }
        if (SH3 == 1)
        {
            inventory.AcquireItem(items[29], 1);
            inventory.SH3 = true;
        }
        if (SH4 == 1)
        {
            inventory.AcquireItem(items[30], 1);
            inventory.SH4 = true;
        }
        if (SH5 == 1)
        {
            inventory.AcquireItem(items[31], 1);
            inventory.SH5 = true;
        }
        if (Acc1 == 1)
        {
            inventory.AcquireItem(items[32], 1);
            inventory.Acc1 = true;
        }
        if (Acc2 == 1)
        {
            inventory.AcquireItem(items[33], 1);
            inventory.Acc2 = true;
        }
        if (Portion1 == 1)
        {    
            
            inventory.AcquireItem(items[34], playerMove.HealPortion);
            inventory.Portion1 = true;
        }
        if (Portion2 == 1)
        {
            inventory.AcquireItem(items[35], playerMove.ManaPortion);
            inventory.Portion2 = true;
        }
        endLoad = true;
    }
}
