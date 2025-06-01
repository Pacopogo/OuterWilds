using UnityEngine;

using UnityEngine.Events;
public class MouseHover : MonoBehaviour
{

    [SerializeField] private UnityEvent OnClick;
    [SerializeField] private UnityEvent OnRelease;
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;


    private void OnMouseEnter() => OnEnter?.Invoke();
    private void OnMouseUp() => OnRelease?.Invoke();    
    private void OnMouseExit() => OnExit?.Invoke();
    private void OnMouseDown() => OnClick?.Invoke();

}
