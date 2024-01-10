using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darwin : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void OnEnable()
    {

    }


    protected virtual void Reset()
    {
        this.LoadComponent();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {

    }

    protected virtual void LoadComponent()
    {

    }
}
