using UnityEngine;

public class RunFromMouse : MonoBehaviour
{
    [SerializeField] private bool isAfraid;
    private Rigidbody2D rb;


    [SerializeField] private float runSpeed = 0.5f;
    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 GetDirection()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = Vector3.Lerp(rb.position, mousePos, runSpeed * Time.fixedDeltaTime);

        return dir;
    }

    private void FixedUpdate()
    {
        if (!isAfraid)
            return;

        rb.MovePosition(GetDirection());
    }
}
