using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider2D))]
public class Bench : MonoBehaviour
{
    [SerializeField] private CinemachineCamera camera;

    [SerializeField] private GameObject playerObj;
    [SerializeField] private GameObject targetObj;

    private bool isToggle = false;

    [SerializeField] private UnityEvent OnEnable;
    [SerializeField] private UnityEvent OnDisable;

    private void OnMouseDown() => WhenToggle();

    private void WhenToggle()
    {
        isToggle = !isToggle;

        playerObj.SetActive(!isToggle);

        if (isToggle)
        {
            camera.Follow = targetObj.transform;
            OnEnable?.Invoke();
        }
        else
        {
            camera.Follow = playerObj.transform;
            OnDisable?.Invoke();
        }
    }


}
