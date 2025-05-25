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

    public void ToggleMoving(bool check) => isMoving = check;

    public void StartPoint() => target = points[0];

    private void Start()
    {
        StartPoint();
    }

    private void FixedUpdate()
    {

        if(animator != null)
            animator.SetBool("IsMoving", isMoving);

        if (!isMoving)
            return;

        MovePawn();
    }

    private void nextPoint()
    {
        pointIndex++;

        if (pointIndex > points.Length)
            pointIndex = 0;

        target = points[pointIndex];

        OnNextPoint?.Invoke();
    }

    private void MovePawn()
    {
        Vector3 direction = -(transform.position - target.position);


        transform.Translate(direction.normalized * speed * Time.fixedDeltaTime);

        Debug.Log(direction.magnitude);

        if(direction.magnitude <= 0.1f)
            nextPoint();
    }
}
