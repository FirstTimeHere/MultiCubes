using System;
using UnityEngine;

public class InteractionWithObject : MonoBehaviour
{
    public event Action ClickedObject;

    private void OnMouseDown()
    {
        ClickedObject?.Invoke();
    }
}
