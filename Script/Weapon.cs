using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type {Melee, Magic, GoblinMelee, GoblinGirl, Boss1Weapon, Boss2Skill2};
    public Type type;
    public int damage;
}
