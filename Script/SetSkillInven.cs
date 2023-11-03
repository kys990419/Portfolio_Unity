using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSkillInven : MonoBehaviour
{
    public static bool SkillSetActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    public PlayerMove playerMove;
    public Image Sword1Rock;
    public Image Sword2Rock;
    public Image Sword3Rock;
    public Image Magic1Rock;
    public Image Magic2Rock;
    public Image Magic3Rock;
    public Image Sword1Rock1;
    public Image Sword2Rock2;
    public Image Sword3Rock3;
    public Image Magic1Rock1;
    public Image Magic2Rock2;
    public Image Magic3Rock3;
    public Image AacRock;
    public Image AacRock1;
    public Text Sword1SkillPointTxt;
    public Text Sword2SkillPointTxt;
    public Text Sword3SkillPointTxt;
    public Text Magic1SkillPointTxt;
    public Text Magic2SkillPointTxt;
    public Text Magic3SkillPointTxt;
    public Text AckSkillPointTxt;
    public Text SkillPointTxt;
    public Text RankUpTxt;
    public Text RankUpTxt2;
    public int Sword1SkillPoint;
    public int Sword2SkillPoint;
    public int Sword3SkillPoint;
    public int Magic1SkillPoint;
    public int Magic2SkillPoint;
    public int Magic3SkillPoint;
    public int AckSkillPoint;
    string s1 = "견습 용병단원";
    string s2 = "정식 용병단원";
    string s3 = "베테랑 용병단원";
    string s4 = "용병단장";

    void Start()
    {
        
    }
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[29]);
            SkillSetActivated = !SkillSetActivated;

            if (SkillSetActivated)
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
    public void setSkillPoint()
    {
        Sword1SkillPointTxt.text = Sword1SkillPoint + " / 3";
        Magic1SkillPointTxt.text = Magic1SkillPoint + " / 3";
        Sword2SkillPointTxt.text = Sword2SkillPoint + " / 3";
        Magic2SkillPointTxt.text = Magic2SkillPoint + " / 3";
        Sword3SkillPointTxt.text = Sword3SkillPoint + " / 3";
        Magic3SkillPointTxt.text = Magic3SkillPoint + " / 3";
        AckSkillPointTxt.text = AckSkillPoint + " / 1";
        SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
    }
    public void unlockSkill1()
    {
        RankUpTxt.text = "<color=#4AFF00>" + s1 + "</color>" + "으로 승격하셨습니다.";
        RankUpTxt2.text = "새로운 스킬이 열렸습니다.";
        Invoke("RankUptxtOut",5f);
        Sword1SkillPoint++;
        Magic1SkillPoint++;
        Sword1SkillPointTxt.text = Sword1SkillPoint + " / 3";
        Magic1SkillPointTxt.text = Magic1SkillPoint + " / 3";
        Sword1Rock.gameObject.SetActive(false);
        Sword1Rock1.gameObject.SetActive(false);
        playerMove.Sword1Rock = false;
        Magic1Rock.gameObject.SetActive(false);
        Magic1Rock1.gameObject.SetActive(false);
        playerMove.Magic1Rock = false;
        SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
    }
    public void unlockSkill2()
    {
        RankUpTxt.text = "<color=#FFAB00>" + s2 + "</color>" + "으로 승격하셨습니다.";
        RankUpTxt2.text = "새로운 스킬이 열렸습니다.";
        Invoke("RankUptxtOut", 5f);
        Sword2SkillPoint++;
        Magic2SkillPoint++;
        Sword2SkillPointTxt.text = Sword2SkillPoint + " / 3";
        Magic2SkillPointTxt.text = Magic2SkillPoint + " / 3";
        Sword2Rock.gameObject.SetActive(false);
        Sword2Rock2.gameObject.SetActive(false);
        playerMove.Sword2Rock = false;
        Magic2Rock.gameObject.SetActive(false);
        Magic2Rock2.gameObject.SetActive(false);
        playerMove.Magic2Rock = false;
        SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
    }
    public void unlockSkill3()
    {
        RankUpTxt.text = "<color=#FF00ED>" + s3 + "</color>" + "으로 승격하셨습니다.";
        RankUpTxt2.text = "새로운 스킬이 열렸습니다.";
        Invoke("RankUptxtOut", 5f);
        Sword3SkillPoint++;
        Magic3SkillPoint++;
        Sword3SkillPointTxt.text = Sword3SkillPoint + " / 3";
        Magic3SkillPointTxt.text = Magic3SkillPoint + " / 3";
        Sword3Rock.gameObject.SetActive(false);
        Sword3Rock3.gameObject.SetActive(false);
        playerMove.Sword3Rock = false;
        Magic3Rock.gameObject.SetActive(false);
        Magic3Rock3.gameObject.SetActive(false);
        playerMove.Magic3Rock = false;
        SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
    }
    public void unlockSkill4()
    {
        RankUpTxt.text = "<color=#FF0000>" + s4 + "</color>" + "으로 승격하셨습니다.";
        RankUpTxt2.text = "새로운 스킬이 열렸습니다.";
        Invoke("RankUptxtOut", 5f);
        AckSkillPoint++;
        AacRock.gameObject.SetActive(false);
        AacRock1.gameObject.SetActive(false);
        playerMove.AckRock = false;
        SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
        AckSkillPointTxt.text = "1 / 1";
    }
    void RankUptxtOut()
    {
        RankUpTxt.text = "";
        RankUpTxt2.text = "";
    }
    public void updateSkill(int num)
    {   
        if(playerMove.SkillPoint > 0)
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[27]);
            if (num == 1 && Sword1SkillPoint < 3 && !playerMove.Sword1Rock)
            {
                Sword1SkillPoint++;
                Sword1SkillPointTxt.text = Sword1SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;

                playerMove.Sword1SkillDmg += 50;
                playerMove.Sword1Skillcool -= 2;
                playerMove.Sword1SkillMana -= 10;
            }
            if (num == 2 && Sword2SkillPoint < 3 && !playerMove.Sword2Rock)
            {
                Sword2SkillPoint++;
                Sword2SkillPointTxt.text = Sword2SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
                playerMove.Sword2SkillDmg += 50;
                playerMove.Sword2Skillcool -= 2;
                playerMove.Sword2SkillMana -= 10;
            }
            if (num == 3 && Sword3SkillPoint < 3 && !playerMove.Sword3Rock)
            {
                Sword3SkillPoint++;
                Sword3SkillPointTxt.text = Sword3SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
                playerMove.Sword3SkillDmg += 50;
                playerMove.Sword3Skillcool -= 2;
                playerMove.Sword3SkillMana -= 10;
            }
            if (num == 4 && Magic1SkillPoint < 3 && !playerMove.Magic1Rock)
            {
                Magic1SkillPoint++;
                Magic1SkillPointTxt.text = Magic1SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
                playerMove.Magic1SkillDmg += 25;
                playerMove.Magic1Skillcool -= 2;
                playerMove.Magic1SkillMana -= 10;
            }
            if (num == 5 && Magic2SkillPoint < 3 && !playerMove.Magic2Rock)
            {
                Magic2SkillPoint++;
                Magic2SkillPointTxt.text = Magic2SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
                playerMove.IceEnemySkillDmg += 0;
                playerMove.IceEnemySkillcool -= 2;
                playerMove.IceEnemySkillMana -= 10;
            }
            if (num == 6 && Magic3SkillPoint < 3 && !playerMove.Magic3Rock)
            {
                Magic3SkillPoint++;
                Magic3SkillPointTxt.text = Magic3SkillPoint + " / 3";
                playerMove.SkillPoint--;
                SkillPointTxt.text = "스킬 포인트 : " + playerMove.SkillPoint;
                playerMove.Magic3SkillDmg += 50;
                playerMove.Magic3Skillcool -= 2;
                playerMove.Magic3SkillMana -= 10;
            }
        }
        else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
    }
}
