using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName ="SO/Enemy")]
public class EnemySO : ScriptableObject
{
   public string enemyName = "Enemy";
   public int hpMax = 2;
   public int dame = 1;
   public List<DropRate> dropList ;
}
