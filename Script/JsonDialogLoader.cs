using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class JsonDialogLoader : MonoBehaviour
{
    public CollisionDetector collisionDetector;
    public QuestClearList questClearList;

    public string filePath = "Assets/Resources/JP_Dialog.json";
    public MessageController messageController_Dialog;
    public string npcIdGiverTag = "QuestNPC"; 
    private NpcIdGiver[] npcIdGivers; 

    private void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas object is not found!");
            return;
        }
        GameObject dialogUI = canvas.transform.Find("DialogUI").gameObject;
        if (dialogUI == null)
        {
            Debug.LogError("DialogUI object is not found!");
            return;
        }

        GameObject dialoGUI = canvas.transform.Find("DialogUI").gameObject;
        messageController_Dialog = dialogUI.GetComponent<MessageController>();
        if (messageController_Dialog == null)
        {
            Debug.LogError("MessageController component is not found on the DialogUI object!");
            return;
        }

        dialogUI.SetActive(false);

        AssignNpcIdGivers();
    }

    private void AssignNpcIdGivers()
    {
        GameObject[] npcIdGiverObjects = GameObject.FindGameObjectsWithTag(npcIdGiverTag);
        npcIdGivers = new NpcIdGiver[npcIdGiverObjects.Length];

        for (int i = 0; i < npcIdGiverObjects.Length; i++)
        {
            npcIdGivers[i] = npcIdGiverObjects[i].GetComponent<NpcIdGiver>();
        }
    }

    public void HandleNpcCollision(int npcId)
    {
       
        string jsonData = LoadJsonFile();
       
        if (!string.IsNullOrEmpty(jsonData))
        {
            DataWrapper dataWrapper = ConvertJsonToDataWrapper(jsonData);


            if(dataWrapper.Dialogues == null)
            {
                Debug.Log("2");
            }
            if (dataWrapper != null && dataWrapper.Dialogues != null)
            {
                FindAndPrintDialogue(dataWrapper.Dialogues, npcId);
            }
            else
            {
                Debug.LogError("Failed to convert JSON to Dialogues.");
            }
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }
    }

   
    private string LoadJsonFile()
    {
        string jsonData = null;

        try
        {
           
            if (File.Exists(filePath))
            {
                
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

        // Debug.Log(jsonData);

        return jsonData;
    }
    private DataWrapper ConvertJsonToDataWrapper(string json)
    {
        DataWrapper dataWrapper = null;

        try
        {
           
            dataWrapper = JsonUtility.FromJson<DataWrapper>(json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to convert JSON to Dialogues: " + ex.Message);
        }

        return dataWrapper;
    }

    private void FindAndPrintDialogue(Data[] Dialogues, int npcId)
    {
        
        string dialogue = null;

        foreach (Data data in Dialogues)
        {
            if (data.CharactersID == npcId)
            {
                if (!CheckQuestStatus(npcId))
                {

                    dialogue = data.Dialogue;

                  
                }
                else if(questClearList.clearQ)
                {
                    dialogue = data.Note2;
                }
                /*
                else if(collisionDetector.isNPCQ == 1)
                {
                    dialogue = data.Note3;
                    collisionDetector.isNPCQ = 0;
                }
                */
                else // false
                {
                    dialogue = data.Note;
                }
                break;
            }
        }

        if (dialogue != null)
        {
            messageController_Dialog.UpdateMessage(dialogue);
        }
        else
        {
            messageController_Dialog.UpdateMessage("No matching dialogue found for Npc ID: " + npcId);
        }
    }
    private bool CheckQuestStatus(int npcId)
    {
        foreach (NpcIdGiver npcIdGiver in npcIdGivers)
        {
            if (npcIdGiver != null && npcIdGiver.Id == npcId && npcIdGiver.CheckQuest == true)
            {
                return npcIdGiver.CheckQuest; //TRUE
            }
        }
        return false;
    }
}

// ?∞Ïù¥???òÌçº ?¥Îûò??
[System.Serializable]
public class DataWrapper
{
    public Data[] Dialogues;
}

// ?∞Ïù¥???¥Îûò??
[System.Serializable]
public class Data
{
    public int? DialogID;
    public int? QuestID;
    public int CharactersID;
    public string Dialogue;
    public string Note;
    public string Note2;
    public string Note3;
}
