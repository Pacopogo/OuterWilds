using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool isMoving = false;

    [Header("Settings")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float sprintSpeed = 6f;

    [Header("Component")]
    [SerializeField] private Animator animator;

    private Vector2 playerDirection;

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        transform.Translate(Vector3.up * playerDirection.y * walkSpeed * Time.fixedDeltaTime);
        transform.Translate(Vector3.right * playerDirection.x * walkSpeed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        isMoving = context.performed;
        animator.SetBool("IsMoving", isMoving);

        if (!context.performed) 
            return;

        playerDirection = context.ReadValue<Vector2>();
    }
}
