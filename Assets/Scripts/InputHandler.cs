using UnityEngine;
using System;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private int _keyMouseButton;
    public event Action OnCounterToggle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_keyMouseButton)) 
        {
            OnCounterToggle?.Invoke();
        }
    }
}