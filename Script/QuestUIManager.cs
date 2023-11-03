using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    private KeyCode questToggleKey = KeyCode.Q;
    public GameObject myQuestUI;
    public JsonQuestLoader questLoader;
    public Text questDataText;
    public QuestManager questManager;

    // private bool isQuestUIActive;

    public void Start()
    {
        myQuestUI = transform.Find("MyQuestUI").gameObject;
        questLoader = FindObjectOfType<JsonQuestLoader>();
        questDataText = myQuestUI.GetComponentInChildren<Text>(); 
        // myQuestUI.SetActive(false);
        // isQuestUIActive = false;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(questToggleKey))
        {
            ToggleQuestUI();
        }*/
        ToggleQuestUI();
    }
    public void UpdateQuestTitle(string questTitle)
    {
        questDataText.text = questTitle;
    }
    public void ToggleQuestUI()
    {
        // isQuestUIActive = !isQuestUIActive;
        // myQuestUI.SetActive(isQuestUIActive);

        int acceptedQuestsCount = QuestManager.Instance.acceptedQuests.Count;

        // Debug.Log("ToggleQuestUI : " + acceptedQuestsCount);

        if (true)
        {
            string allQuestData = questLoader.PrintAllAcceptedQuestData();
            UpdateQuestTitle(allQuestData);
            // Debug.Log(allQuestData);
        }
        if(acceptedQuestsCount == 0)
        {
            string allQuestData_empty = " ";
            UpdateQuestTitle(allQuestData_empty);
            // Debug.Log("empty");
        }
    }
}
