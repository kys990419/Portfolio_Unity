using UnityEngine;
using System.Collections.Generic;

public class NpcIdGiver : MonoBehaviour
{
    public int Id;
    public bool CheckQuest;

    private static List<NpcIdGiver> npcIdGivers = new List<NpcIdGiver>();

    private void Awake()
    {
        npcIdGivers.Add(this);
    }

    public void SetCheckQuest(bool value)
    {
        CheckQuest = value;
    }

    public static NpcIdGiver FindNpcIdGiver(int npcId)
    {
        return npcIdGivers.Find(npc => npc.Id == npcId);
    }
}
