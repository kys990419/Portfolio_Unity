using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int dieEnemy1;
    public GameObject intanBox;
    public GameObject GoldBox;
    public GameObject BossHP;
    public Material[] Enemymat = new Material[2];
    public Material[] Meleemat = new Material[2];
    float Speed;
    CamShake camShake;
    bool wasMelee;
    public enum Type { MeleeGiblin, GoblinGirl, Enemy3, Enemy4,Enemy5,Enemy6, maze1,maze2,Boss, MiddleBoss, NPC, ETC};
    public int bossNum;
    public int MiddleBosNum;
    public Type type;
    public int maxHealth;
    public float curHealth;
    public Transform target;
    public BoxCollider meleeArea;
    public BoxCollider Boss2Area;
    public BoxCollider Boss3Area;
    public bool isChase;
    bool isAttack;
    bool isDamaged;
    bool doMagic2;
    public GameObject SwordSlash;
    public GameObject SwordSlashEffect;
    public GameObject intanBullet;
    public GameObject intanBullet2;
    public GameObject intanBullet3;
    public GameObject intanMonster1;
    public GameObject intanMonster2;
    public GameObject intanMonster3;
    public GameObject intanMonster4;
    public GameObject intanBoss3Magic1;
    public GameObject intanBoss3Magic1_2;
    public GameObject intanBoss3Magic1_3;
    public GameObject intanBoss3Magic2;
    public GameObject intanMiddle3_1Ice;
    public GameObject Middle3_1IcePrepab;
    public GameObject Boss3MonsterPrepab1;
    public GameObject Boss3MonsterPrepab2;
    public GameObject Boss3MonsterPrepab3;
    public GameObject Boss3MonsterPrepab4;
    public GameObject Boss3Magic1Prepab;
    public GameObject Boss3Magic2Prepab;
    public GameObject bullet;
    public GameObject GoldObj;
    public Transform bulletPos;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public Transform MonsterPos1;
    public Transform MonsterPos2;
    public Transform MonsterPos3;
    public Transform MonsterPos4;
    public Transform Boss3Magic1Pos;
    public Transform Boss3Magic2Pos;
    public Transform Middle3_1IcePos;
    public Transform DropItemPos;
    public GameObject Sword3Effet;
    public GameObject MagicDamageParticle;
    public GameObject SwordDamageParticle;
    public GameObject Boss2Particle;
    public BoxCollider Boss2Attack2Box;
    public BoxCollider Boss3Attack2Box;
    public GameObject Boss3Particle;
    public GameObject Boss3Attack1Floor;
    public GameObject Boss3doMonsterFloor;
    public GameObject Boss3doMonsterMonsterFloor1;
    public GameObject Boss3doMonsterMonsterFloor2;
    public GameObject Boss3doMonsterMonsterFloor3;
    public GameObject Boss3doMonsterMonsterFloor4;
    public GameObject Boss3Magic1Roon;
    public GameObject Boss3Magic1Effect;
    public GameObject Boss1Mouse;
    public GameObject Enemy4Rune;
    public GameObject GirlRune;
    public bool isWalkActive;
    bool flag;
    [Header("체력")]
    public Text text;
    public Transform hp;
    public Camera cam;
    public Slider HpBar;
    public Slider HpBarBack;
    public Text BossName;

    PlayerMove playerMove;
    Animator anim;
    Rigidbody rigid;
    Material mat;
    NavMeshAgent nav;
    GameObject player;
    void Start()
    {
        if (Type.Boss != type && Type.MiddleBoss != type) HpBar.value = (float)curHealth / (float)maxHealth;
        if (Type.Boss != type && Type.MiddleBoss != type) HpBarBack.value = (float)curHealth / (float)maxHealth;
        //if (Type.Boss != type && Type.MiddleBoss != type) ChaseStart();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
        camShake = GetComponent<CamShake>();
        ChaseStart();
    }
    void Awake()
    {   
        rigid = GetComponent<Rigidbody>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Type.Boss != type && Type.MiddleBoss != type)
        {
            Handler();
            Quaternion q_hp = Quaternion.LookRotation(hp.position - cam.transform.position);
            Vector3 hp_angle = Quaternion.RotateTowards(hp.rotation, q_hp, 200).eulerAngles;
            hp.rotation = Quaternion.Euler(0, hp_angle.y, 0);
        }
        else
        {
            if (playerMove.isBoss)
            {
                //BossName.text = "" + gameObject.transform.name;
                BossHP.gameObject.SetActive(true);
            }
            else
            {
                BossHP.gameObject.SetActive(false);
            }
        }
        Handler();
        if (nav.enabled)
        {
            nav.SetDestination(player.transform.position);
            nav.isStopped = !isChase;
        }
    }
    void ChaseStart()
    {
        isChase = true;
        anim.SetBool("isWalk", true);
    }
    void FixedUpdate()
    {
        if(isChase && gameObject.layer != 8) Targetting();
        FreezeVelocity();    
    }
    void Handler()
    {
        HpBar.value = Mathf.Lerp(HpBar.value, (float)curHealth / (float)maxHealth, Time.deltaTime * 5f);
        if (isDamaged) Invoke("reHandler", 0.5f);
    }
    void reHandler()
    {
        HpBarBack.value = Mathf.Lerp(HpBarBack.value, (float)curHealth / (float)maxHealth, Time.deltaTime * 5f);
        isDamaged = false;
    }
    void Targetting()
    {   
        float targetRadius = 1f;
        float targetRange = 1.5f;
            
        switch (type)
        {
            case Type.ETC:
                targetRadius = 1f;
                targetRange = 1.5f;
                RaycastHit[] rayHits = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(ETCAttack());
                }
                break;
            case Type.MeleeGiblin:
                targetRadius = 1f;
                targetRange = 1.5f;
                RaycastHit[] rayHits6 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits6.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(MeleeGoblinAttack());
                }
                break;
            case Type.GoblinGirl:
                targetRadius = 8f;
                targetRange = 9f;
                RaycastHit[] rayHits2 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits2.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(GoblinGirlAttack());
                }
                break;
            case Type.Enemy3:
                targetRadius = 1f;
                targetRange = 1.5f;
                RaycastHit[] rayHits1 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits1.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(Enemy3Attack());
                }
                break;
            case Type.Enemy4:
                targetRadius = 11f;
                targetRange = 11f;
                RaycastHit[] rayHits12 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits12.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(Enemy4Attack());
                }
                break;
            case Type.Enemy5:
                targetRadius = 1f;
                targetRange = 1.5f;
                RaycastHit[] rayHits3 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits3.Length > 0 && !isAttack && gameObject.layer == 7)
                { 
                    StartCoroutine(Enemy5Attack());
                }
                break;
            case Type.Enemy6:
                targetRadius = 10f;
                targetRange = 10f;
                RaycastHit[] rayHits4 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits4.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(Enemy6Attack());
                }
                break;
            case Type.maze1:
                targetRadius = 3f;
                targetRange = 3f;
                RaycastHit[] rayHits8 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits8.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(MazeAttack());
                }
                break;
            case Type.maze2:
                targetRadius = 3f;
                targetRange = 3f;
                RaycastHit[] rayHits9 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits9.Length > 0 && !isAttack && gameObject.layer == 7)
                {
                    StartCoroutine(Maze2Attack());
                }
                break;
            case Type.MiddleBoss:
                if (MiddleBosNum == 1)
                {
                    targetRadius = 1f;
                    targetRange = 1.5f;
                    RaycastHit[] rayHits5 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                    if (rayHits5.Length > 0 && !isAttack)
                    {
                        StartCoroutine(Middle1_1Attack());
                    }
                }
                if (MiddleBosNum == 2)
                {
                    targetRadius = 1f;
                    targetRange = 1.5f;
                    RaycastHit[] rayHits5 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                    if (rayHits5.Length > 0 && !isAttack)
                    {
                        StartCoroutine(Middle2_1Attack());
                    }
                }
                if (MiddleBosNum == 3)
                {
                    int result = Random.Range(0, 4);

                    targetRadius = 15f;
                    targetRange = 15f;
                    RaycastHit[] rayHits0 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                    if (rayHits0.Length > 0 && !isAttack)
                    {
                        if (result == 0) StartCoroutine(Middle3_1Attack1());
                        else if (result == 1) StartCoroutine(Middle3_1Attack2());
                        else if (result == 2) StartCoroutine(Middle3_1Attack3());
                    }

                }
                if (MiddleBosNum == 4)
                {
                    if (!wasMelee)
                    {
                        if (!isAttack)
                        {
                            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Enemymat[1];
                            meleeArea.GetComponent<MeshRenderer>().material = Meleemat[1];
                        }

                        int result = Random.Range(0, 3);

                        targetRadius = 1f;
                        targetRange = 1.5f;
                        RaycastHit[] rayHits0 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                        if (rayHits0.Length > 0 && !isAttack)
                        {
                            if (result == 0) StartCoroutine(Middle3_2Attack1());
                            else if (result == 1) StartCoroutine(Middle3_2Attack2());
                            else if (result == 2) StartCoroutine(Middle3_2Attack3());
                        }
                    }
                    else
                    {
                        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Enemymat[0];
                        targetRadius = 10f;
                        targetRange = 10f;
                        RaycastHit[] rayHits0 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                        if (rayHits0.Length > 0 && !isAttack)
                        {
                            StartCoroutine(Middle3_2Attack4());
                        }
                    }
                }
                break;
            case Type.Boss:    
            if(bossNum == 1)
            {
                targetRadius = 1f;
                targetRange = 1.5f;
                RaycastHit[] rayHits5 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits5.Length > 0 && !isAttack)
                {
                    int result = Random.Range(0, 2);
                    if (result == 0) StartCoroutine(Boss1Attack1());
                    else if (result == 1) StartCoroutine(Boss1Attack2());
                }
            }
            if (bossNum == 2)
            {
                targetRadius = 4f;
                targetRange = 4f;
                RaycastHit[] rayHits5 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits5.Length > 0 && !isAttack)
                {
                    int result = Random.Range(0, 2);
                    if (result == 0)
                    {
                        StartCoroutine(Boss2Attack1());
                    }
                    else StartCoroutine(Boss2Attack2());
                }
            }
            if (bossNum == 3)
            {   
                    targetRadius = 20f;
                    targetRange = 20f;
                

                    RaycastHit[] rayHits5 = Physics.SphereCastAll(transform.position, targetRadius, transform.forward, targetRange, LayerMask.GetMask("Player"));
                if (rayHits5.Length > 0 && !isAttack)
                {
                    int result = Random.Range(0, 5);
                    
                        if (result == 0) StartCoroutine(Boss3Attack1());
                        else if (result == 1) StartCoroutine(Boss3Attack2());
                        else if (result == 2) StartCoroutine(Boss3Attack3());
                        else if (result == 4) StartCoroutine(Boss3Attack4());
                        else if (result == 5) StartCoroutine(Boss3Attack5());

                    }
            }
            break;
        }      
    }
    IEnumerator ETCAttack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (!nav.enabled) yield return null;
        anim.SetTrigger("doAttack");

        yield return new WaitForSeconds(2.5f);
        isChase = true;
        isAttack = false;
        //SwordSlash.SetActive(false);
    }
    void ETCAttack1()
    {
        meleeArea.enabled = true;
        //SwordSlash.SetActive(true);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
    }
    void ETCAttack2()
    {
        meleeArea.enabled = false;
    }
    IEnumerator MeleeGoblinAttack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;


        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlash.SetActive(true);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
        yield return new WaitForSeconds(0.4f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(2.5f);
        isChase = true;
        isAttack = false;
        SwordSlash.SetActive(false);
    }
    IEnumerator GoblinGirlAttack()
    {
        isAttack = true;
        Speed = nav.speed;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(1f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;
        yield return new WaitForSeconds(1.6f);
        if (nav.enabled)
        {
            intanBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            GirlRune.SetActive(true);
            Rigidbody bulletRigid = intanBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPos.forward * 20f;
            BoxCollider box = intanBullet.GetComponent<BoxCollider>();
            box.enabled = true;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[32]);
            yield return new WaitForSeconds(2f);
            Destroy(intanBullet.gameObject);
            GirlRune.SetActive(false);
            nav.speed = Speed;
            isChase = true;
            isAttack = false;
        }
        else yield return null;
    }
    IEnumerator Enemy3Attack()
    {
        isChase = false;
        isAttack = true;
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;

        yield return new WaitForSeconds(0.8f);
        meleeArea.enabled = true;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(1f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Enemy4Attack()
    {
        isAttack = true;
        Speed = nav.speed;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(1f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;
        yield return new WaitForSeconds(1.6f);
        if (nav.enabled)
        {
            intanBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Rigidbody bulletRigid = intanBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPos.forward * 30f;
            BoxCollider box = intanBullet.GetComponent<BoxCollider>();
            box.enabled = true;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[32]);
            yield return new WaitForSeconds(2f);
            Destroy(intanBullet.gameObject);
            nav.speed = Speed;
            isChase = true;
            isAttack = false;
        }
        else yield return null;
    }
    IEnumerator Enemy5Attack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(2f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Enemy6Attack()
    {
        isAttack = true;
        Speed = nav.speed;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(1f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;
        yield return new WaitForSeconds(0.8f);
        if (nav.enabled)
        {
            intanBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Enemy4Rune.SetActive(true);
            Rigidbody bulletRigid = intanBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPos.forward * 50f;
            BoxCollider box = intanBullet.GetComponent<BoxCollider>();
            box.enabled = true;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[32]);
            yield return new WaitForSeconds(2f);
            Destroy(intanBullet.gameObject);
            Enemy4Rune.SetActive(false);
            nav.speed = Speed;
            isChase = true;
            isAttack = false;
        }
        else yield return null;
    }
    IEnumerator MazeAttack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.3f);
        if (!nav.enabled) yield return null;
        anim.SetTrigger("doAttack");

        yield return new WaitForSeconds(0.3f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        yield return new WaitForSeconds(1f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Maze2Attack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;
        yield return new WaitForSeconds(1f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Middle1_1Attack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.3f);
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(2.3f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        yield return new WaitForSeconds(2f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Middle2_1Attack()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.3f);
        if (nav.enabled) anim.SetTrigger("doAttack");
        else yield return null;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Middle3_1Attack1()
    {
        isAttack = true;
        Speed = nav.speed;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(0.5f);
        //isChase = false;
        if (nav.enabled) anim.SetTrigger("doAttack1");
        else yield return null;
        Boss3Magic1Roon.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (nav.enabled)
        {
            intanBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Vector3 t_dir1 = (player.transform.position - intanBullet.transform.position).normalized;
            Rigidbody bulletRigid1 = intanBullet.GetComponent<Rigidbody>();
            bulletRigid1.velocity = t_dir1 * 30f;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);

            yield return new WaitForSeconds(1f);

            intanBullet2 = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Vector3 t_dir2 = (player.transform.position - intanBullet2.transform.position).normalized;
            Rigidbody bulletRigid2 = intanBullet2.GetComponent<Rigidbody>();
            bulletRigid2.velocity = t_dir2 * 30f;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
            yield return new WaitForSeconds(1f);
            intanBullet3 = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            Vector3 t_dir3 = (player.transform.position - intanBullet3.transform.position).normalized;
            Rigidbody bulletRigid3 = intanBullet3.GetComponent<Rigidbody>();
            bulletRigid3.velocity = t_dir3 * 30f;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[31]);
            yield return new WaitForSeconds(2f);
            Destroy(intanBullet.gameObject);
            Destroy(intanBullet2.gameObject);
            Destroy(intanBullet3.gameObject);
            Boss3Magic1Roon.SetActive(false);
            nav.speed = Speed;
            //isChase = true;
            isAttack = false;
            wasMelee = false;
        }
        else yield return null;
    }
    IEnumerator Middle3_1Attack2()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.3f);
        Boss1Mouse.SetActive(true);
        if (nav.enabled) anim.SetTrigger("doAttack2");
        else yield return null;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[33]);
        yield return new WaitForSeconds(3f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[34]);
        intanMonster1 = Instantiate(Boss3MonsterPrepab1, MonsterPos1.position, MonsterPos1.rotation);
        Boss3doMonsterMonsterFloor1.SetActive(true);
        intanMonster2 = Instantiate(Boss3MonsterPrepab2, MonsterPos2.position, MonsterPos2.rotation);
        Boss3doMonsterMonsterFloor2.SetActive(true);
        intanMonster3 = Instantiate(Boss3MonsterPrepab3, MonsterPos3.position, MonsterPos3.rotation);
        Boss3doMonsterMonsterFloor3.SetActive(true);
        intanMonster4 = Instantiate(Boss3MonsterPrepab4, MonsterPos4.position, MonsterPos4.rotation);
        Boss3doMonsterMonsterFloor4.SetActive(true);

        yield return new WaitForSeconds(2f);
        Boss3doMonsterMonsterFloor1.SetActive(false);
        Boss3doMonsterMonsterFloor2.SetActive(false);
        Boss3doMonsterMonsterFloor3.SetActive(false);
        Boss3doMonsterMonsterFloor4.SetActive(false);
        Boss1Mouse.SetActive(false);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Middle3_1Attack3()
    {
        isChase = false;
        isAttack = true;
        yield return new WaitForSeconds(1.2f);
        if (nav.enabled) anim.SetTrigger("doAttack3");
        else yield return null;
        yield return new WaitForSeconds(1.2f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[6]);
        intanMiddle3_1Ice = Instantiate(Middle3_1IcePrepab, Middle3_1IcePos.position, Middle3_1IcePos.rotation);
        yield return new WaitForSeconds(1.3f);
        Destroy(intanMiddle3_1Ice.gameObject);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Middle3_2Attack1()
    {
        isChase = false;
        isAttack = true;

        meleeArea.GetComponent<MeshRenderer>().material = Meleemat[0];
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Enemymat[0];
        yield return new WaitForSeconds(0.3f);
        if (nav.enabled) anim.SetTrigger("doAttack1");
        else yield return null;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        isChase = true;
        isAttack = false;
        wasMelee = true;
    }
    IEnumerator Middle3_2Attack2()
    {
        isChase = false;
        isAttack = true;

        meleeArea.GetComponent<MeshRenderer>().material = Meleemat[0];
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Enemymat[0];
        yield return new WaitForSeconds(0.3f);
        if (nav.enabled) anim.SetTrigger("doAttack2");
        else yield return null;
        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(2f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        isChase = true;
        isAttack = false;
        wasMelee = true;
    }
    IEnumerator Middle3_2Attack3()
    {
        isChase = false;
        isAttack = true;

        meleeArea.GetComponent<MeshRenderer>().material = Meleemat[0];
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = Enemymat[0];
        yield return new WaitForSeconds(0.3f);
        if (nav.enabled) anim.SetTrigger("doAttack3");
        else yield return null;

        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        isChase = true;
        isAttack = false;
        wasMelee = true;
    }
    IEnumerator Middle3_2Attack4()
    {
        isAttack = true;
        Speed = nav.speed;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(0.5f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("doAttack4");
        else yield return null;
        yield return new WaitForSeconds(1f);
        if (nav.enabled)
        {
            intanBullet = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            intanBullet2 = Instantiate(bullet, bulletPos2.position, bulletPos2.rotation);
            intanBullet3 = Instantiate(bullet, bulletPos3.position, bulletPos3.rotation);
            yield return new WaitForSeconds(0.5f);
            BoxCollider box = intanBullet.GetComponent<BoxCollider>();
            box.enabled = true;
            BoxCollider box2 = intanBullet2.GetComponent<BoxCollider>();
            box2.enabled = true;
            BoxCollider box3 = intanBullet3.GetComponent<BoxCollider>();
            box3.enabled = true;
            Rigidbody bulletRigid = intanBullet.GetComponent<Rigidbody>();
            bulletRigid.velocity = bulletPos.right * 40f;
            Rigidbody bulletRigid2 = intanBullet2.GetComponent<Rigidbody>();
            bulletRigid2.velocity = bulletPos2.right * 40f;
            Rigidbody bulletRigid3 = intanBullet3.GetComponent<Rigidbody>();
            bulletRigid3.velocity = bulletPos3.right * 40f;
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[13]);
            yield return new WaitForSeconds(2f);
            Destroy(intanBullet.gameObject);
            Destroy(intanBullet2.gameObject);
            Destroy(intanBullet3.gameObject);
            nav.speed = Speed;
            isChase = true;
            isAttack = false;
            wasMelee = false;
        }
        else yield return null;
    }
    IEnumerator Boss1Attack1()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("Attack1");
        else yield return null;

        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(1f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss1Attack2()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("Attack2");
        else yield return null;

        yield return new WaitForSeconds(0.6f);
        meleeArea.enabled = true;
        SwordSlashEffect.SetActive(true);

        yield return new WaitForSeconds(0.6f);
        meleeArea.enabled = false;
        SwordSlashEffect.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss2Attack1()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("Attack1");
        else yield return null;

        yield return new WaitForSeconds(0.8f);
        Boss2Area.enabled = true;
        SwordSlashEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Boss2Area.enabled = false;
        SwordSlashEffect.SetActive(false);
        yield return new WaitForSeconds(2f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss2Attack2()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(1f);
        if (nav.enabled) anim.SetTrigger("Attack2");
        else yield return null;
        yield return new WaitForSeconds(1.6f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[36]);
        Boss2Particle.SetActive(true);
        camShake.Shake();
        Boss2Attack2Box.enabled = true;
        yield return new WaitForSeconds(0.2f);
        Boss2Attack2Box.enabled = false;
        yield return new WaitForSeconds(1.5f);
        Boss2Particle.SetActive(false);
        yield return new WaitForSeconds(2f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss3Attack1()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[38]);
        if (nav.enabled) anim.SetTrigger("Attack1");
        else yield return null;
        Boss3Area.enabled = true;
        SwordSlashEffect.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[37]);
        Boss3Attack1Floor.SetActive(true);
        Boss3Area.enabled = false;
        SwordSlashEffect.SetActive(false);
        yield return new WaitForSeconds(2f);
        Boss3Attack1Floor.SetActive(false);
        yield return new WaitForSeconds(1f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss3Attack2()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(0.5f);
        if (nav.enabled) anim.SetTrigger("Attack2");
        else yield return null;
        yield return new WaitForSeconds(1.2f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[40]);
        SwordSlashEffect.SetActive(true);
        Boss3Particle.SetActive(true);
        Boss3Area.enabled = true;
        camShake.Shake();
        Boss3Attack2Box.enabled = true;
        yield return new WaitForSeconds(0.3f);
        SwordSlashEffect.SetActive(false);
        Boss3Area.enabled = false;
        Boss3Particle.SetActive(false);
        Boss3Attack2Box.enabled = false;
        yield return new WaitForSeconds(2f);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss3Attack3()
    {
        isChase = false;
        isAttack = true;

        yield return new WaitForSeconds(1.8f);
        Boss3doMonsterFloor.SetActive(true);
        if (nav.enabled) anim.SetTrigger("doMonster");
        else yield return null;
        Boss1Mouse.SetActive(true);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[44]);
        yield return new WaitForSeconds(3f);
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[45]);
        Boss3doMonsterFloor.SetActive(false);
        intanMonster1 = Instantiate(Boss3MonsterPrepab1, MonsterPos1.position, MonsterPos1.rotation);
        Boss3doMonsterMonsterFloor1.SetActive(true);
        intanMonster2 = Instantiate(Boss3MonsterPrepab2, MonsterPos2.position, MonsterPos2.rotation);
        Boss3doMonsterMonsterFloor2.SetActive(true);
        intanMonster3 = Instantiate(Boss3MonsterPrepab3, MonsterPos3.position, MonsterPos3.rotation);
        Boss3doMonsterMonsterFloor3.SetActive(true);
        intanMonster4 = Instantiate(Boss3MonsterPrepab4, MonsterPos4.position, MonsterPos4.rotation);
        Boss3doMonsterMonsterFloor4.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        Boss1Mouse.SetActive(false);
        Boss3doMonsterMonsterFloor1.SetActive(false);
        Boss3doMonsterMonsterFloor2.SetActive(false);
        Boss3doMonsterMonsterFloor3.SetActive(false);
        Boss3doMonsterMonsterFloor4.SetActive(false);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss3Attack4()
    {
        isAttack = true;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(1f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("Magic1");
        else yield return null;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[41]);
        Boss3Magic1Effect.SetActive(true);
        Boss3Magic1Roon.SetActive(true);
        yield return new WaitForSeconds(2f);
        intanBoss3Magic1 = Instantiate(Boss3Magic1Prepab, Boss3Magic1Pos.position, Boss3Magic1Pos.rotation);
        Vector3 t_dir1 = (player.transform.position - intanBoss3Magic1.transform.position).normalized;
        Rigidbody bulletRigid1 = intanBoss3Magic1.GetComponent<Rigidbody>();
        bulletRigid1.velocity = t_dir1 * 30f;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[42]);
        yield return new WaitForSeconds(1f);
        intanBoss3Magic1_2 = Instantiate(Boss3Magic1Prepab, Boss3Magic1Pos.position, Boss3Magic1Pos.rotation);
        Vector3 t_dir2 = (player.transform.position - intanBoss3Magic1_2.transform.position).normalized;
        Rigidbody bulletRigid2 = intanBoss3Magic1_2.GetComponent<Rigidbody>();
        bulletRigid2.velocity = t_dir2 * 30f;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[42]);
        yield return new WaitForSeconds(1f);
        intanBoss3Magic1_3 = Instantiate(Boss3Magic1Prepab, Boss3Magic1Pos.position, Boss3Magic1Pos.rotation);
        Vector3 t_dir3 = (player.transform.position - intanBoss3Magic1_3.transform.position).normalized;
        Rigidbody bulletRigid3 = intanBoss3Magic1_3.GetComponent<Rigidbody>();
        bulletRigid3.velocity = t_dir3 * 30f;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[42]);
        yield return new WaitForSeconds(4f);
        Destroy(intanBoss3Magic1);
        Boss3Magic1Effect.SetActive(false);
        Boss3Magic1Roon.SetActive(false);
        isChase = true;
        isAttack = false;
    }
    IEnumerator Boss3Attack5()
    {
        isAttack = true;
        Vector3 dir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 10);
        yield return new WaitForSeconds(1f);
        isChase = false;
        if (nav.enabled) anim.SetTrigger("Magic2");
        else yield return null;
        SwordSlashEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        SwordSlashEffect.SetActive(false);
        intanBoss3Magic2 = Instantiate(Boss3Magic2Prepab, Boss3Magic2Pos.position, Boss3Magic2Pos.rotation);
        Vector3 t_dir1 = (player.transform.position - intanBoss3Magic2.transform.position).normalized;
        Rigidbody bulletRigid1 = intanBoss3Magic2.GetComponent<Rigidbody>();
        bulletRigid1.velocity = t_dir1 * 30f;
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[32]);
        yield return new WaitForSeconds(1.5f);
        isChase = true;
        isAttack = false;
    }
    void FreezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
    void SwordSound()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[7]);
    }
    void BossSwordSound()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[39]);
    }
    void MazeSound()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[35]);
    }
    //Player Magic1 Skill
    void OnTriggerStay(Collider other)
    {   
        if(gameObject.layer != 8)
        {
            if (other.tag == "Bullet1" && !doMagic2)
            {  
                doMagic2 = true;
                Invoke("Magic1Damaged", 0.5f);
            }
        }  
    }
    void Magic1Damaged()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[25]);
        MagicDamageParticle.SetActive(true);
        Invoke("SwordDamageParticleOut", 0.2f);
        curHealth -= playerMove.Magic1SkillDmg;
        if(type != Type.Boss) text.text = playerMove.Magic1SkillDmg.ToString();
        Invoke("FloatingTextOut", 0.5f);
        Vector3 reactVec = transform.position - transform.position;
        StartCoroutine(onDamage(reactVec));
        doMagic2 = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer != 8)
        {   
            // 기본 공격
            if (other.tag == "Melee")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[23]);
                SwordDamageParticle.SetActive(true);
                Invoke("SwordDamageParticleOut", 0.2f);
                curHealth -= (playerMove.EqipAD + playerMove.AD);
                text.text = (playerMove.EqipAD + playerMove.AD).ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));
            }
            // 기본 공격
            if (other.tag == "Bullet")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[25]);
                MagicDamageParticle.SetActive(true);
                Invoke("MagicDamageParticleOut", 0.2f);
                curHealth -= (playerMove.EqipAP + playerMove.AP);
                text.text = (playerMove.EqipAP + playerMove.AP).ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));

                if (other.gameObject.layer == 14) Destroy(other.gameObject);
            }
            if (other.tag == "Bow")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[25]);
                MagicDamageParticle.SetActive(true);
                Invoke("MagicDamageParticleOut", 0.2f);
                curHealth -= 500;
                text.text = 500.ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));

                if (other.gameObject.layer == 14) Destroy(other.gameObject);
            }
            // 매직3 스킬
            if (other.tag == "Bullet3")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[25]);
                MagicDamageParticle.SetActive(true);
                Invoke("MagicDamageParticleOut", 0.2f);
                curHealth -= playerMove.Magic3SkillDmg;
                text.text = playerMove.Magic3SkillDmg.ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));

                if (other.gameObject.layer == 14) Destroy(other.gameObject);
            }
            // 검 1스킬
            if (other.tag == "Sword1")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[23]);
                SwordDamageParticle.SetActive(true);
                Invoke("SwordDamageParticleOut", 0.2f);
                curHealth -= playerMove.Sword1SkillDmg;
                text.text = playerMove.Sword1SkillDmg.ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));
            }
            // 검 2스킬
            if (other.tag == "Sword2")
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[23]);
                SwordDamageParticle.SetActive(true);
                Invoke("SwordDamageParticleOut", 0.2f);
                curHealth -= playerMove.Sword2SkillDmg;
                text.text = playerMove.Sword2SkillDmg.ToString();
                Invoke("FloatingTextOut", 0.5f);
                Vector3 reactVec = transform.position - other.transform.position;
                StartCoroutine(onDamage(reactVec));
            }
            if (other.tag == "Ice")
            {
                StartCoroutine(HittdIce());
            }
        }

    }
    void MagicDamageParticleOut()
    {
        MagicDamageParticle.SetActive(false);
    }
    void SwordDamageParticleOut()
    {
        SwordDamageParticle.SetActive(false);
    }

    // 검 3스킬
    public void GoSword3()
    {
        Sword3Effet.SetActive(true);
        Invoke("Sword3Damaged", 1.2f);
    }
    void Sword3Damaged()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[15]);
        SwordDamageParticle.SetActive(true);
        curHealth -= playerMove.Sword3SkillDmg;
        text.text = playerMove.Sword3SkillDmg.ToString();
        Invoke("FloatingTextOut", 0.5f);
        Vector3 reactVec = transform.position - transform.position;
        StartCoroutine(onDamage(reactVec));
        Invoke("SwordDamageParticleOut", 0.2f);
        Invoke("Swrod3Out", 2f);
    }
    public void Swrod3Out()
    {
        Sword3Effet.SetActive(false);
    }
    IEnumerator HittdIce()
    {
        gameObject.layer = 14;
        anim.speed = 0;
        isChase = false;
        nav.enabled = false;
        isAttack = true;
        mat.color = Color.blue;
        yield return new WaitForSeconds(4f);
        isChase = true;
        nav.enabled = true;
        isAttack = false;
        mat.color = Color.white;
        anim.speed = 1;
        gameObject.layer = 7;
    }
    void FloatingTextOut()
    {
        text.text = "";
    }
    IEnumerator onDamage(Vector3 reactVec)
    {
        isDamaged = true;
        mat.color = Color.red;
        
        yield return new WaitForSeconds(0.2f);

        if(curHealth > 0)
        {
            mat.color = Color.white;
            MagicDamageParticle.SetActive(false);
        }
        else
        {
            SoundManager.instace.SFXPlay("Melee", playerMove.clip[9]);
            mat.color = Color.gray;
            gameObject.layer = 8;
            isChase = false;
            nav.enabled = false;
            isAttack = true;

            intanBullet = Instantiate(GoldObj, DropItemPos.position, DropItemPos.rotation);

            if (Type.MeleeGiblin == type)
            {
                dieEnemy1++;
            }

            if (Type.Boss == type || Type.MiddleBoss == type)
            {
                int curB = playerMove.curBoss;
                playerMove.DieBoss(curB);

                intanBox = Instantiate(GoldBox, DropItemPos.position, DropItemPos.rotation);

                if(meleeArea) meleeArea.enabled = false;
                playerMove.isBoss = false;
                if (playerMove.curTown == 0) SoundManager.instace.BgSoundPlay(playerMove.bglist[3]);
                else if (playerMove.curTown == 1) SoundManager.instace.BgSoundPlay(playerMove.bglist[4]);
                else if (playerMove.curTown == 2) SoundManager.instace.BgSoundPlay(playerMove.bglist[5]);
                RenderSettings.skybox = playerMove.Skymaterial[0];
                playerMove.curBoss = -1;
            }
            else if (Type.MeleeGiblin == type) StopCoroutine(MeleeGoblinAttack());
            else if (Type.GoblinGirl == type) StopCoroutine(GoblinGirlAttack());
            else if (Type.ETC == type) StopCoroutine(ETCAttack());
            else if (Type.Enemy3 == type) StopCoroutine(Enemy3Attack());
            else if (Type.Enemy4 == type) StopCoroutine(Enemy4Attack());
            else if (Type.Enemy5 == type) StopCoroutine(Enemy5Attack());
            else if (Type.Enemy6 == type) StopCoroutine(Enemy6Attack());
            else if (Type.maze2 == type) StopCoroutine(Maze2Attack());
            else if (Type.MiddleBoss == type)
            {   
                if(bossNum == 1)
                {
                    StopCoroutine(Middle1_1Attack());
                }
                if (bossNum == 2)
                {
                    StopCoroutine(Middle1_1Attack());
                }
                if (bossNum == 3)
                {
                    StopCoroutine(Middle3_2Attack1());
                    StopCoroutine(Middle3_2Attack2());
                    StopCoroutine(Middle3_2Attack3());
                    StopCoroutine(Middle3_2Attack4());
                }
                if (bossNum == 4)
                {
                    StopCoroutine(Middle1_1Attack());
                }
            }
            else if (Type.Boss == type)
            {
                if (bossNum == 1)
                {
                    StopCoroutine(Boss1Attack1());
                    StopCoroutine(Boss1Attack2());
                }
                if (bossNum == 2)
                {
                    StopCoroutine(Boss2Attack1());
                    StopCoroutine(Boss2Attack2());
                }
                if (bossNum == 3)
                {
                    StopCoroutine(Boss3Attack1());
                    StopCoroutine(Boss3Attack2());
                    StopCoroutine(Boss3Attack3());
                    StopCoroutine(Boss3Attack4());
                    StopCoroutine(Boss3Attack5());
                }
            }
            anim.SetTrigger("doDie");
            Destroy(gameObject, 3.5f);
        }
    }
}