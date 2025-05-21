using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DragDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float dragSpeed;
    private Vector3 mousePos;

    [SerializeField] private UnityEvent OnDrag;
    [SerializeField] private UnityEvent OnDragEnd;

    private void Start() => rb = GetComponent<Rigidbody2D>();
    private void OnMouseDown() => OnDrag?.Invoke();
    private void OnMouseUp() => OnDragEnd?.Invoke();

    private void OnMouseDrag()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = Vector3.Lerp(rb.position, mousePos, dragSpeed * Time.fixedDeltaTime);

        rb.MovePosition(Dir);
    }


}
