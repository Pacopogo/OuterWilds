using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    [SerializeField] private string triggerTag = "Trash";
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(triggerTag))
            return;

        OnEnter?.Invoke();
        Debug.Log("Enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(triggerTag))
            return;

        OnExit?.Invoke();
        Debug.Log("Exit");
    }
}
