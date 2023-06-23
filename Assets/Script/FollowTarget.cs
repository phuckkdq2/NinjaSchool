using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : Darwin
{
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if(this.mainCamera != null) return;
        this.mainCamera = GetComponent<Camera>();
    }

}
