using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class JsonQuestLoader : MonoBehaviour
{
    private NpcIdGiver npcIdGiver;
    public GameObject questUI;
    public QuestManager questManager;
    // JSON ?�일 경로
    // public string filePath = "Assets/Resources/JP_QuestList.json";
    public string filePath = "JP_QuestList";
    public MessageController messageController_Quest;
    public List<AcceptedQuestData> acceptedQuestsData;
    public List<QuestData> allQuestsData; // ?�로??리스??추�?

    // QuestID?� QuestGiver 값을 ?�?�할 변??
    private int questID;
    private int questGiver;
    private int questReceiver;



    private void Start()
    {
        int questAcceptNumber = QuestManager.Instance.QuestAcceptNumber;
        acceptedQuestsData = new List<AcceptedQuestData>();

        npcIdGiver = GetComponent<NpcIdGiver>();

        allQuestsData = new List<QuestData>(); // ?�로??리스??초기??
        // JSON ?�일 ?�기
        string jsonData = LoadJsonFile();
        if (!string.IsNullOrEmpty(jsonData))
        {
            QuestDataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);

            if (dataWrapper != null && dataWrapper.QuestList != null)
            {
                foreach (QuestData quest in dataWrapper.QuestList)
                {
                    // 모든 ?�스???�이?��? allQuestsData 리스?�에 ?�??
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
        // JSON ?�일 ?�기
        string jsonData = LoadJsonFile();

        // ?�이??변??�?출력
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

    public void AcceptQuest(int npcId, int myQuestAcceptNumber) // npcgiver.id 값이 ?�어???�재 ?��? ?�락가?�한 ?�스??Id(?�스?�창?�용)가 ?�어??
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

                    // ?�락???�스???�이?��? ?�??                    \
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
            // ���ҽ� �ε�
            TextAsset textAsset = Resources.Load<TextAsset>("JP_QuestList");

            if (textAsset != null)
            {
                // �ؽ�Ʈ ������ ��������
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
            // ?�일 존재 ?��? ?�인
            if (File.Exists(filePath))
            {
                // ?�일 ?�기
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
            // JSON ?�이?��? QuestDataWrapper 객체�?변??
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
                          "<color=yellow>" + "[����Ʈ]: "+ "</color>" + quest.QuestTitle + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + quest.QuestContents + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + quest.QuestReward + "\n" +
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
        // JSON ?�일 ?�기
        string jsonData = LoadJsonFile();
        // ?�이??변??
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
