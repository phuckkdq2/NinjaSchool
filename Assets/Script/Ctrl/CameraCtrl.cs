using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
