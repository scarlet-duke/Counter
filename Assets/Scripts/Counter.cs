using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _count = 0;
    private bool _isRunning = false;
    private Coroutine _countCoroutine;
    private readonly WaitForSeconds _waitTime = new WaitForSeconds(0.5f);
    public event Action<int> UpdateCounter;
    [SerializeField] private InputHandler inputHandler;

    private void OnEnable()
    {
        inputHandler.OnCounterToggle += ToggleCounter;
    }

    private void OnDisable()
    {
        inputHandler.OnCounterToggle -= ToggleCounter;
    }

    private void ToggleCounter()
    {
        if (_isRunning)
        {
            StopCounter();
        }
        else
        {
            StartCounter();
        }
    }

    private void StartCounter()
    {
        _isRunning = true;
        _countCoroutine = StartCoroutine(CountRoutine());
    }

    private void StopCounter()
    {
        _isRunning = false;
        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
        }
    }

    IEnumerator CountRoutine()
    {
        while (_isRunning)
        {
            yield return _waitTime;
            _count++;
            UpdateCounter?.Invoke(_count);
        }
    }
}
