using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public static event Action OnCounterToggle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnCounterToggle?.Invoke();
        }
    }
}