using System;
using UnityEngine;

public class F_NPC : MonoBehaviour,IManagedItem<string>
{
    public event Action OnDeath = null;
    float hp = 0;
    F_NPCMovement movement = null;
    F_MetamorphComponent metamorphComponent = null;
    [SerializeField] float hpMax = 100;
    [SerializeField] float rageGive = 1;
    [SerializeField] float rangeAttack = 0.5f;
    [SerializeField] float rangeAgro = 10;

    [SerializeField] string id = "NPC";
    public string ID => id;
    public F_MetamorphComponent MetamorphComponent => metamorphComponent;
    public bool IsValid => movement && metamorphComponent;

    private void Start() => InitItem();
    private void OnDestroy() => DestroyItem();
    public void MakeAction(F_Player _target)
    {
        if (!_target) return;
        float _distance = Vector3.Distance(_target.transform.position,transform.position);
        if (_distance <= rangeAgro)
            movement.Movement(_target.transform);
        if (_distance <= rangeAttack)
            _target.PlayerRageComponent.AddRage(rageGive * Time.deltaTime);
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
        movement = GetComponent<F_NPCMovement>();
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
