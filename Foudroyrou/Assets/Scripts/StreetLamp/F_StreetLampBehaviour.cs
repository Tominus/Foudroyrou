using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class F_StreetLampBehaviour : MonoBehaviour
{
    public event Action<bool> OnAnimLightStart = null;
    public event Action OnLampActivated = null, OnLampDesactivated = null, OnLampDetectPlayer = null;

    [SerializeField] Transform detectionSocket = null;
    [SerializeField] bool bIsActivated = false;
    [SerializeField] float fAnimOnTime = 1,
                           fAnimOffTime = 1,
                           fMinRandomCooldown = 5,
                           fMaxRandomCooldown = 100,
                           fRageCureAmount = 0.1f,
                           fCurrentCooldown = 0;
    [SerializeField, Range(0.01f, 5)] float fDetectionRate = 1;
    [SerializeField, Range(0.01f, 5)] float fDetectionRadius = 1;
    [SerializeField] LayerMask playerLayer = 0;

    F_PlayerRageComponent currentRageComponent = null;

    public bool IsValid => detectionSocket;

    private void Start()
    {
        InitAbo();
    }
    private void OnDestroy()
    {
        OnAnimLightStart = null;
        OnLampActivated = null;
        OnLampDesactivated = null;
        OnLampDetectPlayer = null;
    }
    private void OnDrawGizmos()
    {
        if (!IsValid) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionSocket.position, fDetectionRadius);
    }

    void InitAbo()
    {
        OnAnimLightStart += (state) => bIsActivated = state;
        Invoke(nameof(StartLampAnimOn), 0.1f);
        InvokeRepeating(nameof(Detection), Random.Range(0.0f, 1.0f), fDetectionRate);
        
        /*
         F_World.Instance.DayManager.OnNight += StartLampAnimOn;
         */
        //TODO ABO OnNight 
    }

    void Detection()
    {
        if (!IsValid) return;
        Collider[] _colliders = Physics.OverlapSphere(detectionSocket.position, fDetectionRadius, playerLayer);
        
        int _max = _colliders.Length;
        if (_max < 1 || !bIsActivated)
        {
            if (!currentRageComponent) return;
            currentRageComponent.SetGrowRage(true);
            currentRageComponent = null;
            return;
        }

        for (int i = 0; i < _max; i++)
        {
            F_PlayerRageComponent _rageCompo = _colliders[i].GetComponent<F_PlayerRageComponent>();
            if (!_rageCompo) continue;
            OnLampDetectPlayer?.Invoke();
            currentRageComponent = _rageCompo;

            currentRageComponent.RemoveRage(fRageCureAmount);
            currentRageComponent.SetGrowRage(false);
            //TODO REMOVE RAGE;
        }
    }

    void StartLampAnimOn()
    {
        OnAnimLightStart?.Invoke(true);
        Invoke(nameof(ActivateLamp), fAnimOnTime);
    }
    void ActivateLamp()
    {
        OnLampActivated?.Invoke();
        Invoke(nameof(StartLampAnimOff), GetRandomTime());
    }

    void StartLampAnimOff()
    {
        OnAnimLightStart?.Invoke(false);
        Invoke(nameof(DesactivateLamp), fAnimOffTime);
    }
    void DesactivateLamp()
    {
        OnLampDesactivated?.Invoke();
        Invoke(nameof(StartLampAnimOn), GetRandomTime());
    }

    float GetRandomTime()
    {
        return fCurrentCooldown = Random.Range(fMinRandomCooldown, fMaxRandomCooldown);
    }
}