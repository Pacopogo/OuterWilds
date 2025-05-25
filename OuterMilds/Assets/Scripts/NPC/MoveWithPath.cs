using UnityEngine;
using UnityEngine.Events;


public class MoveWithPath : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    private Transform target;
    private int pointIndex;

    [SerializeField] private float speed = 3f;
    [SerializeField] private bool isMoving = true;

    [SerializeField] private Animator animator;

    [SerializeField] private UnityEvent OnNextPoint;

    public void ToggleMoving(bool check)
    {
        isMoving = check;

    }

    private void Start()
    {
        StartPoint();
    }

    public void StartPoint() => target = points[0];
    private void FixedUpdate()
    {

        if (animator != null)
            animator.SetBool("IsMoving", isMoving);

        if (!isMoving)
            return;

        MovePawn();
    }

    private void nextPoint()
    {
        pointIndex++;

        if (pointIndex > points.Length - 1)
            pointIndex = 0;

        target = points[pointIndex];

        OnNextPoint?.Invoke();
    }

    private void MovePawn()
    {
        if(points == null) 
            return;

        Vector3 direction = -(transform.position - target.position);


        transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);

        if (direction.magnitude <= 0.1f)
            nextPoint();
    }
}
