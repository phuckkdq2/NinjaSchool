using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName ="SO/Map")]
public class MapSO : ScriptableObject
{
    public List<EnemyCtrl> enemies;
}


