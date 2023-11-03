using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class JsonQuestLoader : MonoBehaviour
{
    private NpcIdGiver npcIdGiver;
    public GameObject questUI;
    public QuestManager questManager;
    // JSON ?åÏùº Í≤ΩÎ°ú
    // public string filePath = "Assets/Resources/JP_QuestList.json";
    public string filePath = "JP_QuestList";
    public MessageController messageController_Quest;
    public List<AcceptedQuestData> acceptedQuestsData;
    public List<QuestData> allQuestsData; // ?àÎ°ú??Î¶¨Ïä§??Ï∂îÍ?

    // QuestID?Ä QuestGiver Í∞íÏùÑ ?Ä?•Ìï† Î≥Ä??
    private int questID;
    private int questGiver;
    private int questReceiver;



    private void Start()
    {
        int questAcceptNumber = QuestManager.Instance.QuestAcceptNumber;
        acceptedQuestsData = new List<AcceptedQuestData>();

        npcIdGiver = GetComponent<NpcIdGiver>();

        allQuestsData = new List<QuestData>(); // ?àÎ°ú??Î¶¨Ïä§??Ï¥àÍ∏∞??
        // JSON ?åÏùº ?ΩÍ∏∞
        string jsonData = LoadJsonFile();
        if (!string.IsNullOrEmpty(jsonData))
        {
            QuestDataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);

            if (dataWrapper != null && dataWrapper.QuestList != null)
            {
                foreach (QuestData quest in dataWrapper.QuestList)
                {
                    // Î™®Îì† ?òÏä§???∞Ïù¥?∞Î? allQuestsData Î¶¨Ïä§?∏Ïóê ?Ä??
                    allQuestsData.Add(quest);
                    
                }
            }
            else
            {
                Debug.LogError("Failed to convert JSON to QuestList.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }



        messageController_Quest = questUI.GetComponent<MessageController>();
        if (messageController_Quest == null)
        {
            Debug.LogError("MessageController component is not found on the QuestUI object!");
            return;
        }

        //questUI.SetActive(true);
    }
    private void Update()
    {   
        /*
        foreach (QuestData quest in allQuestsData)
        {
            if(quest.QuestID == questManager.QuestAcceptNumber)
            {
                FindObjectOfType<JsonQuestLoader>()?.ShowQuest(quest.QuestID);
            }
        }
        */
    }
    public void ShowQuest(int questId)
    {
        string jsonData = LoadJsonFile();

        if (!string.IsNullOrEmpty(jsonData))
        {
            QuestDataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);

            if (dataWrapper != null && dataWrapper.QuestList != null)
            {
                FindAndPrintData2(dataWrapper.QuestList, questId);
            }
            else
            {
                Debug.LogError("Failed to convert JSON to QuestList.");
            }
        }
    }
    public void HandleNpcCollision(int npcId, int questAcceptNumber)
    {
        // JSON ?åÏùº ?ΩÍ∏∞
        string jsonData = LoadJsonFile();

        // ?∞Ïù¥??Î≥Ä??Î∞?Ï∂úÎ†•
        if (!string.IsNullOrEmpty(jsonData))
        {
            QuestDataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);

            if (dataWrapper != null && dataWrapper.QuestList != null)
            {
                FindAndPrintData(dataWrapper.QuestList, npcId, questAcceptNumber);
            }
            else
            {
                Debug.LogError("Failed to convert JSON to QuestList.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }

    }

    public void AcceptQuest(int npcId, int myQuestAcceptNumber) // npcgiver.id Í∞íÏù¥ ?òÏñ¥???ÑÏû¨ ?¥Í? ?òÎùΩÍ∞Ä?•Ìïú ?òÏä§??Id(?òÏä§?∏Ï∞Ω?ÑÏö©)Í∞Ä ?òÏñ¥??
    {
        // Debug.Log("K : " + myQuestAcceptNumber);

        QuestData questcheck = GetQuestDataById(npcId, myQuestAcceptNumber);

        if(questcheck != null)
        {
            //
            bool success = QuestManager.Instance.AcceptQuest(myQuestAcceptNumber, npcId);

            if (success)
            {

                //
                QuestData quest = GetQuestDataById(npcId, myQuestAcceptNumber);
                if (quest == null)
                {
                    Debug.Log("quest empty shit");
                }
                if (quest != null)
                {
                    AcceptedQuestData acceptedQuest = new AcceptedQuestData
                    {
                        QuestID = quest.QuestID,
                        QuestTitle = quest.QuestTitle,
                        QuestContents = quest.QuestContents,
                        QuestContents2 = quest.QuestContents2,
                        QuestReward = quest.QuestReward,
                        QuestGiver = quest.QuestGiver,
                        QuestReceiver = quest.QuestReceiver,
                        QuestNote = quest.QuestNote
                        
                    };

                    // ?òÎùΩ???òÏä§???∞Ïù¥?∞Î? ?Ä??                    \
                    acceptedQuestsData.Add(acceptedQuest);
                }
            }
            else
            {
                Debug.Log("Failed to accept quest.");
            }
        }
    }
    public void RemoveAcceptedQuest(int questId)
    {
        AcceptedQuestData questToRemove = acceptedQuestsData.Find(quest => quest.QuestID == questId);
        if (questToRemove != null)
        {
            acceptedQuestsData.Remove(questToRemove);
           
        }
    }

    private string LoadJsonFile()
    {
        string jsonData = null;

        try
        {
            // ∏Æº“Ω∫ ∑ŒµÂ
            TextAsset textAsset = Resources.Load<TextAsset>("JP_QuestList");

            if (textAsset != null)
            {
                // ≈ÿΩ∫∆Æ µ•¿Ã≈Õ ∞°¡Æø¿±‚
                jsonData = textAsset.text;
            }
            else
            {
                Debug.LogError("JSON file not found!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load JSON file: " + ex.Message);
        }

        return jsonData;
    }

    /* private string LoadJsonFile()
    {
        string jsonData = null;

        try
        {
            // ?åÏùº Ï°¥Ïû¨ ?¨Î? ?ïÏù∏
            if (File.Exists(filePath))
            {
                // ?åÏùº ?ΩÍ∏∞
                jsonData = File.ReadAllText(filePath);
            }
            else
            {
                Debug.LogError("JSON file not found!");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to load JSON file: " + ex.Message);
        }
        return jsonData;
    } */

    private QuestDataWrapper ConvertJsonToDataWrapper(string json)
    {
        QuestDataWrapper dataWrapper = null;

        try
        {
            // JSON ?∞Ïù¥?∞Î? QuestDataWrapper Í∞ùÏ≤¥Î°?Î≥Ä??
            dataWrapper = JsonUtility.FromJson<QuestDataWrapper>(json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to convert JSON to QuestList: " + ex.Message);
        }
        return dataWrapper;
    }

    private void PrintQuestData(QuestData[] QuestList)
    {
        foreach (QuestData quest in QuestList)
        {
            string data = //"Quest ID: " + quest.QuestID + "\n" +
                          "<color=yellow>" + "[ƒ˘Ω∫∆Æ]: "+ "</color>" + quest.QuestTitle + "\n" + "\n" +
                          "<color=yellow>" + "[ƒ˘Ω∫∆Æ ≥ªøÎ]: " + "</color>" + quest.QuestContents + "\n" + "\n" +
                          "<color=yellow>" + "[ƒ˘Ω∫∆Æ ∫∏ªÛ]: " + "</color>" + quest.QuestReward + "\n" +
                          "<color=red>" +quest.QuestNote  + "</color>"; 


            messageController_Quest.UpdateMessage(data);
        }
    }

    private void FindAndPrintData(QuestData[] dataObjects, int npcId, int questAcceptNumber)
    {
        bool foundData = false;

        foreach (QuestData data in dataObjects)
        {
            if (data.QuestGiver == npcId && questAcceptNumber == data.QuestID)
            {
                
                PrintQuestData(new QuestData[] { data });
                foundData = true;
                break;
            }
        }

        if (!foundData)
        {
            messageController_Quest.UpdateMessage("No matching data found for Npc ID: " + npcId);
        }
    }
    private void FindAndPrintData2(QuestData[] dataObjects, int questId)
    {
        bool foundData = false;

        foreach (QuestData data in dataObjects)
        {
            if (questId == data.QuestID)
            {

                PrintQuestData(new QuestData[] { data });
                foundData = true;
                break;
            }
        }
    }



    private QuestData GetQuestDataById(int npcId, int myQuestAcceptNumber)
    {
        // JSON ?åÏùº ?ΩÍ∏∞
        string jsonData = LoadJsonFile();
        // ?∞Ïù¥??Î≥Ä??
        if (!string.IsNullOrEmpty(jsonData))
        {
            QuestDataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);

            if (dataWrapper != null && dataWrapper.QuestList != null)
            {
                foreach (QuestData quest in dataWrapper.QuestList)
                {
                    if (quest.QuestID == myQuestAcceptNumber && quest.QuestGiver == npcId)
                    {
                        return quest;
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to convert JSON to QuestList.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }

        return null;
    }
    public string PrintAllAcceptedQuestData()
    {
        string data = "";

        foreach (AcceptedQuestData acceptedQuest in acceptedQuestsData)
        {
            data = acceptedQuest.PrintAcceptedQuestData() + "\n";
        }

        return data;
    }

}


[System.Serializable]
public class AcceptedQuestData
{
    public int QuestID;
    public string QuestTitle;
    public string QuestContents;
    public string QuestContents2;
    public string? QuestReward;
    public int QuestGiver;
    public int QuestReceiver;
    public string? QuestNote;

    public string PrintAcceptedQuestData()
    {
        string data = //"Quest ID: " + QuestID + "\n" +
             
                      "<color=yellow>" + QuestTitle + "</color>" + "\n" +
                      "" + QuestContents2 + "\n";
                      //"Quest Reward: " + QuestReward + "\n" +
                      //"Quest Giver: " + QuestGiver + "\n" +
                      //"Quest Receiver: " + QuestReceiver + "\n" +
                      //"Quest Note: " + QuestNote + "\n" +
        return data;
    }
}

[System.Serializable]
public class QuestDataWrapper
{
    public QuestData[] QuestList;
}

[System.Serializable]
public class QuestData
{
    public int QuestID;
    public string QuestTitle;
    public string QuestContents;
    public string QuestContents2;
    public string? QuestReward;
    public int QuestGiver;
    public int QuestReceiver;
    public string? QuestNote;
}
