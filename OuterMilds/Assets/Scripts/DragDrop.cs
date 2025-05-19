using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DragDrop : MonoBehaviour
{
    [SerializeField] private float dragSpeed;
    private Vector3 mousePos;

    [SerializeField] private UnityEvent OnDrag;
    [SerializeField] private UnityEvent OnDragEnd;

    private void OnMouseDown() => OnDrag?.Invoke();
    private void OnMouseUp() => OnDragEnd?.Invoke();

    private void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = Vector3.Lerp(transform.position, mousePos, dragSpeed * Time.fixedDeltaTime);

        transform.position = Dir;
    }


}
