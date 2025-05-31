using UnityEngine;

public class PhysicsFling : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public void FlingUP(float force) => rb.AddForce(Vector2.up *  force);
    
}
