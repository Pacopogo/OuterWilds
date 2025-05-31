using UnityEngine;
using UnityEngine.Events;

//Made by: Pablo Pacopogo
public class CollisionTimeEvent : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float maxTimer = 3f;
    private float current;

    private bool isCounting;

    [SerializeField] private UnityEvent OnFinish;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag))
            return;

        isCounting = true;
        current = maxTimer;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag))
            return;

        isCounting = false;
    }

    private void FixedUpdate()
    {

        if (!isCounting)
            return;

        current -= Time.fixedDeltaTime;

        if (current < 0)
        {
            OnFinish?.Invoke();
            isCounting = false;
            return;
        }
    }
}
