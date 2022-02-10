using UnityEngine;

public class F_NPCMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    public void Movement(Transform _target)
    {
        Vector3 _dir = (_target.position - transform.position).normalized;
        transform.position += _dir * moveSpeed * Time.deltaTime;
    }
}
