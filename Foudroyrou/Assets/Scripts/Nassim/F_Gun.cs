using UnityEngine;
using UnityEngine.VFX;

public class F_Gun : MonoBehaviour
{
    float shootTime = 0;
    bool shootLoad = true;
    int ammoAmount = 0;
    Transform targetAim = null;
    [SerializeField] VisualEffect visualEffectOnShoot = null;
    [SerializeField] float shootCooldown = 1;
    [SerializeField] float damageDeal = 10;
    [SerializeField] float range = 10;
    [SerializeField] int ammoAmountMax = 10;
    [SerializeField] LayerMask hitLayer = 0;
    private void Start()
    {
        ammoAmount = ammoAmountMax;
        F_UIManager.Instance?.AmmoUI.UpdateAmmoText(ammoAmount, ammoAmountMax);
    }
    void Update()
    {
        CooldownReset();
        if(targetAim)
            transform.forward = new Vector3(targetAim.forward.x,0, targetAim.forward.z);
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
        if (!shootLoad || ammoAmount <= 0) return;
        shootLoad = false;
        EffectOnShoot();
        RemoveAmmo();
        bool _hit = Physics.Raycast(transform.position,transform.forward,out RaycastHit _hitRay, range, hitLayer);
        Debug.DrawRay(transform.position, transform.forward * range,_hit ? Color.red : Color.green,0.2f);
        if (!_hit) return;
        F_NPC _npc = _hitRay.collider.GetComponent<F_NPC>();
        _npc?.TakeDamage(damageDeal);
    }
    void EffectOnShoot()
    {
        if (!visualEffectOnShoot) return;
        visualEffectOnShoot.SetVector3("End", transform.forward * range);
        VisualEffect _spawn = Instantiate(visualEffectOnShoot, transform.position, Quaternion.identity);
        Destroy(_spawn.gameObject, 0.1f);
    }
    void RemoveAmmo()
    {
        ammoAmount--;
        F_UIManager.Instance?.AmmoUI.UpdateAmmoText(ammoAmount, ammoAmountMax);
    }
    public void SetObjectTargetAim(Transform _targetAim)
    {
        targetAim = _targetAim;
        transform.forward = _targetAim.forward;
    }
}
