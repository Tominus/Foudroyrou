using UnityEngine;

public class F_Gun : MonoBehaviour
{
    float shootTime = 0;
    bool shootLoad = true;
    [SerializeField] float shootCooldown = 1;
    [SerializeField] float damageDeal = 10;
    [SerializeField] float range = 10;
    [SerializeField] LayerMask hitLayer = 0;
    void Update()
    {
        CooldownReset();
        Shoot();
    }
    void CooldownReset()
    {
        if (shootLoad) return;
        shootTime += Time.deltaTime;
        if(shootTime > shootCooldown)
        {
            shootLoad = true;
            shootTime = 0;
        }
    }
    public void Shoot()
    {
        if (!shootLoad) return;
        shootLoad = false;
        bool _hit = Physics.Raycast(transform.position,transform.forward,out RaycastHit _hitRay, range, hitLayer);
        Debug.DrawRay(transform.position, transform.forward * range,_hit ? Color.red : Color.green,0.2f);
        if (!_hit) return;
        F_NPC _npc = _hitRay.collider.GetComponent<F_NPC>();
        _npc?.TakeDamage(damageDeal);
    }
}
