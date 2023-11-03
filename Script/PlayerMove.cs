using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Minimap;
    public QuestClearList questClearList;
    public bool Hal;
    public bool Zun;
    public bool Gang;
    public bool onCanon;
    public bool onGold;
    public bool onGreen;
    public GameObject MyQuestUI;
    public int MonsterKill;
    public Slot slot;
    public Inventory inventory;
    public bool isQuest;
    public GameObject KillBoss;
    public GameObject intanKillBoss;
    public GameObject[] Map;
    public GameObject[] IntanMonsterParticle;
    public GameObject[] MonsterParticle;
    bool makeM0;
    bool makeM1;
    bool makeM2;
    bool makeM3;
    bool makeM4;
    bool makeM5;
    bool makeM6;
    bool makeM7;
    bool makeM8;
    bool makeM9;
    public Transform[] mab1Pos;
    public GameObject[] mab1Monster;
    public GameObject[] mab1intanMonster;
    public Transform[] mab2Pos;
    public GameObject[] mab2Monster;
    public GameObject[] mab2intanMonster;
    public Transform[] mab3Pos;
    public GameObject[] mab3Monster;
    public GameObject[] mab3intanMonster;
    float time = 0f;
    float F_time = 1f;
    public bool Acc1;
    bool Acc1_1;
    public bool Acc2;
    bool Acc2_1;
    bool ContactWall;
    bool bow1;
    bool goAck;
    bool speeddodge;
    public bool nododge;
    public Material[] Skymaterial;
    public bool startGame;
    public KeyBtnClick keyBtnClick;
    public GameObject hide;
    public bool inTown;
    public int Level;
    public Save save;
    public GameObject[] Boss;
    public GameObject intancurBoss;
    public AudioClip[] clip;
    public AudioClip[] bglist;
    public Vector3 vec;
    Enemy enemy;
    public Animator anim;
    Rigidbody rigid;
    public UI ui;
    Material mat;
    Vector3 moveDirection;
    Vector3 dodgeVec;
    public SetSkillInven setSkillInven;
    public StatInven statInven;
    public Material[] Playermat = new Material[2];
    public Transform cameraArm;
    public GameObject nearObject;
    public GameObject[] weapons;
    public GameObject[] Backweapons;
    public GameObject[] Item;
    public BoxCollider[] meleeArea;
    BoxCollider Magic0_1Area;
    BoxCollider Magic0_2Area;
    BoxCollider Magic3Area;
    BoxCollider BowArea1;
    BoxCollider BowArea2;
    BoxCollider BowArea3;
    BoxCollider BowArea1_1;
    BoxCollider BowArea2_1;
    BoxCollider BowArea3_1;
    public GameObject intanBullet1;
    public GameObject intanBullet1_2;
    public GameObject intanBullet2;
    public GameObject intanBullet3;
    public GameObject IceEnemyBullet;
    public GameObject intanSword2;
    public GameObject intanBow;
    public GameObject intanBow2;
    public GameObject intanBow3;
    public GameObject intanBow1_1;
    public GameObject intanBow2_1;
    public GameObject intanBow3_1;
    public GameObject prefeb_FloatingText;
    public GameObject BowObj;
    public float rate;
    public Transform[] Town;
    public Transform bulletPos;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public Transform IcePos;
    public Transform Sword2Pos;
    public Transform BowPos;
    public Transform BowPos2;
    public Transform BowPos3;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject HealParticle;
    public GameObject ManaParticle;
    public GameObject Magic3Floor;
    public GameObject Sword3Floor;
    public GameObject IceEnemy;
    public GameObject Sword1Slash;
    public GameObject Sword1Slash2;
    public GameObject Sword1Slash3;
    public GameObject Sword1Particle;
    public GameObject Sword2Particle;
    public GameObject StunnedParticle;
    public GameObject AckParticle;
    public GameObject MotionTrail;
    public GameObject RankupParticle;
    //public GameObject SwapParticle;
    public LayerMask layer;
    public float EnemyRadius;
    public Collider[] col;
    public Transform target;
    public bool[] hasItems;
    public bool flag;
    public bool isJump;
    bool isMove;
    bool rDown;
    bool sDown;
    bool eDown;
    bool Jdown;
    bool Ddown;
    bool Rdown;
    bool KeyZdown;
    bool KeyXdown;
    bool Key1down;
    bool Key2down;
    bool Key3down;
    bool Key4down;
    bool Key5down;
    bool Key6down;
    bool Key7down;
    bool isDodge;
    bool isSwap;
    bool isDrink;
    bool isHeal;
    bool isMana;
    bool isWalk;
    bool isRun;
    public bool isdun;
    public bool isPortal;
    public bool isAck;
    public float Sword1Skillcool;
    public float Sword2Skillcool;
    public float Sword3Skillcool;
    public float Magic1Skillcool;
    public float IceEnemySkillcool;
    public float Magic3Skillcool;
    public float AckSkillcool;
    public float AckUsingSkillcool;
    public float Sword1SkillDmg;
    public float Sword2SkillDmg;
    public float Sword3SkillDmg;
    public float Magic1SkillDmg;
    public float IceEnemySkillDmg;
    public float Magic3SkillDmg;
    public float Sword1SkillMana;
    public float Sword2SkillMana;
    public float Sword3SkillMana;
    public float Magic1SkillMana;
    public float IceEnemySkillMana;
    public float Magic3SkillMana;
    public bool isDamage;
    int curSwordIndex = 0;
    int curMagicIndex = 8;
    bool curWeapon;
    int potionIndex = -1;
    public float smoothness = 10f;
    public int Gold = 100;
    public int HealPortion;
    public int ManaPortion;
    public int SkillPoint;
    public int Stat = 0;
    public float maxHealth;
    public float curHealth;
    public float maxMp;
    public float curMp;
    public int AD;
    public int AP;
    public int Defense;
    public float speed;
    public float PortionRate;
    public bool isBoss;
    //현재 플레이어가 끼고 있는 장비 스텟넣기
    public int EqipHealth;
    public int EqipMp;
    public int EqipAD;
    public int EqipAP;
    public int EqipDefense;
    public float Eqipspeed;
    public float EqipPortionRate;
    public bool Sword1Rock = true;
    public bool Sword2Rock = true;
    public bool Sword3Rock = true;
    public bool Magic1Rock = true;
    public bool Magic2Rock = true;
    public bool Magic3Rock = true;
    public bool AckRock = true;
    public Transform[] PlayerBossPos;
    public Transform[] BossPos;
    public GameObject[] EnterBossTrigger;
    public GameObject[] EnterBossCollider;
    public int curTown;
    public int curBoss = -1;

    void Start()
    {
        Minimap.gameObject.SetActive(true);
        flag = true;

        SoundManager.instace.BgSoundPlay(bglist[4]);
        save.GameLoad();

        InvokeRepeating("enemyaround", 0, 0.2f);
        ui.goldText.text = Gold + "";
        ui.curHealNum(HealPortion);
        ui.curManaNum(ManaPortion);
        statInven.statText.text = "스텟 포인트 : " + Stat;
        if (Level == 1) statInven.RankText.text = "<color=#4AFF00>" + "견습 용병단원" + "</color>";
        else if(Level == 2) statInven.RankText.text = "<color=#FFAB00>" + "정식 용병단원" + "</color>";
        else if(Level == 3) statInven.RankText.text = "<color=#FF00ED>" + "베테랑 용병단원" + "</color>";
        else if(Level == 4) statInven.RankText.text = "<color=#FF0000>" + "용병단장" + "</color>";
        SetStat();
        EqipHealth = 30;
        EqipAD = 1;
        EqipAP = 1;
        EqipDefense = 1;
        Eqipspeed = 1;
        statInven.ChangeWeaponUpdateStat();
    }
    void Awake()
    {   
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        ui = GetComponent<UI>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }
    void Update()
    {
        if(isdun) resetMonster();
        goStart();
        Move();
        Attack();
        Jump();
        Dodge();
        Swap();
        Interation();
        Drink();
        Magic2();
        Magic3();
        Sword1();
        Sword2();
        Sword3();
        DoIceEnemy();
        Awakening();
        SkillDown();
        noWall();
        if (Acc1 && !Acc1_1)
        {
            Acc1_1 = true;
            Invoke("goAcc1",1f);
        }
        if (Acc2 && !Acc2_1)
        {
            Acc2_1 = true;
            Invoke("goAcc2", 1f);
        }
    }
    public void MakeMoster()
    {  
        if(curTown == 0)
        {    
            for(int i=0; i<10;i++)
            {
                mab1intanMonster[i] = Instantiate(mab1Monster[i%2], mab1Pos[i].position, mab1Pos[i].rotation);
            }
        }
        else if (curTown == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                mab2intanMonster[i] = Instantiate(mab2Monster[i % 2], mab2Pos[i].position, mab2Pos[i].rotation);
            }
        }
        else if (curTown == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                mab3intanMonster[i] = Instantiate(mab3Monster[i % 2], mab3Pos[i].position, mab3Pos[i].rotation);
            }
        }
    }
    void resetMonster()
    {
        if (curTown == 0)
        {
            for(int i=0;i<10;i++)
            {
                if(i == 0 && mab1intanMonster[0] == null && !makeM0)
                {
                    MonsterKill++;
                    makeM0 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 1 && mab1intanMonster[1] == null && !makeM1)
                {
                    MonsterKill++;
                    makeM1 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 2 && mab1intanMonster[2] == null && !makeM2)
                {
                    MonsterKill++;
                    makeM2 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 3 && mab1intanMonster[3] == null && !makeM3)
                {
                    MonsterKill++;
                    makeM3 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 4 && mab1intanMonster[4] == null && !makeM4)
                {
                    MonsterKill++;
                    makeM4 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 5 && mab1intanMonster[5] == null && !makeM5)
                {
                    MonsterKill++;
                    makeM5 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 6 && mab1intanMonster[6] == null && !makeM6)
                {
                    MonsterKill++;
                    makeM6 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 7 && mab1intanMonster[7] == null && !makeM7)
                {
                    MonsterKill++;
                    makeM7 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 8 && mab1intanMonster[8] == null && !makeM8)
                {
                    MonsterKill++;
                    makeM8 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 9 && mab1intanMonster[9] == null && !makeM9)
                {
                    MonsterKill++;
                    makeM9 = true;
                    StartCoroutine(resetMonster2(i));
                }
            }
        }
        else if (curTown == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 && mab2intanMonster[0] == null && !makeM0)
                {
                    MonsterKill++;
                    makeM0 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 1 && mab2intanMonster[1] == null && !makeM1)
                {
                    MonsterKill++;
                    makeM1 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 2 && mab2intanMonster[2] == null && !makeM2)
                {
                    MonsterKill++;
                    makeM2 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 3 && mab2intanMonster[3] == null && !makeM3)
                {
                    MonsterKill++;
                    makeM3 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 4 && mab2intanMonster[4] == null && !makeM4)
                {
                    MonsterKill++;
                    makeM4 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 5 && mab2intanMonster[5] == null && !makeM5)
                {
                    MonsterKill++;
                    makeM5 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 6 && mab2intanMonster[6] == null && !makeM6)
                {
                    MonsterKill++;
                    makeM6 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 7 && mab2intanMonster[7] == null && !makeM7)
                {
                    MonsterKill++;
                    makeM7 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 8 && mab2intanMonster[8] == null && !makeM8)
                {
                    MonsterKill++;
                    makeM8 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 9 && mab2intanMonster[9] == null && !makeM9)
                {
                    MonsterKill++;
                    makeM9 = true;
                    StartCoroutine(resetMonster2(i));
                }
            }
        }
        if (curTown == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 && mab3intanMonster[0] == null && !makeM0)
                {
                    MonsterKill++;
                    makeM0 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 1 && mab3intanMonster[1] == null && !makeM1)
                {
                    MonsterKill++;
                    makeM1 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 2 && mab3intanMonster[2] == null && !makeM2)
                {
                    MonsterKill++;
                    makeM2 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 3 && mab3intanMonster[3] == null && !makeM3)
                {
                    MonsterKill++;
                    makeM3 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 4 && mab3intanMonster[4] == null && !makeM4)
                {
                    MonsterKill++;
                    makeM4 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 5 && mab3intanMonster[5] == null && !makeM5)
                {
                    MonsterKill++;
                    makeM5 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 6 && mab3intanMonster[6] == null && !makeM6)
                {
                    MonsterKill++;
                    makeM6 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 7 && mab3intanMonster[7] == null && !makeM7)
                {
                    MonsterKill++;
                    makeM7 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 8 && mab3intanMonster[8] == null && !makeM8)
                {
                    MonsterKill++;
                    makeM8 = true;
                    StartCoroutine(resetMonster2(i));
                }
                if (i == 9 && mab3intanMonster[9] == null && !makeM9)
                {
                    MonsterKill++;
                    makeM9 = true;
                    StartCoroutine(resetMonster2(i));
                }
            }
        }
    }
    IEnumerator resetMonster2(int i)
    {
        yield return new WaitForSeconds(3f);

        if (curTown == 0)
        {
            mab1intanMonster[i] = Instantiate(mab1Monster[i % 2], mab1Pos[i].position, mab1Pos[i].rotation);
            IntanMonsterParticle[i] = Instantiate(MonsterParticle[0], mab1Pos[i].position, mab1Pos[i].rotation);
        }
        else if (curTown == 1)
        {
            mab2intanMonster[i] = Instantiate(mab2Monster[i % 2], mab2Pos[i].position, mab2Pos[i].rotation);
            IntanMonsterParticle[i] = Instantiate(MonsterParticle[1], mab2Pos[i].position, mab2Pos[i].rotation);
        }
        else if (curTown == 2)
        {
            mab3intanMonster[i] = Instantiate(mab3Monster[i % 2], mab3Pos[i].position, mab3Pos[i].rotation);
            IntanMonsterParticle[i] = Instantiate(MonsterParticle[2], mab3Pos[i].position, mab3Pos[i].rotation);
        }
        SoundManager.instace.SFXPlay("Melee", clip[45]);

        yield return new WaitForSeconds(2f);
        Destroy(IntanMonsterParticle[i].gameObject);
        if (i == 0) makeM0 = false;
        if (i == 1) makeM1 = false;
        if (i == 2) makeM2 = false;
        if (i == 3) makeM3 = false;
        if (i == 4) makeM4 = false;
        if (i == 5) makeM5 = false;
        if (i == 6) makeM6 = false;
        if (i == 7) makeM7 = false;
        if (i == 8) makeM8 = false;
        if (i == 9) makeM9 = false;
    }
    void DieAllMonster()
    {
        if (curTown == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                Destroy(mab1intanMonster[i].gameObject);
            }
        }
        if (curTown == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Destroy(mab2intanMonster[i].gameObject);
            }
        }
        if (curTown == 2)
        {
            for (int i = 0; i < 10; i++)
            {
                Destroy(mab3intanMonster[i].gameObject);
            }
        }
    }
    void goAcc1()
    {
        curHealth += 10;
        if (curHealth > maxHealth) curHealth = maxHealth;
        Acc1_1 = false;
    }
    void goAcc2()
    {
        curMp += 10;
        if (curMp > maxMp) curMp = maxMp;
        Acc2_1 = false;
    }
    void goStart()
    {
        if(startGame)
        {
            Invoke("StartGame", 2.3f);
        }
    }
    void StartGame()
    {
        hide.gameObject.SetActive(true);
        ui.spaceUi(curTown);
        SoundManager.instace.BgSoundPlay(bglist[curTown]);
        startGame = false;
        flag = false;
    }
    void SetStat()
    {
        statInven.HealText.text = "" + maxHealth;
        statInven.ManaText.text = "" + maxMp;
        statInven.ADText.text = "" + AD;
        statInven.APText.text = "" + AP;
        statInven.DefenseText.text = "" + Defense;
        statInven.SpeedText.text = "" + speed;
        statInven.PortionRateText.text = PortionRate + "%";
    }
    void enemyaround()
    {
        col = Physics.OverlapSphere(transform.position, EnemyRadius,layer);

        Transform short_ememy = null;
        
        if(col.Length > 0)
        {
            float short_distance = Mathf.Infinity;

            foreach(Collider s_col in col)
            {
                float playertoememy = Vector3.SqrMagnitude(transform.position - s_col.transform.position);
                if(short_distance > playertoememy)
                {
                    short_distance = playertoememy;
                    short_ememy = s_col.transform;
                }
            }
        }
        target = short_ememy;
    }
    void noWall()
    {
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 0.3f, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, look, out hit, 0.3f))
        {
            if (hit.collider.gameObject.tag == "Floor" || hit.collider.gameObject.tag == "BossWall") ContactWall = true;
        }
        else ContactWall = false;
    }
    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 MoveVec = new Vector3(x, y);
        Vector3 forward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
        Vector3 right = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
        moveDirection = forward * y + right * x;
        isMove = MoveVec.magnitude != 0;
        if (!isMove || isJump || isDodge || flag || Inventory.inventoryActivated || WeaponInven.WeaponyActivated || PortionInven.PortionInvenActivated
            || ArmorInven.ArmorActivated || SettingInven.SettingActivated || SetSkillInven.SkillSetActivated || StatInven.StatInvenActivated && !isQuest)
        {
            isWalk = false;
            isRun = false;
            SoundManager2.instace.BgSoundStop(clip[0]);
            SoundManager2.instace.BgSoundStop(clip[1]);
        }

        Jdown = Input.GetButtonDown("Jump");
        rDown = Input.GetButton("Run");
        Ddown = Input.GetKeyDown(KeyCode.LeftControl);
        eDown = Input.GetKeyDown(KeyCode.E);
        sDown = Input.GetKeyDown(KeyCode.Q);
        Rdown = Input.GetKeyDown(KeyCode.R);
        KeyZdown = Input.GetKeyDown(KeyCode.Z);
        KeyXdown = Input.GetKeyDown(KeyCode.X);
        Key1down = Input.GetKeyDown(KeyCode.Alpha1);
        Key2down = Input.GetKeyDown(KeyCode.Alpha2);
        Key3down = Input.GetKeyDown(KeyCode.Alpha3);
        Key4down = Input.GetKeyDown(KeyCode.Alpha4);
        Key5down = Input.GetKeyDown(KeyCode.Alpha5);
        Key6down = Input.GetKeyDown(KeyCode.Alpha6);
        Key7down = Input.GetKeyDown(KeyCode.Alpha7);

        anim.SetBool("isWalk", isMove);
        anim.SetBool("isRun", rDown);

        if (isDodge && !isPortal && !Inventory.inventoryActivated && !WeaponInven.WeaponyActivated && !PortionInven.PortionInvenActivated 
            && !ArmorInven.ArmorActivated && !SettingInven.SettingActivated && !SetSkillInven.SkillSetActivated && !StatInven.StatInvenActivated && !isQuest)
        {
            moveDirection = dodgeVec;
            transform.position += moveDirection * speed * Time.deltaTime;
        }

        if (isMove && !flag && !isDodge && !isDamage && !isPortal && !goAck && !Inventory.inventoryActivated && !WeaponInven.WeaponyActivated && !PortionInven.PortionInvenActivated
            && !ArmorInven.ArmorActivated && !SettingInven.SettingActivated && !SetSkillInven.SkillSetActivated && !StatInven.StatInvenActivated && !isQuest)
        {
            if (!isWalk && !rDown && !isJump && !isDodge && !isDamage && !isAck)
            {
                SoundManager2.instace.BgSoundStop(clip[1]);
                SoundManager2.instace.BgSoundPlay(clip[0]);
                isWalk = true;
                isRun = false;
            }
            if(rDown && !isRun && !isJump && !isDodge)
            {
                SoundManager2.instace.BgSoundStop(clip[0]);
                SoundManager2.instace.BgSoundPlay(clip[1]);
                isRun = true;
                isWalk = false;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * smoothness);
            if(!ContactWall) transform.position += moveDirection * speed * (rDown ? 1.5f : 1f) * Time.deltaTime;
        }
    }
    public void Upgread1()
    {
        Level++;
        SoundManager.instace.SFXPlay("Melee", clip[19]);
        Stat += 50;
        statInven.statText.text = "스탯 포인트 : " + Stat;
        statInven.RankText.text = "<color=#4AFF00>" + "견습 용병단원" + "</color>";
        AD += 10;
        AP += 10;
        statInven.ChangeWeaponUpdateStat();
        RankupParticle.SetActive(true);
        Invoke("RankupParticleOut", 5f);
        SkillPoint += 2;
        setSkillInven.unlockSkill1();
    }
    public void Upgread2()
    {
        Level++;
        SoundManager.instace.SFXPlay("Melee", clip[19]);
        Stat += 50;
        statInven.statText.text = "스탯 포인트 : " + Stat;
        statInven.RankText.text = "<color=#FFAB00>" + "정식 용병단원" + "</color>";
        AD += 10;
        AP += 10;
        statInven.ChangeWeaponUpdateStat();
        RankupParticle.SetActive(true);
        Invoke("RankupParticleOut", 5f);
        SkillPoint += 2;
        setSkillInven.unlockSkill2();
    }
    public void Upgread3()
    {
        Level++;
        SoundManager.instace.SFXPlay("Melee", clip[19]);
        Stat += 50;
        statInven.statText.text = "스탯 포인트 : " + Stat;
        statInven.RankText.text = "<color=#FFAB00>" + "정식 용병단원" + "</color>";
        AD += 10;
        AP += 10;
        statInven.ChangeWeaponUpdateStat();
        RankupParticle.SetActive(true);
        Invoke("RankupParticleOut", 5f);
        SkillPoint += 2;
        setSkillInven.unlockSkill2();
    }
    public void Upgread4()
    {
        SoundManager.instace.SFXPlay("Melee", clip[19]);
        Stat += 50;
        statInven.statText.text = "스탯 포인트 : " + Stat;
        statInven.RankText.text = "<color=#FF0000>" + "용병단장" + "</color>";
        AD += 10;
        AP += 10;
        statInven.ChangeWeaponUpdateStat();
        RankupParticle.SetActive(true);
        Invoke("RankupParticleOut", 5f);
        SkillPoint += 2;
        setSkillInven.unlockSkill4();
    }
    void SkillDown()
    {   
        if(Key4down)
        {
            Level++;
            SoundManager.instace.SFXPlay("Melee", clip[19]);
            Stat += 50;
            statInven.statText.text = "스탯 포인트 : " + Stat;
            statInven.RankText.text = "<color=#4AFF00>" + "견습 용병단원" + "</color>";
            AD += 10;
            AP += 10;
            statInven.ChangeWeaponUpdateStat();
            RankupParticle.SetActive(true);
            Invoke("RankupParticleOut", 5f);
            SkillPoint += 2;
            setSkillInven.unlockSkill1();
        }
        if (Key5down)
        {
            Level++;
            SoundManager.instace.SFXPlay("Melee", clip[19]);
            Stat += 50;
            statInven.statText.text = "스탯 포인트 : " + Stat;
            statInven.RankText.text = "<color=#FFAB00>" + "정식 용병단원" + "</color>";
            AD += 10;
            AP += 10;
            statInven.ChangeWeaponUpdateStat();
            RankupParticle.SetActive(true);
            Invoke("RankupParticleOut", 5f);
            SkillPoint += 2;
            setSkillInven.unlockSkill2();
        }
        if (Key6down)
        {
            Level++;
            SoundManager.instace.SFXPlay("Melee", clip[19]);
            Stat += 50;
            statInven.statText.text = "스탯 포인트 : " + Stat;
            statInven.RankText.text = "<color=#FF00ED>" + "베테랑 용병단원" + "</color>";
            AD += 10;
            AP += 10;
            statInven.ChangeWeaponUpdateStat();
            RankupParticle.SetActive(true);
            Invoke("RankupParticleOut", 5f);
            SkillPoint += 2;
            setSkillInven.unlockSkill3();
        }
        if (Key7down)
        {
            SoundManager.instace.SFXPlay("Melee", clip[19]);
            Stat += 50;
            statInven.statText.text = "스탯 포인트 : " + Stat;
            statInven.RankText.text = "<color=#FF0000>" + "용병단장" + "</color>";
            AD += 10;
            AP += 10;
            statInven.ChangeWeaponUpdateStat();
            RankupParticle.SetActive(true);
            Invoke("RankupParticleOut", 5f);
            SkillPoint += 2;
            setSkillInven.unlockSkill4();
        }
    }
    void RankupParticleOut()
    {
        RankupParticle.SetActive(false);
    }
    void Drink()
    {
        if (KeyZdown && !KeyXdown && !isJump && !isDodge && !isMana && !flag && !isHeal && !isDamage && !isQuest)
        {   
            if(HealPortion == 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoHealPortion();
            }
            else
            {   
                SoundManager.instace.SFXPlay("Melee", clip[4]);
                HealPortion--;
                ui.curHealNum(HealPortion);
                HealParticle.SetActive(true);
                curHealth += (50 + PortionRate * 10);
                if (curHealth > maxHealth) curHealth = maxHealth;
                isDrink = true;
                isHeal = true;
                potionIndex = 0;
                anim.SetTrigger("doDrink");
                Item[potionIndex].SetActive(true);
                Invoke("doDrinking", 2.5f);

                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].item != null)
                    {
                        if (inventory.slots[i].item.itemName == "체력물약")
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }

            }
        }
        if (KeyXdown && !KeyZdown && !isJump && !isDodge && !isHeal && !flag && !isMana && !isDamage && !isQuest)
        {   
            if(ManaPortion == 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoManaPortion();
            }
            else
            {
                SoundManager.instace.SFXPlay("Melee", clip[4]);
                ManaPortion--;
                ui.curManaNum(ManaPortion);
                ManaParticle.SetActive(true);
                curMp += (50 + PortionRate * 10);
                if (curMp > maxMp) curMp = maxMp;
                isDrink = true;
                isMana = true;
                potionIndex = 1;
                anim.SetTrigger("doDrink");
                Item[potionIndex].SetActive(true);
                Invoke("doDrinking", 2.5f);

                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.slots[i].item != null)
                    {
                        if (inventory.slots[i].item.itemName == "마나물약")
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }
            }
        }
    }
    void doDrinking()
    {
        if (potionIndex == 0)
        {
            isHeal = false;
            Item[potionIndex].SetActive(false);
            isDrink = false;
            HealParticle.SetActive(false);
        }
        if (potionIndex == 1)
        {
            isMana = false;
            Item[potionIndex].SetActive(false);
            isDrink = false;
            ManaParticle.SetActive(false);
        }
    }
    void Interation()
    {
        if (eDown && nearObject != null && !isJump && !isDodge && !isDamage) 
        {
            if (nearObject.tag == "Item")
            {
                ui.GetItem(nearObject);
                Destroy(nearObject);
            }
        }
    }
    void Swap()
    {
        if (sDown && !isJump! && !isDodge && !isSwap && !flag && !isDamage && !isQuest)
        {
            SoundManager.instace.SFXPlay("Melee", clip[8]);
            isSwap = true;
            Invoke("doSwaping", 0.8f);
            anim.SetTrigger("doSwap");
        }
    }
    void doSwaping()
    {   
        if(!curWeapon)
        {
            weapons[curSwordIndex].SetActive(false);
            weapons[curMagicIndex].SetActive(true);
            Backweapons[curSwordIndex].SetActive(true);
            Backweapons[curMagicIndex].SetActive(false);
            ui.swordImg.gameObject.SetActive(false);
            ui.magicImg.gameObject.SetActive(true);
            ui.MagicUI.gameObject.SetActive(true);
            ui.SwordUI.gameObject.SetActive(false);
            curWeapon = true;
            isSwap = false;
        }
        else if (curWeapon)
        {
            weapons[curMagicIndex].SetActive(false);
            weapons[curSwordIndex].SetActive(true);
            Backweapons[curMagicIndex].SetActive(true);
            Backweapons[curSwordIndex].SetActive(false);
            ui.swordImg.gameObject.SetActive(true);
            ui.magicImg.gameObject.SetActive(false);
            ui.MagicUI.gameObject.SetActive(false);
            ui.SwordUI.gameObject.SetActive(true);
            curWeapon = false;
            isSwap = false;
        }
        //SwapParticle.SetActive(false);
    }
    public void ChangeWeaponindex(int weaponindex)
    {
        if (!curWeapon)
        {
            if (weaponindex < 8)
            {
                weapons[curSwordIndex].SetActive(false);
                curSwordIndex = weaponindex;
                weapons[curSwordIndex].SetActive(true);
            }
            else
            {
                Backweapons[curMagicIndex].SetActive(false);
                curMagicIndex = weaponindex;
                Backweapons[curMagicIndex].SetActive(true);
            }
        }
        else if (curWeapon)
        {
            if (weaponindex >= 8)
            {
                weapons[curMagicIndex].SetActive(false);
                curMagicIndex = weaponindex;
                weapons[curMagicIndex].SetActive(true);
            }
            else
            {
                Backweapons[curSwordIndex].SetActive(false);
                curSwordIndex = weaponindex;
                Backweapons[curSwordIndex].SetActive(true);
            }
        }
    }
    void Jump()
    {
        if (Jdown && !isJump && !isDodge && !isDrink && !isDamage && !isQuest)
        {
            SoundManager.instace.SFXPlay("Melee", clip[2]);
            isJump = true;
            if(isAck)
            {
                if (!ContactWall) rigid.AddForce(Vector3.up * 6, ForceMode.Impulse);
                anim.SetTrigger("doAckJump");
            }
            else
            {
                if (!ContactWall) rigid.AddForce(Vector3.up * 4, ForceMode.Impulse);
                anim.SetTrigger("doJump");
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
        if (collision.gameObject.tag == "EmemyBag")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 100;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag2")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 200;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag3")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 300;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag4")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 500;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag5")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 1000;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag6")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 2000;
            ui.goldText.text = Gold + "";
        }
        if (collision.gameObject.tag == "EnemyBag7")
        {
            SoundManager.instace.SFXPlay("Melee", clip[30]);
            Destroy(collision.gameObject);
            Gold += 3000;
            ui.goldText.text = Gold + "";
        }
    }
    void Dodge()
    {
        if (!isDodge && Ddown && !isJump && !isDrink && !flag && !isDamage && !isSwap && !isQuest)
        {
            SoundManager.instace.SFXPlay("Melee", clip[3]);
            isDodge = true;
            dodgeVec = moveDirection;
            if (isAck)
            {
                anim.SetTrigger("doAckDodge");
            }
            else
            {
                anim.SetTrigger("doDodge");
                if (!ContactWall)
                {
                    speed *= 1.4f;
                    Invoke("DodgeOut2", 0.6f);
                }
                else
                {
                    Invoke("DodgeOut", 0.6f);
                }
            }
        }
    }
    void DodgeOut()
    {
        //if (!isAck && !nododge) speed *= 0.5f;
        isDodge = false;
    }
    void DodgeOut2()
    {
        speed /= 1.4f;
        //speeddodge = false;
        isDodge = false;
    }
    void Awakening()
    {
        if(Rdown && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !isAck && !AckRock && !isQuest)
        {
            if (ui.Ackcurcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.Ackcoolon();
                isAck = true;
                goAck = true;
                speed += 2;
                anim.SetTrigger("doAwakening");
                StartCoroutine("doAck");
            }
        }
    }
    IEnumerator doAck()
    {
        SoundManager.instace.SFXPlay("Melee", clip[14]);
        gameObject.layer = 11;
        yield return new WaitForSeconds(0.5f);
        AckParticle.SetActive(true);
        yield return new WaitForSeconds(1f);
        goAck = false;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Playermat[1];
        AckParticle.SetActive(false);
        MotionTrail.SetActive(true);
        gameObject.layer = 9;
    }
    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage &&!isPortal && !Inventory.inventoryActivated 
            && !ArmorInven.ArmorActivated && !PortionInven.PortionInvenActivated && !SetSkillInven.SkillSetActivated && !StatInven.StatInvenActivated
            && !WeaponInven.WeaponyActivated && !SettingInven.SettingActivated && !isQuest)
        {   
            if(isAck)
            {   
                if(!intanBow || !intanBow1_1)
                {
                    flag = true;
                    StopCoroutine("Bow");
                    StartCoroutine("Bow");
                    anim.SetTrigger("doBow");
                }
            }
            else
            {
                if (!curWeapon)
                {
                    flag = true;
                    anim.SetTrigger("onweaponAttack");
                }
                else
                {                 
                    if (!intanBullet1 || !intanBullet1_2)
                    {
                         flag = true;
                         StopCoroutine("Shot");
                         StartCoroutine("Shot");
                         anim.SetTrigger("doMagic1");
                    }
                }
            }
        }
    }
    IEnumerator Bow()
    {
        yield return new WaitForSeconds(0.1f);
        if(!intanBow)
        {
            bow1 = true;
            intanBow = Instantiate(BowObj, BowPos.position, BowPos.rotation);
            intanBow2 = Instantiate(BowObj, BowPos2.position, BowPos2.rotation);
            intanBow3 = Instantiate(BowObj, BowPos3.position, BowPos3.rotation);
            Invoke("BowOut", 4f);
        }
        else if(intanBow && !intanBow1_1)
        {
            intanBow1_1 = Instantiate(BowObj, BowPos.position, BowPos.rotation);
            intanBow2_1 = Instantiate(BowObj, BowPos2.position, BowPos2.rotation);
            intanBow3_1 = Instantiate(BowObj, BowPos3.position, BowPos3.rotation);
            Invoke("BowOut2", 4f);
        }
        SoundManager.instace.SFXPlay("Melee", clip[12]);
    }
    public void doBow()
    {    
        SoundManager.instace.SFXPlay("Melee", clip[13]);

        if(bow1)
        {
            Rigidbody bulletRigid = intanBow.GetComponent<Rigidbody>();
            bulletRigid.velocity = transform.forward * 60f;
            BowArea1 = intanBow.GetComponent<BoxCollider>();
            BowArea1.enabled = true;
            Rigidbody bulletRigid2 = intanBow2.GetComponent<Rigidbody>();
            bulletRigid2.velocity = transform.forward * 60f;
            BowArea2 = intanBow2.GetComponent<BoxCollider>();
            BowArea2.enabled = true;
            Rigidbody bulletRigid3 = intanBow3.GetComponent<Rigidbody>();
            bulletRigid3.velocity = transform.forward * 60f;
            BowArea3 = intanBow3.GetComponent<BoxCollider>();
            BowArea3.enabled = true;
            bow1 = false;
        }
        else
        {
            Rigidbody bulletRigid = intanBow1_1.GetComponent<Rigidbody>();
            bulletRigid.velocity = transform.forward * 60f;
            BowArea1_1 = intanBow1_1.GetComponent<BoxCollider>();
            BowArea1_1.enabled = true;
            Rigidbody bulletRigid2 = intanBow2_1.GetComponent<Rigidbody>();
            bulletRigid2.velocity = transform.forward * 60f;
            BowArea2_1 = intanBow2_1.GetComponent<BoxCollider>();
            BowArea2_1.enabled = true;
            Rigidbody bulletRigid3 = intanBow3_1.GetComponent<Rigidbody>();
            bulletRigid3.velocity = transform.forward * 60f;
            BowArea3_1 = intanBow3_1.GetComponent<BoxCollider>();
            BowArea3_1.enabled = true;
        }
    }
    public void outBow()
    {
        flag = false;
    }
    void BowOut()
    {
        Destroy(intanBow.gameObject);
        Destroy(intanBow2.gameObject);
        Destroy(intanBow3.gameObject);
    }
    void BowOut2()
    {
        Destroy(intanBow1_1.gameObject);
        Destroy(intanBow2_1.gameObject);
        Destroy(intanBow3_1.gameObject);
    }
    IEnumerator Shot()
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.instace.SFXPlay("Melee", clip[18]);
        if (!intanBullet1)
        {
            Invoke("bullet1Out",3f);
            intanBullet1 = Instantiate(bullet1, bulletPos.position, bulletPos.rotation);
            StartCoroutine("Magic1");
        }
        else if (intanBullet1 && !intanBullet1_2)
        {
            Invoke("bullet1_2Out", 3f);
            intanBullet1_2 = Instantiate(bullet1, bulletPos.position, bulletPos.rotation);
            StartCoroutine("Magic1_2");
        }
        yield return new WaitForSeconds(1f);
        flag = false;
    }
    IEnumerator Magic1()
    {
        yield return new WaitForSeconds(2f);
        if(target != null)
        {
            target.position += new Vector3(0, 1, 0);
            Vector3 t_dir = (target.position - intanBullet1.transform.position).normalized;

            Rigidbody bulletRigid = intanBullet1.GetComponent<Rigidbody>();
            bulletRigid.velocity = t_dir * 30f;
            Magic0_1Area = intanBullet1.GetComponent<BoxCollider>();
            Magic0_1Area.enabled = true;
        }
    }
    IEnumerator Magic1_2()
    {
        yield return new WaitForSeconds(2f);
        if (target != null)
        {
            target.position += new Vector3(0, 1, 0);
            Vector3 t_dir = (target.position - intanBullet1_2.transform.position).normalized;

            Rigidbody bulletRigid = intanBullet1_2.GetComponent<Rigidbody>();
            bulletRigid.velocity = t_dir * 30f;
            Magic0_2Area = intanBullet1_2.GetComponent<BoxCollider>();
            Magic0_2Area.enabled = true;
        }
    }
    void bullet1Out()
    {
        Destroy(intanBullet1.gameObject);
    }
    void bullet1_2Out()
    {
        Destroy(intanBullet1_2.gameObject);
    }

    //magic1skill
    void Magic2()
    {
        if (curWeapon && Key1down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !Magic1Rock && !isQuest)
        {
            if (curMp - Magic1SkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            else if (ui.Magic2curcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.Magic3CoolonM2();
                flag = true;
                StopCoroutine("Shot2");
                StartCoroutine("Shot2");
                anim.SetTrigger("doMagic2");
            }
        }
    }
    IEnumerator Shot2()
    {
        SoundManager.instace.SFXPlay("Melee", clip[22]);
        curMp -= Magic1SkillMana;
        yield return new WaitForSeconds(2f);
        intanBullet2 = Instantiate(bullet2, bulletPos2.position, bulletPos2.rotation);
        Invoke("magic2Out", 3f);
        yield return new WaitForSeconds(1f);
        flag = false;
    }
    void magic2Out()
    {
        Destroy(intanBullet2.gameObject);
    }
    void Magic3()
    {
        if (curWeapon && Key3down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !Magic3Rock && !isQuest)
        {
            if (curMp - Magic3SkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            else if (ui.Magic3curcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.Magic3CoolonM3();
                flag = true;
                StopCoroutine("Shot3");
                StartCoroutine("Shot3");
                anim.SetTrigger("doMagic3");
            }
        }
    }
    IEnumerator Shot3()
    {
        Magic3Floor.SetActive(true);
        curMp -= Magic3SkillMana;
        yield return new WaitForSeconds(0.5f);
        SoundManager.instace.SFXPlay("Melee", clip[16]);
        intanBullet3 = Instantiate(bullet3, bulletPos3.position, bulletPos3.rotation);
        Invoke("magic3Out", 4f);
        StartCoroutine("doMagic3");
        yield return new WaitForSeconds(3f);
        Magic3Floor.SetActive(false);
        flag = false;
    }
    IEnumerator doMagic3()
    {
        yield return new WaitForSeconds(1.3f);
        SoundManager.instace.SFXPlay("Melee", clip[17]);
        Magic3Area = intanBullet3.GetComponent<BoxCollider>();
        Magic3Area.enabled = true;
        Rigidbody bulletRigid = intanBullet3.GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * 20f;
    }
    void magic3Out()
    {
        Magic3Area.enabled = false;
        Destroy(intanBullet3.gameObject);
    }
    void SwordHit1()
    {
        Sword1Slash.SetActive(true);
        meleeArea[curSwordIndex].enabled = true;
        flag = true;
        SoundManager.instace.SFXPlay("Melee", clip[7]);
    }
    void SwordHit1out()
    {
        meleeArea[curSwordIndex].enabled = false;
        Invoke("MoveOut", 0.1f);
    }
    void SwordHit1_2()
    {
        Sword1Slash2.SetActive(true);
        AD += 10;
        meleeArea[curSwordIndex].enabled = true;
        flag = true;
        SoundManager.instace.SFXPlay("Melee", clip[7]);
    }
    void SwordHit1_2out()
    {
        meleeArea[curSwordIndex].enabled = false;
        AD -= 10;
        Invoke("MoveOut", 0.1f);
    }
    void SwordHit1_3()
    {
        Sword1Slash3.SetActive(true);
        AD += 30;
        meleeArea[curSwordIndex].enabled = true;
        flag = true;
        SoundManager.instace.SFXPlay("Melee", clip[7]);
    }
    void SwordHit1_3out()
    {  
        meleeArea[curSwordIndex].enabled = false;
        AD -= 30;
        Invoke("MoveOut", 0.5f);
    }
    void MoveOut()
    {
        Sword1Slash.SetActive(false);
        Sword1Slash2.SetActive(false);
        Sword1Slash3.SetActive(false);
        flag = false;
    }

    void Sword1()
    {
        if (!curWeapon && Key1down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !Sword1Rock && !isQuest)
        {
            if (curMp - Sword1SkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            else if (ui.Sword1curcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.Magic3CoolonS1();
                flag = true;
                StopCoroutine("doSword1");
                StartCoroutine("doSword1");
                anim.SetTrigger("GoSword1");
            }
        }
    }
    IEnumerator doSword1()
    {
        curMp -= Sword1SkillMana;
        yield return new WaitForSeconds(0.5f);
        SoundManager.instace.SFXPlay("Melee", clip[11]);
        Sword1Particle.SetActive(true);
        Invoke("Swoord1Out", 1f);
        yield return new WaitForSeconds(1f);
        flag = false;
    }
    void Swoord1Out()
    {
        Sword1Particle.SetActive(false);
    }
    void Sword2()
    {
        if (!curWeapon && Key2down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !Sword2Rock && !isQuest)
        {
            if (curMp - Sword2SkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            else if (ui.Sword2curcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.Magic3CoolonS2();
                flag = true;
                StopCoroutine("doSword2");
                StartCoroutine("doSword2");
                anim.SetTrigger("doSword2");
            }
        }
    }
    IEnumerator doSword2()
    {
        curMp -= Sword2SkillMana;
        yield return new WaitForSeconds(1.2f);
        SoundManager.instace.SFXPlay("Melee", clip[10]);
        intanSword2 = Instantiate(Sword2Particle, Sword2Pos.position, Sword2Pos.rotation);
        Invoke("Swoord2Out", 3f);
        yield return new WaitForSeconds(1.6f);
        flag = false;
    }
    void Swoord2Out()
    {
        Destroy(intanSword2.gameObject);
    }
    void Sword3()
    {
        if (!curWeapon && Key3down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && !Sword3Rock && !isQuest)
        {
            if (curMp - Sword3SkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            else if(ui.Sword3curcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                EnemyRadius = 100f;
                gameObject.layer = 11;
                ui.Magic3CoolonS3();
                flag = true;
                StopCoroutine("Sword03");
                StartCoroutine("Sword03");
                anim.SetTrigger("doSword3");
            }
        }
    }
    IEnumerator Sword03()
    {
        yield return new WaitForSeconds(0.5f);
        SoundManager.instace.SFXPlay("Melee", clip[14]);
        Sword3Floor.SetActive(true);
        curMp -= Sword3SkillMana;
        yield return new WaitForSeconds(2.5f);
        foreach (Collider s_col in col)
        {
            enemy = s_col.GetComponent<Enemy>();
            enemy.GoSword3();
        }
        Sword3Floor.SetActive(false);
        flag = false;
        EnemyRadius = 20f;
        gameObject.layer = 9;
    }
    void DoIceEnemy()
    {
        if (Key2down && !isMana && !isHeal && !flag && !isSwap && !isDodge && !isDamage && curWeapon && !Magic2Rock && !isQuest)
        {
            if (curMp - IceEnemySkillMana < 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.NoMana();
            }
            if (ui.IceEnemycurcool > 0)
            {
                SoundManager.instace.SFXPlay("Melee", clip[5]);
                ui.WaitSkillCool();
            }
            else
            {
                ui.IceEnemyCoolon();
                flag = true;
                anim.SetTrigger("doIceEnemy");
                StartCoroutine("goIceEnemy");
            }
        }
    }
    IEnumerator goIceEnemy()
    {
        curMp -= IceEnemySkillMana;
        yield return new WaitForSeconds(1.2f);
        SoundManager.instace.SFXPlay("Melee", clip[6]);
        IceEnemyBullet = Instantiate(IceEnemy, IcePos.position, IcePos.rotation);
        yield return new WaitForSeconds(1.3f);
        flag = false;
        yield return new WaitForSeconds(1f);
        Destroy(IceEnemyBullet.gameObject);
    }
    void OutIceEnemy()
    {   
        IceEnemy.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Item") nearObject = other.gameObject;
        if (other.tag == "Town") inTown = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item") nearObject = null;
        if (other.tag == "Town") inTown = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (other.tag == "EnemyWeapon" && gameObject.layer != 11)
        {   
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage + Defense;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(onDamage(reactVec));
        }
        if (other.tag == "EnemyGoblinGirl" && gameObject.layer != 11)
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage + Defense;
            Vector3 reactVec = transform.position - other.transform.position;
            StartCoroutine(onDamage(reactVec));

            Destroy(other.gameObject);
        }
        if (other.tag == "Boss2" && gameObject.layer != 11)
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage + Defense;
            Vector3 reactVec = transform.position - other.transform.position;
            gameObject.layer = 11;
            StartCoroutine(onDamage(reactVec));
        }
        if(other.tag == "EnemyIce")
        {
            StartCoroutine("EnemyIce");
        }
        if(other.tag == "Portal1")
        {
            curTown = 1;
            StartCoroutine(goTown(1));
        }
        if (other.tag == "Portal2")
        {
            curTown = 2;
            StartCoroutine(goTown(2));
        }
        if (other.tag == "Portal3")
        {
            curTown = 0;
            StartCoroutine(goTown(0));
        }
        if (other.tag == "Portal4")
        {
            StartCoroutine(godun(3));
        }
        if (other.tag == "Portal5")
        {
            StartCoroutine(godun(4));
        }
        if (other.tag == "Portal6")
        {
            StartCoroutine(godun(5));
        }
        if (other.gameObject.name == "1_1" && curBoss == 0)
        {   
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "Boss1" && curBoss == 1)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "2_1" && curBoss == 2)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "Boss2" && curBoss == 3)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "3_1" && curBoss == 4)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "3_2" && curBoss == 5)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.name == "Boss3" && curBoss == 6)
        {
            StartCoroutine(EnterBoss());
        }
        if (other.gameObject.tag == "KillBoss")
        {
            StartCoroutine(goTown(curTown));
        }
        if (other.gameObject.tag == "Green")
        {
            onGreen = true;
        }
        if (other.gameObject.tag == "Gold")
        {
            onGold = true;
        }
        if (other.gameObject.tag == "Canon")
        {
            onCanon = true;
        }
        if (other.gameObject.tag == "Gang")
        {
            Gang = true;
        }
        if (other.gameObject.tag == "Zun")
        {
            Zun = true;
        }
        if (other.gameObject.tag == "Hal")
        {
            Hal = true;
        }
    }
    IEnumerator godun(int num)
    {
        yield return new WaitForSeconds(0.5f);
        isJump = true;
        isPortal = true;
        MyQuestUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        ui.Fade();
        yield return new WaitForSeconds(1f);
        SoundManager.instace.bgSound.Stop();
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = Town[num].position;
        yield return new WaitForSeconds(2.5f);
        SoundManager.instace.BgSoundPlay(bglist[num]);
        ui.spaceUi(num);
        MakeMoster();
        yield return new WaitForSeconds(1f);
        if (questClearList.curQuest != -1) MyQuestUI.gameObject.SetActive(true);
        isdun = true;
    }
    public IEnumerator goTown(int num)
    {
        MyQuestUI.gameObject.SetActive(false);
        gameObject.layer = 11;
        yield return new WaitForSeconds(0.5f);
        isJump = true;
        isPortal = true;
        yield return new WaitForSeconds(1f);
        ui.Fade();
        yield return new WaitForSeconds(1f);
        SoundManager.instace.bgSound.Stop();
        yield return new WaitForSeconds(1f);
        if(curTown == 1)
        {
            Map[0].gameObject.SetActive(true);
            Map[1].gameObject.SetActive(true);
            Map[2].gameObject.SetActive(true);
        }
        if (curTown == 2)
        {
            Map[0].gameObject.SetActive(true);
            Map[1].gameObject.SetActive(true);
            Map[2].gameObject.SetActive(true);
        }
        if (curTown == 0)
        {
            Map[0].gameObject.SetActive(true);
            Map[1].gameObject.SetActive(true);
            Map[2].gameObject.SetActive(true);
        }
        if (intanKillBoss != null) Destroy(intanKillBoss.gameObject);
        gameObject.transform.position = Town[num].position;
        yield return new WaitForSeconds(2.5f);
        SoundManager.instace.BgSoundPlay(bglist[num]);
        ui.spaceUi(num);
        isdun = false;
        gameObject.layer = 9;
        if (questClearList.curQuest != -1) MyQuestUI.gameObject.SetActive(true);
        DieAllMonster();
    }
    IEnumerator EnterBoss()
    {
        MyQuestUI.gameObject.SetActive(false);
        isdun = false;
        DieAllMonster();
        yield return new WaitForSeconds(0.5f);
        isPortal = true;
        isJump = true;
        yield return new WaitForSeconds(1f);
        ui.Fade();
        yield return new WaitForSeconds(1f);
        SoundManager.instace.bgSound.Stop();
        EnterBossTrigger[curBoss].gameObject.SetActive(false);
        //EnterBossCollider[curBoss].gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(1.8f);
        gameObject.transform.position= PlayerBossPos[curBoss].position;
        yield return new WaitForSeconds(0.1f);
        if (curBoss == 4 || curBoss == 5 || curBoss == 6) RenderSettings.skybox = Skymaterial[1];
        intancurBoss = Instantiate(Boss[curBoss], BossPos[curBoss].position, BossPos[curBoss].rotation);
        isBoss = true;
        SoundManager.instace.BgSoundPlay(bglist[6]);
        if (questClearList.curQuest != -1) MyQuestUI.gameObject.SetActive(true);
    }
    public void DieBoss(int curB)
    {
        intanKillBoss = Instantiate(KillBoss, BossPos[curB].position, BossPos[curB].rotation);
    }
    IEnumerator EnemyIce()
    {
        isJump = true;
        flag = true;
        anim.speed = 0;
        mat.color = Color.black;
        yield return new WaitForSeconds(3f);
        mat.color = Color.white;
        anim.speed = 1;
        flag = false;
        isJump = false;
    }

    IEnumerator onDamage(Vector3 reactVec)
    {
        isDamage = true;
        SoundManager.instace.SFXPlay("Melee", clip[24]);
        if (curHealth > 0)
        {   
            if(gameObject.layer == 11)
            {   
                StunnedParticle.SetActive(true);
                anim.SetTrigger("doStuned");
                SoundManager.instace.SFXPlay("Melee", clip[46]);
                yield return new WaitForSeconds(1.4f);
                anim.SetTrigger("doStandUp");
                yield return new WaitForSeconds(0.5f);
                reactVec = reactVec.normalized;
                reactVec += Vector3.back; 
                yield return new WaitForSeconds(2.5f);
                StunnedParticle.SetActive(false);
                gameObject.layer = 9;
                isDamage = false;
            }
            else
            {
                yield return new WaitForSeconds(0.01f);
                isDamage = false;
                mat.color = Color.red;
                yield return new WaitForSeconds(0.2f);
                mat.color = Color.white;
            }
        }
        else
        {
            SoundManager.instace.SFXPlay("Melee", clip[21]);
            gameObject.layer = 11;
            anim.SetTrigger("doDie");
            StartCoroutine(goHome(curTown));
        }
    }
    IEnumerator goHome(int num)
    {
        MyQuestUI.gameObject.SetActive(false);
        yield return new WaitForSeconds(3.5f);
        SoundManager.instace.SFXPlay("Melee", clip[20]);
        anim.speed = 0;
        ui.PlayerDieTxt.gameObject.SetActive(true);
        isPortal = true;
        yield return new WaitForSeconds(3f);
        ui.Fade();
        isBoss = false;
        ui.PlayerDieTxt.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        SoundManager.instace.bgSound.Stop();
        RenderSettings.skybox = Skymaterial[0];
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = Town[num].position;
        anim.speed = 1;
        yield return new WaitForSeconds(2.5f);
        SoundManager.instace.BgSoundPlay(bglist[num]);
        ui.spaceUi(num);
        gameObject.layer = 9;
        curHealth = maxHealth;
        curMp = maxMp;
        isDamage = false;
        //EnterBossTrigger[curBoss].gameObject.SetActive(true);
        //EnterBossCollider[curBoss].gameObject.SetActive(false);
        Destroy(intancurBoss.gameObject);
        DieAllMonster();
        isdun = false;
        if(questClearList.curQuest != -1) MyQuestUI.gameObject.SetActive(true);
    }
}