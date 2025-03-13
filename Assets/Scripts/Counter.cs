using System.Collections;
using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    private int _count = 0;
    private bool _isRunning = false;
    private Coroutine _countCoroutine;
    private readonly WaitForSeconds _waitTime = new WaitForSeconds(0.5f);
    public event Action<int> UpdateCounter;

    private void OnEnable()
    {
        _inputHandler.OnCounterToggle += ToggleCounter;
    }

    private void OnDisable()
    {
        _inputHandler.OnCounterToggle -= ToggleCounter;
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

    private IEnumerator CountRoutine()
    {
        while (_isRunning)
        {
            yield return _waitTime;
            _count++;
            UpdateCounter?.Invoke(_count);
        }
    }
}