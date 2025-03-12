using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter updateCounter;
    private void OnEnable()
    {
        updateCounter.UpdateCounter += UpdateCounterDisplay;
    }
    private void UpdateCounterDisplay(int _count)
    {
        Debug.Log("Count: " + _count);
    }
}
