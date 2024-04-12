using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithObject : MonoBehaviour
{
    public event Action ClickedObject;

    private void OnMouseDown()
    {
        ClickedObject?.Invoke();
    }
}
