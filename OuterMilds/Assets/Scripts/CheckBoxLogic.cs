using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerEvent))]
public class CheckBoxLogic : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private TriggerEvent triggerEvent;

    [SerializeField] private UnityEvent OnTrigger;
    [SerializeField] private UnityEvent OnMissed;


    private void Start()
    {
        triggerEvent = GetComponent<TriggerEvent>();
        MoveRandomPosition();
    }
    public void MoveRandomPosition()
    {
        int rnd = Random.Range(0, points.Length);

        transform.position = points[rnd].position;
    }

    public void CheckTriggered()
    {
        if (triggerEvent.IsColiding)
        {
            OnTrigger?.Invoke();
        }
        else
        {
            OnMissed?.Invoke();
        }
    }
}
