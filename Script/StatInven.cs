using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatInven : MonoBehaviour
{
    public static bool StatInvenActivated = false;

    // 필요한 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase;
    public PlayerMove playerMove;
    public Text statText;
    public Text HealText;
    public Text ManaText;
    public Text ADText;
    public Text APText;
    public Text DefenseText;
    public Text SpeedText;
    public Text PortionRateText;
    public Text RankText;
    void Start()
    {
        float heal = playerMove.maxHealth + playerMove.EqipHealth;
        float Mana = playerMove.maxMp + playerMove.EqipMp;
        int AD = playerMove.AD + playerMove.EqipAD;
        int AP = playerMove.AP + playerMove.EqipAP;
        int Defense = playerMove.Defense + playerMove.EqipDefense;
        float speed = playerMove.speed + playerMove.Eqipspeed;
        float PortionRate = playerMove.PortionRate + playerMove.EqipPortionRate;

        HealText.text = "" + heal;
        ManaText.text = "" + Mana;
        ADText.text = "" + AD;
        APText.text = "" + AP;
        DefenseText.text = "" + Defense;
        SpeedText.text = "" + speed;
        PortionRateText.text = "" + PortionRate;
    }
    void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[29]);
            StatInvenActivated = !StatInvenActivated;

            if (StatInvenActivated)
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
    public void updateStat(int num)
    {   
        if(playerMove.Stat > 0)
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[27]);
            if (num == 0)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.maxHealth += 10;
                ChangeWeaponUpdateStat();
                //HealText.text = "" + playerMove.maxHealth;
            }
            if (num == 1)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.maxMp += 10;
                ChangeWeaponUpdateStat();
                //ManaText.text = "" + playerMove.maxMp;
            }
            if (num == 2)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.AD++;
                ChangeWeaponUpdateStat();
                //ADText.text = "" + playerMove.AD;
            }
            if (num == 3)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.AP++;
                ChangeWeaponUpdateStat();
                //APText.text = "" + playerMove.AP;
            }
            if (num == 4)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.Defense++;
                ChangeWeaponUpdateStat();
                //DefenseText.text = "" + playerMove.Defense;
            }
            if (num == 5)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.speed += 0.05f;
                ChangeWeaponUpdateStat();
                //SpeedText.text = "" + playerMove.speed;
            }
            if (num == 6)
            {
                playerMove.Stat--;
                statText.text = "스텟 포인트 : " + playerMove.Stat;
                playerMove.PortionRate++;
                ChangeWeaponUpdateStat();
                //PortionRateText.text = playerMove.PortionRate + "%";
            }
        }
        else SoundManager.instace.SFXPlay("Melee", playerMove.clip[5]);
    }
    public void ChangeWeaponUpdateStat()
    {
        float heal = playerMove.maxHealth + playerMove.EqipHealth;
        float Mana = playerMove.maxMp + playerMove.EqipMp;
        int AD = playerMove.AD + playerMove.EqipAD;
        int AP = playerMove.AP + playerMove.EqipAP;
        int Defense = playerMove.Defense + playerMove.EqipDefense;
        float speed = playerMove.speed + playerMove.Eqipspeed;
        float PortionRate = playerMove.PortionRate + playerMove.EqipPortionRate;

        HealText.text = "" + heal;
        ManaText.text = "" + Mana;
        ADText.text = "" + AD;
        APText.text = "" + AP;
        DefenseText.text = "" + Defense;
        SpeedText.text = "" + speed.ToString("F2");
        PortionRateText.text = "" + PortionRate;
    }
}
