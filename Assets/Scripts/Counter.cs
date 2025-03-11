using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int count = 0;
    private bool isRunning = false;
    private Coroutine countCoroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounter();
        }
    }

    void ToggleCounter()
    {
        if (isRunning)
        {
            StopCounter();
        }
        else
        {
            StartCounter();
        }
    }

    void StartCounter()
    {
        isRunning = true;
        countCoroutine = StartCoroutine(CountRoutine());
    }

    void StopCounter()
    {
        isRunning = false;
        if (countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
        }
    }

    IEnumerator CountRoutine()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(0.5f);
            count++;
            UpdateCounterDisplay();
        }
    }

    void UpdateCounterDisplay()
    {
        Debug.Log("Count: " + count);
    }
}
