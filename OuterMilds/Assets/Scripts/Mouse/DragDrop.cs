using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class DragDrop : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float dragSpeed;
    private Vector3 mousePos;
    private bool canDrag = false;

    [SerializeField] private UnityEvent OnDrag;
    [SerializeField] private UnityEvent OnDragEnd;

    private void Start() => rb = GetComponent<Rigidbody2D>();
    private void OnMouseDown()
    {
        OnDrag?.Invoke();
        canDrag = true;
    }
    private void OnMouseUp()
    {
        if (!canDrag)
            return;

        OnDragEnd?.Invoke();
    }

    private void OnMouseDrag()
    {
        if (!canDrag)
            return;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Dir = Vector3.Lerp(rb.position, mousePos, dragSpeed * Time.fixedDeltaTime);

        rb.MovePosition(Dir);
    }

    public void ForceStopDrag()
    {
        canDrag = false;
        OnDragEnd?.Invoke();
    }
}
