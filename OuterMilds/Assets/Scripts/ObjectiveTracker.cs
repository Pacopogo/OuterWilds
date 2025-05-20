using UnityEngine;
using UnityEngine.Events;

public class ObjectiveTracker : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFinish;

    [SerializeField] private int goal;
    [SerializeField] private int current;

    public void AddToCurrent()
    {
        current++;

        if (current == goal)
            OnFinish?.Invoke();
    }

    public void RemoveFromCurrent() => current--;
}
