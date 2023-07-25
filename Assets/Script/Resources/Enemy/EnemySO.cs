using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName ="ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
   public string enemyName = "Enemy";
   public float hpMax = 2;
}