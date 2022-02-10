using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public event Action OnDeath = null;
    float hp = 0;
    [SerializeField] float hpMax = 100;
    [SerializeField] float rangeAttack = 0.5f;
    [SerializeField] float rangeAgro = 10;
    private void Start() => hp = hpMax;
    void Init()
    {

    }
    public void MakeAction(Transform _target)
    {
        if (!_target) return;
        float _distance = Vector3.Distance(_target.position,transform.position);
        if (_distance < rangeAgro)
           //MoveTo Target
            ;
        if (_distance <= rangeAttack)
            //Damage Target
            ;
    }
    public void TakeDamage(float _damage)
    {
        hp -= _damage;
        if(hp <= 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
