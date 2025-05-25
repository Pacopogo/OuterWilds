using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerRespawn : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject canvas;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Settings")]
    [SerializeField] private float maxTimer = 5f;
    private float currentTime;

    private bool isCounting;

    [Header("Events")]
    [SerializeField] private UnityEvent OnDestory;

    private void Start() => currentTime = maxTimer;

    public void ToggleCounting(bool check)
    {
        isCounting = check;
        canvas.SetActive(isCounting);
    }
    private void FixedUpdate()
    {
        if (!isCounting)
            return;

        currentTime -= Time.fixedDeltaTime;
        countText.text = currentTime.ToString("f0");

        CheckCountdown();
    }

    private void CheckCountdown()
    {
        if (currentTime >= 0.9f)
            return;

        int rnd = Random.Range(0, spawnPoints.Length);
        transform.position = spawnPoints[rnd].position;

        currentTime = maxTimer;

        OnDestory?.Invoke();

    }
}
