using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _updateCounter;

    private void OnEnable()
    {
        _updateCounter.UpdateCounter += UpdateCounterDisplay;
    }

    private void OnDisable()
    {
        _updateCounter.UpdateCounter -= UpdateCounterDisplay;
    }
    private void UpdateCounterDisplay(int _count)
    {
        Debug.Log("Count: " + _count);
    }
}
