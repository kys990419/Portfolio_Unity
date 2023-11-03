using UnityEngine;
using UnityEngine.UI;

public class QuestCompleteButton : MonoBehaviour
{
    public Item Heal;
    public Item Mana;
    public GameObject OffBtn;
    public GameObject Off;
    public Slot slot;
    public Inventory inventory;
    public CollisionDetector collisionDetector;
    public QuestAcceptButton questAcceptBtn;
    public PlayerMove playerMove;
    public QuestClearList questClearList;
    public GameObject dialogUI;
    public GameObject questUI;
    public GameObject questAcceptButton;
    public GameObject questCompleteButton;
    public NpcIdGiver npcIdGiver;
    public QuestMark questMark;

    private Button completeButton;
    private int npcId;
    private int questId;
    private void Start()
    {
        completeButton = GetComponent<Button>();
        completeButton.onClick.AddListener(CallCloseClearMark);
        completeButton.onClick.AddListener(CompleteQuest);
        completeButton.onClick.AddListener(CallQuestMark);
    }

    public void SetNpcId_Complete(int NpcId, int MyQuestCompleteNumber) 
    {
        npcId = NpcId;
        questId = MyQuestCompleteNumber;
    }

    private void CompleteQuest()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[26]);
        if (questClearList.curQuest == 1)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "토마토")
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }
            }
        }
        if (questClearList.curQuest == 1)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";

        }
        if (questClearList.curQuest == 2)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";

        }
        if (questClearList.curQuest == 3)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 4)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            playerMove.Upgread1();
        }
        if (questClearList.curQuest == 5)
        {
            for (int j = 0; j < 10; j++)
            {
                inventory.AcquireItem(Heal, 1);
                inventory.AcquireItem(Mana, 1);
            }
            playerMove.HealPortion += 10;
            playerMove.ui.curHealNum(playerMove.HealPortion);
            playerMove.ManaPortion += 10;
            playerMove.ui.curManaNum(playerMove.ManaPortion);
        }
        if (questClearList.curQuest == 6)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "고블린 궁수 전리템")
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }
            }
        }
        if (questClearList.curQuest == 7)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 8)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 9)
        {
            playerMove.Gold += 500;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "고블린 행동대장의 척추")
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }
            }
        }
        if (questClearList.curQuest == 10)
        {
            for (int j = 0; j < 10; j++)
            {
                inventory.AcquireItem(Heal, 1);
                inventory.AcquireItem(Mana, 1);
            }
            playerMove.HealPortion += 10;
            playerMove.ui.curHealNum(playerMove.HealPortion);
            playerMove.ManaPortion += 10;
            playerMove.ui.curManaNum(playerMove.ManaPortion);
        }
        if (questClearList.curQuest == 11)
        {
            playerMove.Gold += 1000;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            playerMove.Upgread2();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "고블린 왕의 두골")
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            Debug.Log(inventory.slots[i].itemCount);
                            inventory.slots[i].itemCount -= 1;
                            slot.SetSlotCount2(inventory.slots[i]);
                        }
                    }
                }
            }
        }
        if (questClearList.curQuest == 12)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 13)
        {
            playerMove.Gold += 300;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 14)
        {
            playerMove.Gold += 200;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 15)
        {
            playerMove.Gold += 200;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 16)
        {
            playerMove.Gold += 200;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "신비로운약")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 17)
        {
            playerMove.Gold += 200;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 18)
        {
            playerMove.Gold += 200;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "해골궁수의 뿔")
                    {
                        inventory.slots[i].itemCount -= 10;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 19)
        {
            playerMove.Gold += 400;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "해골 기사의 갈비뼈")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 20)
        {
            playerMove.Gold += 400;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 21)
        {
            playerMove.Gold += 400;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "불로초")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 22)
        {
            playerMove.Gold += 2000;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "암석거인의 파편")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
            playerMove.Upgread3();
        }
        if (questClearList.curQuest == 23)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";


        }
        if (questClearList.curQuest == 24)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 25)
        {
            playerMove.Gold += 100;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 26)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 27)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 28)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 29)
        {
            playerMove.Gold += 800;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 30)
        {
            playerMove.Gold += 800;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 31)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "검은망령의 전리품")
                    {
                        inventory.slots[i].itemCount -= 10;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 32)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 33)
        {
            playerMove.Gold += 600;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 34)
        {
            playerMove.Gold += 2000;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "뒤틀린 주술사의 목걸이")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }
        if (questClearList.curQuest == 35)
        {
            playerMove.Gold += 2000;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "뒤틀린 사신의 모래시계")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
            playerMove.Upgread4();
        }
        if (questClearList.curQuest == 36)
        {
            playerMove.Gold += 800;
            playerMove.ui.goldText.text = playerMove.Gold + "";
        }
        if (questClearList.curQuest == 37)
        {
            playerMove.Gold += 1000000;
            playerMove.ui.goldText.text = playerMove.Gold + "";

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "지옥 수문장의 전리품 책")
                    {
                        inventory.slots[i].itemCount -= 1;
                        slot.SetSlotCount2(inventory.slots[i]);
                    }
                }
            }
        }

        questClearList.curQuest = 0;
        playerMove.curBoss = -1;



        if ( QuestManager.Instance.QuestAcceptNumber == 1)
        {
            questClearList.Q1Clear = false;
        }
        // Debug.Log(npcId + questId); // 첫 퀘스트 일때 npcid = 2 questid = 1
        // FindObjectOfType<JsonQuestLoader>()?.AcceptQuest(npcId, questId);
        
        NpcIdGiver npcIdGiver = NpcIdGiver.FindNpcIdGiver(npcId);
        if (npcIdGiver != null)
        {
            npcIdGiver.SetCheckQuest(false);
            Debug.Log("Change CheckQuest for Npc ID: " + npcId);
        }
        //questAcceptBtn.QuestUI.gameObject.SetActive(false);
        dialogUI.SetActive(false);
        //questUI.SetActive(false);
        //questAcceptButton.SetActive(false);
        //questCompleteButton.SetActive(false);
        playerMove.isQuest = false;
        playerMove.anim.speed = 1;
        // collisionDetector.onlyOneTime = false;

        Off.gameObject.SetActive(false);

        questClearList.clearQ = false;

        playerMove.MonsterKill = 0;
        questAcceptBtn.MyQuestUI.gameObject.SetActive(false);

        questClearList.curCount = 0;
        QuestManager.Instance.CompleteQuest(npcId, questId);
        OffBtn.gameObject.SetActive(false);

        questClearList.ProgressTxt.text = "";

    }
    void CallQuestMark()
    {
        QuestMark questMark = FindObjectOfType<QuestMark>();
        if (questMark != null)
        {
            questMark.CallCheckThis();
        }
    }
    void CallCloseClearMark()
    {
        QuestMark questMarkCloseClear = FindObjectOfType<QuestMark>();
        if (questMarkCloseClear != null)
        {
            questMarkCloseClear.CloseClearMark();
        }
    }
}
