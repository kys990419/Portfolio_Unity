using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;

public class QuestAcceptButton : MonoBehaviour
{
    public GameObject onBtn;
    public GameObject On;
    public QuestClearList questClear;
    public bool isQuestUI;
    public GameObject MyQuestUI;
    //public GameObject QuestUI;
    public PlayerMove playerMove;
    public GameObject dialogUI;
    public GameObject questUI;
    public GameObject questAcceptButton;
    public GameObject questCompleteButton;
    public NpcIdGiver npcIdGiver;
    private Button acceptButton;
    private int npcId;
    private int questId;

    private void Start()
    {

        acceptButton = GetComponent<Button>();
        acceptButton.onClick.AddListener(AcceptQuest);
        acceptButton.onClick.AddListener(CallQuestMark2);
        acceptButton.onClick.AddListener(CallQuestClearList);
    }

    public void SetNpcId_Accept(int NpcId, int MyQuestAcceptNumber)
    {
        npcId = NpcId;
        questId = MyQuestAcceptNumber;
    }
    private void Update()
    {
        
    }
    private void AcceptQuest()
    {
        SoundManager.instace.SFXPlay("Melee", playerMove.clip[47]);
        FindObjectOfType<JsonQuestLoader>()?.AcceptQuest(npcId, questId);
        NpcIdGiver npcIdGiver = NpcIdGiver.FindNpcIdGiver(npcId);
        if (npcIdGiver != null)
        {
            npcIdGiver.SetCheckQuest(true);
        }

        //QuestUI.gameObject.SetActive(false);
        dialogUI.SetActive(false);
        //questUI.SetActive(false);
        //questAcceptButton.SetActive(false);
        //questCompleteButton.SetActive(false);
        playerMove.isQuest = false;
        playerMove.anim.speed = 1;
        MyQuestUI.gameObject.SetActive(true);
        On.gameObject.SetActive(false);
        //onBtn.gameObject.SetActive(false);

    }
    void CallQuestMark2()
    {
        QuestMark questMark2 = FindObjectOfType<QuestMark>();
        if (questMark2 != null)
        {
            questMark2.CloseAcceptMark();
        }
    }
    void CallQuestClearList()
    {
        QuestClearList questClearList = FindObjectOfType<QuestClearList>();
        if(questClearList != null)
        {
            questClearList.CallFunction(QuestManager.Instance.QuestAcceptNumber);
        }
    }
}
