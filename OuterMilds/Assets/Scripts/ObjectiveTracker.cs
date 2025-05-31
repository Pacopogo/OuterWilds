using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ObjectiveTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    
    [SerializeField] private UnityEvent OnFinish;

    [SerializeField] private int goal;
    [SerializeField] private int current;

    private void Start()
    {
        UpdateDisplay();
    }

    public void AddToCurrent()
    {
        if (current == goal)
            return;

        current++;

        UpdateDisplay();

        if (current == goal)
            OnFinish?.Invoke();
    }

    public void RemoveFromCurrent()
    {
        if (current < 0)
        {
            current = 0;
            return;
        }

        current--;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (displayText == null)
            return;

        displayText.text = current.ToString() + "/" + goal.ToString();
    }
}
