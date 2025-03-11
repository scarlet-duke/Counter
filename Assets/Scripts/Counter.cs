using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _count = 0;
    private bool _isRunning = false;
    private Coroutine _countCoroutine;
    private readonly WaitForSeconds _waitTime = new WaitForSeconds(0.5f);

    private void OnEnable()
    {
        InputHandler.OnCounterToggle += _toggleCounter;
    }

    private void OnDisable()
    {
        InputHandler.OnCounterToggle -= _toggleCounter;
    }

    private void _toggleCounter()
    {
        if (_isRunning)
        {
            _stopCounter();
        }
        else
        {
            _startCounter();
        }
    }

    private void _startCounter()
    {
        _isRunning = true;
        _countCoroutine = StartCoroutine(CountRoutine());
    }

    private void _stopCounter()
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
            _updateCounterDisplay();
        }
    }

    private void _updateCounterDisplay()
    {
        Debug.Log("Count: " + _count);
    }
}
