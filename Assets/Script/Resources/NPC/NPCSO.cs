using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "SO/NPC")]
public class NPCSO : ScriptableObject
{
    public List<string> conversation ;
    public List<NPCFunction> nPCFunctions;
}

public enum NPCFunction
{
    talk,
    shop,
    misson,
}
