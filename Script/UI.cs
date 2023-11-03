using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public Text PlayerDieTxt;
    public GameObject LodingUI;
    public Sprite[] LodingImgLand;
    public Image LodingImg;
    public Text LodingText;
    public Image LodingBar;
    public GameObject Space;
    public Image SpaceImg;
    public Text spaceText;
    public Image Panel;
    float time = 0f;
    float spacetime = 0f;
    float F_time = 1f;
    float L_time = 3f;
    public Slider HpBar;
    public Slider MpBar;
    public Slider HpBarBack;
    public Slider MpBarBack;
    public Text text;
    bool backHit;
    bool backHit2;
    PlayerMove playerMove;
    public Image swordImg;
    public Image magicImg;
    public Text goldText;
    public Image MagicUI;
    public Image SwordUI;
    public Image Sword1Cool;
    public Image Sword2Cool;
    public Image Sword3Cool;
    public Image Magic2Cool;
    public Image Magic3Cool;
    public Image IncEnemyCool;
    public Image AckCool;
    public Text Sword1CoolText;
    public Text Sword2CoolText;
    public Text Sword3CoolText;
    public Text Magic2CoolText;
    public Text Magic3CoolText;
    public Text IceEnemyCoolText;
    public Text AckCoolText;
    public Text curHealText;
    public Text curManaText;
    public float Sword1curcool;
    public float Sword2curcool;
    public float Sword3curcool;
    public float Magic2curcool;
    public float Magic3curcool;
    public float IceEnemycurcool;
    public float Ackcurcool;
    public float Ackusingcool;
    string[] LodingTextRand = new string[6];
    void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }
    void Start()
    {
        LodingTextRand[0] = "Tip ) 구르기 버튼을 이용하여 공격을 회피할 수 있습니다.";
        LodingTextRand[1] = "Tip ) 데릭은 18살입니다.";
        LodingTextRand[2] = "Tip ) 스킬을 찍을 수록 쿨타임과 데미지가 증가합니다.";
        LodingTextRand[3] = "Tip ) 획득한 골드로 아이템을 구매할 수 있습니다.";
        LodingTextRand[4] = "Tip ) 전직 퀘스트를 통해 전직이 가능합니다.";
        HpBar.value = (float)playerMove.curHealth / (float)playerMove.maxHealth;
        MpBar.value = (float)playerMove.curMp / (float)playerMove.maxMp;
        HpBarBack.value = (float)playerMove.curHealth / (float)playerMove.maxHealth;
        MpBarBack.value = (float)playerMove.curMp / (float)playerMove.maxMp;
        Sword2Cool.fillAmount = 0f;
        Sword3Cool.fillAmount = 0f;
        Magic2Cool.fillAmount = 0f;
        Magic3Cool.fillAmount = 0f;
    }
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0,1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;
        Panel.gameObject.SetActive(false);
        
        LodingUI.gameObject.SetActive(true);
        int rand = Random.Range(0, 5);

        LodingImg.gameObject.GetComponent<Image>().sprite = LodingImgLand[rand];
        LodingText.text = LodingTextRand[rand];

        while (time < 3f)
        {
            time += Time.deltaTime / F_time;
            LodingBar.fillAmount = Mathf.Lerp(0, 1, time);
            yield return null;
        }
        LodingUI.gameObject.SetActive(false);
        time = 0f;
        playerMove.isPortal = false;
        playerMove.isJump = false;
        Panel.gameObject.SetActive(true);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        LodingBar.fillAmount = 0f;
        Panel.gameObject.SetActive(false);
        yield return null;
    }
    public void spaceUi(int num)
    {
        Space.gameObject.SetActive(true);
        if (num == 0)
        {
            spaceText.text = "루테란 마을";
        }
        if (num == 1)
        {
            spaceText.text = "아르테미스 마을";
        }
        if (num == 2)
        {
            spaceText.text = "아르데타인 마을";
        }
        if (num == 3)
        {
            spaceText.text = "루테란 평원";
        }
        if (num == 4)
        {
            spaceText.text = "아르테미스 협곡";
        }
        if (num == 5)
        {
            spaceText.text = "아르데타인 무법지대";
        }
        StartCoroutine(outSpaceUI());
    }
    IEnumerator outSpaceUI()
    {
        yield return new WaitForSeconds(3f);
        spacetime = 0f;
        Color alpha1 = spaceText.color;
        Color alpha2 = spaceText.color;
        while (alpha1.a > 0f)
        {
            spacetime += Time.deltaTime / F_time;
            alpha1.a = Mathf.Lerp(1, 0, spacetime);
            alpha2.a = Mathf.Lerp(1, 0, spacetime);
            spaceText.color = alpha1;
            SpaceImg.color = alpha2;
            yield return null;
        }
        Space.gameObject.SetActive(false);
        spacetime = 0f;
        while (alpha1.a < 1f)
        {
            spacetime += Time.deltaTime / F_time;
            alpha1.a = Mathf.Lerp(0, 1, spacetime);
            alpha2.a = Mathf.Lerp(0, 1, spacetime);
            spaceText.color = alpha1;
            SpaceImg.color = alpha2;
            yield return null;
        }
        yield return null;
    }
    public void Magic3CoolonM3()
    {
        Magic3Cool.fillAmount = 1f;
        StartCoroutine("CooltimeMagic3");

        Magic3curcool = playerMove.Magic3Skillcool;
        Magic3CoolText.gameObject.SetActive(true);
        Magic3CoolText.text = "" + Magic3curcool;
        StartCoroutine("CoolTimeCounterM3");
    }

    IEnumerator CooltimeMagic3()
    {
        while (Magic3Cool.fillAmount > 0)
        {
            Magic3Cool.fillAmount -= 1 * Time.deltaTime / playerMove.Magic3Skillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterM3()
    {
        while (Magic3curcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Magic3curcool -= 1.0f;
            Magic3CoolText.text = "" + Magic3curcool;
        }
        Magic3CoolText.gameObject.SetActive(false);
        yield break;
    }
    public void Magic3CoolonM2()
    {
        Magic2Cool.fillAmount = 1f;
        StartCoroutine("CooltimeM2");

        Magic2curcool = playerMove.Magic1Skillcool;
        Magic2CoolText.gameObject.SetActive(true);
        Magic2CoolText.text = "" + Magic2curcool;
        StartCoroutine("CoolTimeCounterM2");
    }

    IEnumerator CooltimeM2()
    {
        while (Magic2Cool.fillAmount > 0)
        {
            Magic2Cool.fillAmount -= 1 * Time.deltaTime / playerMove.Magic1Skillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterM2()
    {
        while (Magic2curcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Magic2curcool -= 1.0f;
            Magic2CoolText.text = "" + Magic2curcool;
        }
        Magic2CoolText.gameObject.SetActive(false);
        yield break;
    }
    public void Magic3CoolonS1()
    {
        Sword1Cool.fillAmount = 1f;
        StartCoroutine("CooltimeS1");

        Sword1curcool = playerMove.Sword1Skillcool;
        Sword1CoolText.gameObject.SetActive(true);
        Sword1CoolText.text = "" + Sword1curcool;
        StartCoroutine("CoolTimeCounterS1");
    }

    IEnumerator CooltimeS1()
    {
        while (Sword1Cool.fillAmount > 0)
        {
            Sword1Cool.fillAmount -= 1 * Time.deltaTime / playerMove.Sword1Skillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterS1()
    {
        while (Sword1curcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Sword1curcool -= 1.0f;
            Sword1CoolText.text = "" + Sword1curcool;
        }
        Sword1CoolText.gameObject.SetActive(false);
        yield break;
    }
    public void Magic3CoolonS2()
    {
        Sword2Cool.fillAmount = 1f;
        StartCoroutine("CooltimeS2");

        Sword2curcool = playerMove.Sword2Skillcool;
        Sword2CoolText.gameObject.SetActive(true);
        Sword2CoolText.text = "" + Sword2curcool;
        StartCoroutine("CoolTimeCounterS2");
    }

    IEnumerator CooltimeS2()
    {
        while (Sword2Cool.fillAmount > 0)
        {
            Sword2Cool.fillAmount -= 1 * Time.deltaTime / playerMove.Sword2Skillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterS2()
    {
        while (Sword2curcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Sword2curcool -= 1.0f;
            Sword2CoolText.text = "" + Sword2curcool;
        }
        Sword2CoolText.gameObject.SetActive(false);
        yield break;
    }
    public void Magic3CoolonS3()
    {
        Sword3Cool.fillAmount = 1f;
        StartCoroutine("CooltimeS3");

        Sword3curcool = playerMove.Sword3Skillcool;
        Sword3CoolText.gameObject.SetActive(true);
        Sword3CoolText.text = "" + Sword3curcool;
        StartCoroutine("CoolTimeCounterS3");
    }
    IEnumerator CooltimeS3()
    {
        while (Sword3Cool.fillAmount > 0)
        {
            Sword3Cool.fillAmount -= 1 * Time.deltaTime / playerMove.Sword3Skillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterS3()
    {
        while (Sword3curcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Sword3curcool -= 1.0f;
            Sword3CoolText.text = "" + Sword3curcool;
        }
        Sword3CoolText.gameObject.SetActive(false);
        yield break;
    }
    public void IceEnemyCoolon()
    {
        IncEnemyCool.fillAmount = 1f;
        StartCoroutine("IceCooltime");

        IceEnemycurcool = playerMove.IceEnemySkillcool;
        IceEnemyCoolText.gameObject.SetActive(true);
        IceEnemyCoolText.text = "" + IceEnemycurcool;
        StartCoroutine("IceTimeCounter");
    }
    IEnumerator IceCooltime()
    {
        while (IncEnemyCool.fillAmount > 0)
        {
            IncEnemyCool.fillAmount -= 1 * Time.deltaTime / playerMove.IceEnemySkillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator IceTimeCounter()
    {
        while (IceEnemycurcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            IceEnemycurcool -= 1.0f;
            IceEnemyCoolText.text = "" + IceEnemycurcool;
        }
        IceEnemyCoolText.gameObject.SetActive(false);
        yield break;
    }
    public void Ackcoolon()
    {
        AckCool.fillAmount = 1f;
        StartCoroutine("CooltimeAck");

        Ackcurcool = playerMove.AckSkillcool;
        //AckCoolText.gameObject.SetActive(true);
        //AckCoolText.text = "" + Ackcurcool;
        StartCoroutine("CoolTimeCounterAck");
    }
    IEnumerator CooltimeAck()
    {
        while (AckCool.fillAmount > 0)
        {
            AckCool.fillAmount -= 1 * Time.deltaTime / playerMove.AckSkillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterAck()
    {
        while (Ackcurcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Ackcurcool -= 1.0f;
            //AckCoolText.text = "" + Ackcurcool;
        }
        //AckCoolText.gameObject.SetActive(false);
        playerMove.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = playerMove.Playermat[0];
        playerMove.isAck = false;
        playerMove.speed -= 2;
        playerMove.MotionTrail.SetActive(false);
        Ackcoolon2();
        yield break;
    }
    public void Ackcoolon2()
    {
        AckCool.fillAmount = 1f;
        StartCoroutine("CooltimeAck2");

        Ackcurcool = playerMove.AckSkillcool;
        AckCoolText.gameObject.SetActive(true);
        AckCoolText.text = "" + Ackcurcool;
        StartCoroutine("CoolTimeCounterAck2");
    }
    IEnumerator CooltimeAck2()
    {
        while (AckCool.fillAmount > 0)
        {
            AckCool.fillAmount -= 1 * Time.deltaTime / playerMove.AckSkillcool;

            yield return null;
        }
        yield break;
    }
    IEnumerator CoolTimeCounterAck2()
    {
        while (Ackcurcool > 0)
        {
            yield return new WaitForSeconds(1.0f);

            Ackcurcool -= 1.0f;
            AckCoolText.text = "" + Ackcurcool;
        }
        AckCoolText.gameObject.SetActive(false);
        yield break;
    }
    void Update()
    {
        Handler1();
        Handler2();
        PlayerDmg();
        PlayerAttack();
    }
    void Handler1()
    {
        HpBar.value = Mathf.Lerp(HpBar.value,(float)playerMove.curHealth / (float)playerMove.maxHealth,Time.deltaTime * 5f);

        if(backHit)
        {
            HpBarBack.value = Mathf.Lerp(HpBarBack.value, (float)playerMove.curHealth / (float)playerMove.maxHealth, Time.deltaTime * 5f);
            if (HpBar.value >= HpBarBack.value - 0.01f)
            {
                backHit = false;
                HpBarBack.value = HpBar.value;
            }
        }
    }
    void Handler2()
    {
        MpBar.value = Mathf.Lerp(MpBar.value, (float)playerMove.curMp / (float)playerMove.maxMp, Time.deltaTime * 5f);

        if (backHit2)
        {
            MpBarBack.value = Mathf.Lerp(MpBarBack.value, (float)playerMove.curMp / (float)playerMove.maxMp, Time.deltaTime * 5f);
            if (MpBar.value >= MpBarBack.value - 0.01f)
            {
                backHit2 = false;
                MpBarBack.value = MpBar.value;
            }
        }
    }
    void PlayerDmg()
    {   
        if(playerMove.isDamage) Invoke("BackHpFun", 0.5f);
    }
    void BackHpFun()
    {
        backHit = true;
    }
    void PlayerAttack()
    {
        if (playerMove.flag) Invoke("BackHpFun2", 0.5f);
    }
    void BackHpFun2()
    {
        backHit2 = true;
    }
    public void NoMana()
    {
        text.text = "마나(MP)가 부족합니다.";
        Invoke("FloatingTextOut", 0.5f);
    }
    public void GetItem(GameObject nearObject)
    {
        ItemPickUp item = nearObject.GetComponent<ItemPickUp>();
        text.text = item.item.itemName + " 을(를) 획득하였습니다.";
        Invoke("FloatingTextOut", 1f);
    }
    public void NoHealPortion()
    {
        text.text = "체력(HP)포션이 부족합니다.";
        Invoke("FloatingTextOut", 0.5f);
    }
    public void NoManaPortion()
    {
        text.text = "마나(MP)포션이 부족합니다.";
        Invoke("FloatingTextOut", 0.5f);
    }
    public void curHealNum(int curHealN)
    {   
        curHealText.text = curHealN + "";
    }
    public void curManaNum(int curManaN)
    {
        curManaText.text = curManaN + "";
    }
    public void WaitSkillCool()
    {
        text.text = "스킬 시전 사용시간이 아닙니다.";
        Invoke("FloatingTextOut", 0.5f);
    }

    void FloatingTextOut()
    {
        text.text = "";
    }
}