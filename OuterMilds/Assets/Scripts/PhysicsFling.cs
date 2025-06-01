using UnityEngine;

public class PhysicsFling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
 
    [SerializeField] private float strenght;
    [SerializeField] private bool isFlinging = false;
    public void IsFling(bool fling) => isFlinging = fling;
    public void FlingUP(float force) => rb.AddForce(Vector2.up *  force);


    private void FixedUpdate()
    {
        if (!isFlinging)
            return;

        rb.AddForce(Vector2.up * strenght);
    }
}
