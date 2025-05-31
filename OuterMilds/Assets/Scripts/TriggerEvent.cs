using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    [SerializeField] private string triggerTag = "Trash";
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;

    public bool IsColiding = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(triggerTag))
            return;

        IsColiding = true;
        OnEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(triggerTag))
            return;

        IsColiding = false;
        OnExit?.Invoke();

    }
}
