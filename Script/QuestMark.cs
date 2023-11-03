using System.Collections.Generic;
using UnityEngine;

public class QuestMark : MonoBehaviour
{
    public Save save;
    public bool doMark;
    public Camera cam;
    public int index;  
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        if(save.endLoad) CheckThis();
    }
    private GameObject targetChildObject;
    private GameObject targetChildObject2;

    void CheckThis()
    {
        // Debug.Log("Mark index" + index);
        JsonQuestLoader questLoader = FindObjectOfType<JsonQuestLoader>();
        List<QuestData> allQuestsData = questLoader.allQuestsData;
        int QI = allQuestsData[index].QuestID; 
        int QG = allQuestsData[index].QuestGiver; 

        
        GameObject[] npcObjects = GameObject.FindGameObjectsWithTag("QuestNPC");
                
        foreach (GameObject npcObject in npcObjects)
        {
            NpcIdGiver npcIdGiver = npcObject.GetComponent<NpcIdGiver>();
            if (npcIdGiver != null && npcIdGiver.Id == QG) //어떤 npc에 ui를띄울건지
            {
                int npcId = npcIdGiver.Id;

                if (QuestManager.Instance.QuestAcceptNumber == QI)
                {                   
                    for (int i = 0; i < npcIdGiver.transform.childCount; i++)
                    {
                        Debug.Log("in");
                        GameObject childObject = npcIdGiver.transform.GetChild(i).gameObject;
                        GameObject childObject2 = npcIdGiver.transform.GetChild(i).gameObject;
                        if (!childObject.activeSelf && childObject.name == "Canvas1")
                        {
                            childObject.SetActive(true);
                            targetChildObject = childObject;
                            doMark = true;
                            // break;
                        }
                        if (!childObject2.activeSelf && childObject2.name == "Canvas2")
                        {   // childObject2.SetActive(true);
                            targetChildObject2 = childObject2;
                            // break;
                            doMark = true;
                        }
                    }
                }               
            }
        }       
        index++;
    }
    public void CloseAcceptMark() 
    {
        targetChildObject.SetActive(false);
    }
    public void CloseClearMark() 
    {
        targetChildObject2.SetActive(false);
    }
    public void OpenClearMark()
    {
        targetChildObject2.SetActive(true);
    }
    public void CallCheckThis()
    {
        Debug.Log("second");
        CheckThis();
    }
    private void Update()
    {
        if(doMark)
        {
            Quaternion q_hp = Quaternion.LookRotation(targetChildObject.gameObject.transform.position - cam.transform.position);
            Vector3 hp_angle = Quaternion.RotateTowards(targetChildObject.gameObject.transform.rotation, q_hp, 200).eulerAngles;
            targetChildObject.gameObject.transform.rotation = Quaternion.Euler(0, hp_angle.y, 0);

            Quaternion q_hp2 = Quaternion.LookRotation(targetChildObject2.gameObject.transform.position - cam.transform.position);
            Vector3 hp_angle2 = Quaternion.RotateTowards(targetChildObject2.gameObject.transform.rotation, q_hp, 200).eulerAngles;
            targetChildObject2.gameObject.transform.rotation = Quaternion.Euler(0, hp_angle.y, 0);
        }
    }
}
