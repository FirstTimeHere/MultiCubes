using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action Click;

    private void OnMouseDown()
    {
        Click?.Invoke();
    }
}
