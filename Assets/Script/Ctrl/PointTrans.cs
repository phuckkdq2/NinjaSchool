using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTrans : MonoBehaviour
{
    [SerializeField] public Intersection intersection;
    [SerializeField] public Transform PlayerPoint;
}

public enum Intersection    // nút giao giữa các cổng của map 
{
    SchoolVsHachi,
    SchooolVsYamato,
    HachiVsSakura
}
