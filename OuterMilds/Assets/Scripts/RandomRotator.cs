using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private void Start()
    {
        float rnd = Random.Range(0f, 1f);
        transform.rotation = new Quaternion(0, 0, rnd, 0);
    }
}
