using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestClearList : MonoBehaviour
{
    public GameObject GoldBox;
    public GameObject Gold2Box;
    public GameObject Gold3Box;
    public Enemy enemy;
    public int curQuest;
    public int maxCount;
    public int curCount;
    public Text ProgressTxt;
    public Text CountTxt;
    public bool clearQ;

    public bool Q1Clear;
    public bool Q2Clear;
    public bool Q3Clear;
    public bool Q4Clear;
    public bool Q5Clear;
    public bool Q6Clear;
    public bool Q7Clear;
    public bool Q8Clear;
    public bool Q9Clear;
    public bool Q10Clear;
    public bool Q11Clear;
    public bool Q12Clear;
    public bool Q13Clear;
    public bool Q14Clear;
    public bool Q15Clear;
    public bool Q16Clear;
    public bool Q17Clear;
    public bool Q18Clear;
    public bool Q19Clear;
    public bool Q20Clear;
    public bool Q21Clear;
    public bool Q22Clear;
    public bool Q23Clear;
    public bool Q24Clear;
    public bool Q25Clear;
    public bool Q26Clear;
    public bool Q27Clear;
    public bool Q28Clear;
    public bool Q29Clear;
    public bool Q30Clear;
    public bool Q31Clear;
    public bool Q32Clear;
    public bool Q33Clear;
    public bool Q34Clear;
    public bool Q35Clear;
    public bool Q36Clear;
    public bool Q37Clear;
    public PlayerMove playerMove;
    public Inventory inventory;
    // ?¨ìˆ˜ë¥??€?¥í•  ë°°ì—´
    private Action[] functionArray;

    private void Awake()
    {
        functionArray = new Action[]
        {
            Function1,
            Function2,
            Function3,
            Function4,
            Function5,
            Function6,
            Function7,
            Function8,
            Function9,
            Function10,
            Function11,
            Function12,
            Function13,
            Function14,
            Function15,
            Function16,
            Function17,
            Function18,
            Function19,
            Function20,
            Function21,
            Function22,
            Function23,
            Function24,
            Function25,
            Function26,
            Function27,
            Function28,
            Function29,
            Function30,
            Function31,
            Function32,
            Function33,
            Function33,
            Function34,
            Function35,
            Function36,
            Function37,
        };
    }
    private void Update()
    {
        if(curQuest == 1) Function1();
        else if(curQuest == 2) Function2();
        else if(curQuest == 3) Function3();
        else if (curQuest == 4) Function4();
        else if (curQuest == 5) Function5();
        else if (curQuest == 6) Function6();
        else if (curQuest == 7) Function7();
        else if (curQuest == 8) Function8();
        else if (curQuest == 9) Function9();
        else if (curQuest == 10) Function10();
        else if (curQuest == 11) Function11();
        else if (curQuest == 12) Function12();
        else if (curQuest == 13) Function13();
        else if (curQuest == 14) Function14();
        else if (curQuest == 15) Function15();
        else if (curQuest == 16) Function16();
        else if (curQuest == 17) Function17();
        else if (curQuest == 18) Function18();
        else if (curQuest == 19) Function19();
        else if (curQuest == 20) Function20();
        else if (curQuest == 21) Function21();
        else if (curQuest == 22) Function22();
        else if (curQuest == 23) Function23();
        else if (curQuest == 24) Function24();
        else if (curQuest == 25) Function25();
        else if (curQuest == 26) Function26();
        else if (curQuest == 27) Function27();
        else if (curQuest == 28) Function28();
        else if (curQuest == 29) Function29();
        else if (curQuest == 30) Function30();
        else if (curQuest == 31) Function31();
        else if (curQuest == 32) Function32();
        else if (curQuest == 33) Function33();
        else if (curQuest == 34) Function34();
        else if (curQuest == 35) Function35();
        else if (curQuest == 36) Function36();
        else if (curQuest == 37) Function37();
    }
    private void Function1()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Åä¸¶Åä")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 5;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Åä¸¶Åä" && inventory.slots[i].itemCount >= 5)
                {
                    Q1Clear = true;
                }
            }
        }

        if (Q1Clear)
        {   
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if(questClearImage != null)
            {
                if(QuestManager.Instance.QuestAcceptNumber == 1)
                {
                    questClearImage.OpenClearMark();
                }
            }
        }
    }
    private void Function2()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 2) Q2Clear = true;
        if (Q2Clear)  
        {
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function3()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 3) Q3Clear = true;
        if (Q3Clear)
        {
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function4()
    {
        maxCount = 5;
        curCount = playerMove.MonsterKill;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;


        if (curCount >= 5) Q4Clear = true;

        if (Q4Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function5()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 5) Q5Clear = true;

        if (Q5Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }

    private void Function6()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° ±Ã¼ö Àü¸®ÅÛ")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 10;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° ±Ã¼ö Àü¸®ÅÛ" && inventory.slots[i].itemCount >= 10)
                {
                    Q6Clear = true;
                }
            }
        }

        if (Q6Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }

    private void Function7()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.onGreen) Q7Clear = true;

        if (Q7Clear)
        {   
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }

    private void Function8()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.onGold) Q8Clear = true;

        if (Q8Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function9()
    {
        playerMove.curBoss = 0;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° Çàµ¿´ëÀåÀÇ Ã´Ãß")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° Çàµ¿´ëÀåÀÇ Ã´Ãß" && inventory.slots[i].itemCount >= 1)
                {
                    Q9Clear = true;
                }
            }
        }

        if (Q9Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }

    private void Function10()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 10) Q10Clear = true;

        if (Q10Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }

    private void Function11()
    {
        playerMove.curBoss = 1;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° ¿ÕÀÇ µÎ°ñ")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°íºí¸° ¿ÕÀÇ µÎ°ñ" && inventory.slots[i].itemCount >= 1)
                {
                    Q11Clear = true;
                }
            }
        }

        if (Q11Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function12()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 12) Q12Clear = true;

        if (Q12Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function13()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 13) Q13Clear = true;

        if (Q13Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function14()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 14) Q14Clear = true;

        if (Q14Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function15()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 15) Q15Clear = true;

        if (Q15Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function16()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "½Åºñ·Î¿î¾à")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "½Åºñ·Î¿î¾à" && inventory.slots[i].itemCount >= 1)
                {
                    Q16Clear = true;
                }
            }
        }

        if (Q16Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function17()
    {
        maxCount = 10;
        curCount = playerMove.MonsterKill;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;


        if (curCount >= 10) Q17Clear = true;

        if (Q17Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function18()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ÇØ°ñ±Ã¼öÀÇ »Ô")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 10;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ÇØ°ñ±Ã¼öÀÇ »Ô" && inventory.slots[i].itemCount >= 10)
                {
                    Q18Clear = true;
                }
            }
        }

        if (Q18Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function19()
    {
        playerMove.curBoss = 2;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ÇØ°ñ ±â»çÀÇ °¥ºñ»À")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ÇØ°ñ ±â»çÀÇ °¥ºñ»À" && inventory.slots[i].itemCount >= 1)
                {
                    Q19Clear = true;
                }
            }
        }

        if (Q19Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function20()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.onCanon) Q20Clear = true;

        if (Q20Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function21()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ºÒ·ÎÃÊ")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "ºÒ·ÎÃÊ" && inventory.slots[i].itemCount >= 1)
                {
                    Q21Clear = true;
                }
            }
        }

        if (Q21Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function22()
    {
        playerMove.curBoss = 3;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "¾Ï¼®°ÅÀÎÀÇ ÆÄÆí")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "¾Ï¼®°ÅÀÎÀÇ ÆÄÆí" && inventory.slots[i].itemCount >= 1)
                {
                    Q22Clear = true;
                }
            }
        }

        if (Q22Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function23()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 23) Q23Clear = true;

        if (Q23Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function24()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 24) Q24Clear = true;

        if (Q24Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function25()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 25) Q25Clear = true;

        if (Q25Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function26()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 26) Q26Clear = true;

        if (Q26Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function27()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 27) Q27Clear = true;

        if (Q27Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function28()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 28) Q28Clear = true;

        if (Q28Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function29()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.Gang) Q29Clear = true;

        if (Q29Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function30()
    {
        maxCount = 10;
        curCount = playerMove.MonsterKill;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;


        if (curCount >= 10) Q30Clear = true;

        if (Q30Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function31()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°ËÀº¸Á·ÉÀÇ Àü¸®Ç°")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 10;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "°ËÀº¸Á·ÉÀÇ Àü¸®Ç°" && inventory.slots[i].itemCount >= 10)
                {
                    Q31Clear = true;
                }
            }
        }

        if (Q31Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function32()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.Zun) Q32Clear = true;

        if (Q32Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function33()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (playerMove.Hal) Q33Clear = true;

        if (Q33Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function34()
    {
        playerMove.curBoss = 4;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "µÚÆ²¸° ÁÖ¼ú»çÀÇ ¸ñ°ÉÀÌ")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "µÚÆ²¸° ÁÖ¼ú»çÀÇ ¸ñ°ÉÀÌ" && inventory.slots[i].itemCount >= 1)
                {
                    Q34Clear = true;
                }
            }
        }

        if (Q34Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function35()
    {
        playerMove.curBoss = 5;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "µÚÆ²¸° »ç½ÅÀÇ ¸ð·¡½Ã°è")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "µÚÆ²¸° »ç½ÅÀÇ ¸ð·¡½Ã°è" && inventory.slots[i].itemCount >= 1)
                {
                    Q35Clear = true;
                }
            }
        }

        if (Q35Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function36()
    {
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = "";

        if (curQuest == 36) Q36Clear = true;

        if (Q36Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
    private void Function37()
    {
        playerMove.curBoss = 6;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Áö¿Á ¼ö¹®ÀåÀÇ Àü¸®Ç° Ã¥")
                {
                    curCount = inventory.slots[i].itemCount;
                }
            }
        }
        maxCount = 1;
        ProgressTxt.text = "[ ÁøÇàÁß ]";
        CountTxt.text = curCount + " / " + maxCount;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Áö¿Á ¼ö¹®ÀåÀÇ Àü¸®Ç° Ã¥" && inventory.slots[i].itemCount >= 1)
                {
                    Q37Clear = true;
                }
            }
        }

        if (Q37Clear)
        {
            ProgressTxt.text = "<color=green>" + "[ ¿Ï·á ]" + "</color>";
            clearQ = true;
            QuestMark questClearImage = FindObjectOfType<QuestMark>();
            if (questClearImage != null)
            {
                Debug.Log("? Mark is create");
                questClearImage.OpenClearMark();
            }
            Debug.Log("Second Quest Clear Can!");
        }
    }
   
    public void CallFunction(int index)
    {
        if (index >= 0 && index < functionArray.Length)
        {
            //functionArray[index-1]?.Invoke();
            Debug.Log(index);
            if (index == 1) curQuest = 1;
            else if (index == 2) curQuest = 2;
            else if (index == 3) curQuest = 3;
            else if (index == 4) curQuest = 4;
            else if (index == 5) curQuest = 5;
            else if (index == 6) curQuest = 6;
            else if (index == 7) curQuest = 7;
            else if (index == 8)
            {
                GoldBox.gameObject.SetActive(true);
                Gold2Box.gameObject.SetActive(true);
                Gold3Box.gameObject.SetActive(true);
                curQuest = 8;
            }
            else if (index == 9) curQuest = 9;
            else if (index == 10) curQuest = 10;
            else if (index == 11) curQuest = 11;
            else if (index == 12) curQuest = 12;
            else if (index == 13) curQuest = 13;
            else if (index == 14) curQuest = 14;
            else if (index == 15) curQuest = 15;
            else if (index == 16) curQuest = 16;
            else if (index == 17) curQuest = 17;
            else if (index == 18) curQuest = 18;
            else if (index == 19) curQuest = 19;
            else if (index == 20) curQuest = 20;
            else if (index == 21) curQuest = 21;
            else if (index == 22) curQuest = 22;
            else if (index == 23) curQuest = 23;
            else if (index == 24) curQuest = 24;
            else if (index == 25) curQuest = 25;
            else if (index == 26) curQuest = 26;
            else if (index == 27) curQuest = 27;
            else if (index == 28) curQuest = 28;
            else if (index == 29)
            {
                playerMove.Gang = false;
                curQuest = 29;
            }
            else if (index == 30) curQuest = 30;
            else if (index == 31) curQuest = 31;
            else if (index == 32)
            {
                playerMove.Zun = false;
                curQuest = 32;
            }
            else if (index == 33)
            {
                playerMove.Hal = false;
                curQuest = 33;
            }
            else if (index == 34) curQuest = 34;
            else if (index == 35) curQuest = 35;
            else if (index == 36) curQuest = 36;
            else if (index == 37) curQuest = 37;
        }
    }
}
