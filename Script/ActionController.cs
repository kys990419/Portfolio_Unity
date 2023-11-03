using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class ActionController : MonoBehaviour
{
    public CollisionDetector collisionDetector;
    public int NPCnum;
    public PlayerMove playerMove;
    public GameObject QuestHIde;
    public Camchagne camchagne;
    public WeaponInven weaponInven;
    [SerializeField]
    private float range; // 습득 가능한 최대 거리.
    private bool pickupActivated = false;
    private bool NPCActivated = false;
    private RaycastHit hitInfo; // 충돌체 정보 저장.
    private RaycastHit hitInfo2; // 충돌체 정보 저장.
    public RaycastHit hitInfo3;

    // 아이템 레이어에만 반응하도록 레이어 마스크를 설정.
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask NPClayerMask;
    [SerializeField]
    private LayerMask DodgelayerMask;

    // 필요한 컴포넌트.
    [SerializeField]
    private Text actionText;
    [SerializeField]
    private Text actionText2;
    [SerializeField]
    private Inventory theInventory;
    public PortionInven portionInven;
    public ArmorInven armorInven;
    public Camera cam;
    public Transform NPCname;
    CinemachineVirtualCamera vCam;
    
    private void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }
    void Update()
    {
        CheckItem();
        CheckNPC();
        TryAction();
        dodgeCheck();
    }
    public void dodgeCheck()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo3, 10, DodgelayerMask))
        {
            playerMove.nododge = true;
        }
        else playerMove.nododge = false;
    }
    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {   
            if(hitInfo.transform != null)
            {
                CheckItem();
                CanPickUp();
            }
            if(hitInfo2.transform != null)
            {
                CheckNPC();
                CanNPC();
            }
        }
    }

    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if (hitInfo.transform != null)
            {
                SoundManager.instace.SFXPlay("Melee", playerMove.clip[30]);
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                InfoDisappear();
            }
        }
    }
    private void CanNPC()
    {
        if (NPCActivated)
        {
            if (hitInfo2.transform.name == "WeaponNPC")
            {
                WeaponInven.WeaponyActivated = !WeaponInven.WeaponyActivated;

                if (WeaponInven.WeaponyActivated)
                    weaponInven.OpenInventory();
                else
                    weaponInven.CloseInventory();
            }
            
            if (hitInfo2.transform.name == "PortionNPC")
            {
                PortionInven.PortionInvenActivated = !PortionInven.PortionInvenActivated;

                if (PortionInven.PortionInvenActivated)
                    portionInven.OpenInventory();
                else
                    portionInven.CloseInventory();
            }
            if (hitInfo2.transform.name == "WeaponNPC2")
            {
                ArmorInven.ArmorActivated = !ArmorInven.ArmorActivated;

                if (ArmorInven.ArmorActivated)
                    armorInven.OpenInventory();
                else
                    armorInven.CloseInventory();
            }
            if(hitInfo2.transform.tag == "QuestNPC")
            {
                /*
                Animator anim = hitInfo2.transform.GetComponent<Animator>();
                anim.SetTrigger("doAction");

                if (hitInfo2.transform.name == "MotherNPC")
                {
                    NPCnum = 0;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "elderNPC")
                {
                    NPCnum = 1;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "soldier1")
                {
                    NPCnum = 2;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "soldier2")
                {
                    NPCnum = 3;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "soldier3")
                {
                    NPCnum = 4;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "soldier4")
                {
                    NPCnum = 5;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "soldier5")
                {
                    NPCnum = 6;
                    camchagne.ShowNpc1(NPCnum);
                }
                if (hitInfo2.transform.name == "WizardNPC")
                {
                    NPCnum = 7;
                    camchagne.ShowNpc1(NPCnum);
                }
                QuestHIde.gameObject.SetActive(false);
                playerMove.isDamage = true;

                Vector3 t_dir2 = playerMove.transform.position;
                Vector3 t_dir = (hitInfo2.transform.position - playerMove.transform.position).normalized;
                playerMove.transform.position = t_dir;
                */
            }
        }
    }
    /*  대화끝나면
     camchagne[NPCnum].ShowMain();
     playerMove.transform.position = t_dir2;
     playerMove.isDamage = false;
    */
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
            InfoDisappear();
    }
    private void CheckNPC()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo2, range, NPClayerMask))
        {
            if (hitInfo2.transform.tag == "NPC1" || hitInfo2.transform.tag == "NPC2" || hitInfo2.transform.tag == "NPC3" || hitInfo2.transform.tag == "QuestNPC")
            {
                NPCInfoAppear();
            }
        }
        else
            NPCInfoDisappear();
    }
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = "<color=yellow>" +  hitInfo.transform.gameObject.GetComponent<ItemPickUp>().item.itemName + "</color>" + 
            "을(를) 획득하려면 " + "<color=yellow>" + "(G)" + "</color>" + "키";
    }
    private void NPCInfoAppear()
    {
        NPCActivated = true;
        actionText2.gameObject.SetActive(true);
        actionText2.text = "<color=yellow>" + "(G)" + "</color>" + "키를 눌러 대화하기";
    }
    private void InfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
    private void NPCInfoDisappear()
    {
        NPCActivated = false;
        actionText2.gameObject.SetActive(false);
    }
}
