using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RunFromMouse : MonoBehaviour
{
    [SerializeField] private bool isAfraid;
    private Rigidbody2D rb;


    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float runRadius = 1.0f;
    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!isAfraid || CheckDistance() == false)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
          
        rb.linearVelocity = GetDirection().normalized * runSpeed;
    }
    private Vector2 GetDirection()
    {
        Vector2 dir = (Vector2)(transform.position - mousePos).normalized;

        return dir;
    }

    private bool CheckDistance()
    {
        float distance = Vector2.Distance(transform.position, mousePos);

        bool isClose = distance > runRadius ? false : true;
        
        return isClose;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, runRadius);
    }
}
