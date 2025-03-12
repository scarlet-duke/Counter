using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    public event Action OnCounterToggle;
    [SerializeField] private int _keyMouseButton;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_keyMouseButton)) 
        {
            OnCounterToggle?.Invoke();
        }
    }
}