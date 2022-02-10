using System;
using UnityEngine;

public class F_NPC : MonoBehaviour,IManagedItem<string>
{
    public event Action OnDeath = null;
    float hp = 0;
    [SerializeField] float hpMax = 100;
    [SerializeField] float rangeAttack = 0.5f;
    [SerializeField] float rangeAgro = 10;

    string id = "NPC";
    public string ID => id;
    public bool IsValid => true;

    F_MetamorphComponent metamorphComponent = null;
    public F_MetamorphComponent MetamorphComponent => metamorphComponent;
    private void Start() => InitItem();
    private void OnDestroy() => DestroyItem();
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
    public void InitItem()
    {
        hp = hpMax;
        F_NPCManager.Instance?.Add(this);
        metamorphComponent = GetComponent<F_MetamorphComponent>();
    }
    public void DestroyItem() => F_NPCManager.Instance?.Remove(this);
    public void Enable()
    {
        
    }
    public void Disable()
    {
        
    }
    public void SetID(string _id) => id = _id;
}
