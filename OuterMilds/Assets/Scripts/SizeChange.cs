using UnityEngine;

public class SizeChange : MonoBehaviour
{
    [SerializeField] private Transform trans;
    public void SetScale(float scale) => trans.localScale = new Vector3(scale, scale, scale);

}
