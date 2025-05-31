using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Made by: Pablo Pacopogo
public class CollisionTimeEvent : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float maxTimer = 3f;
    [SerializeField] private float current;

    [Header("Components")]
    [SerializeField] private Slider timeSlider;

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
        UiUpdate();

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

    private void UiUpdate()
    {
        if (!timeSlider)
            return;

        timeSlider.gameObject.SetActive(isCounting);

        if (!isCounting)
            return;


        timeSlider.maxValue = maxTimer;
        timeSlider.value = current;
    }
}
