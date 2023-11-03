using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBtnClick : MonoBehaviour
{
    public StatInven statInven;
    public int num;
    public void getBtn()
    {
        statInven.updateStat(num);
    }
}
