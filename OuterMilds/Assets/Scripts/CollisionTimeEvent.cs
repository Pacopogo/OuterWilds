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
    private float oldTime;

    [Header("Components")]
    [SerializeField] private Slider timeSlider;

    private bool isCounting = false;

    [SerializeField] private UnityEvent OnFinish;

    private void Start()
    {
        current = maxTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag))
            return;

        isCounting = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(playerTag))
            return;

        isCounting = false;
    }

    private void FixedUpdate()
    {
        oldTime = current;

        if (isCounting)
        {
            current -= Time.fixedDeltaTime;

            if (current < 0)
            {
                OnFinish?.Invoke();
                isCounting = false;
                return;
            }
        }
        else
        {
            if (current < maxTimer)
                current += Time.fixedDeltaTime;

        }

        UiUpdate();
    }

    private void UiUpdate()
    {
        if (!timeSlider)
            return;


        if (current == oldTime)
        {
            timeSlider.gameObject.SetActive(false);
            return;
        }

        timeSlider.gameObject.SetActive(true);


        timeSlider.maxValue = maxTimer;
        timeSlider.value = current;
    }
}
