using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtnClick : MonoBehaviour
{
    public SetSkillInven setSkillInven;
    public int num;
    public void getBtn()
    {
        setSkillInven.updateSkill(num);
    }
}
