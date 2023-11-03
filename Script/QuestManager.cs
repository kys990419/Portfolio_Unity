using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public int QuestAcceptNumber = 1;
    public int MyQuestAcceptNumber = 1;
    public int MyQuestCompleteNumber = 1;
    public List<int> acceptedQuests;
    private static QuestManager instance;

    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if (instance == null)
                {
                    GameObject manager = new GameObject("QuestManager");
                    instance = manager.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        
        acceptedQuests = new List<int>();
    }

    public bool AcceptQuest(int questId, int npcId) // myQuestAcceptNumber
    {

        if (acceptedQuests.Contains(questId))
        {
            Debug.Log("Quest is already accepted.");
            return false;
        }
        acceptedQuests.Add(questId);
        acceptedQuests.Add(npcId);
        return true;
    }

    public void CompleteQuest(int npcId, int myQuestCompleteNumber)
    {
    
        if (acceptedQuests.Contains(myQuestCompleteNumber))
        {
            if (acceptedQuests[0] == myQuestCompleteNumber && acceptedQuests[1] == npcId)
            {
                acceptedQuests.Remove(myQuestCompleteNumber);
                acceptedQuests.Remove(npcId);

                QuestAcceptNumber++;
                MyQuestAcceptNumber++;
                MyQuestCompleteNumber++;

                // Debug.Log("Remaining accepted quests: " + acceptedQuests.Count);

                if (acceptedQuests.Count == 0)
                {
                    // Debug.Log("All quests completed.");
                }
                else
                {
                    Debug.Log("Quests in progress: " + string.Join(", ", acceptedQuests));
                }
            }
            else
            {
                Debug.Log("No have quest");
            }
        }
        else
        {
            Debug.Log("Empty Quest");
        }
    }
}
