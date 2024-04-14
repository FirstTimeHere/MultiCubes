using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action Clicked;

    private void OnMouseDown()
    {
        Clicked?.Invoke();
    }
}
