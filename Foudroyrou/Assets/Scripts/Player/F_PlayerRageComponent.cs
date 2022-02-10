using System;
using UnityEngine;

public class F_PlayerRageComponent : MonoBehaviour
{
    public event Action OnMaxRage = null;
    public event Action<float> OnRagePercent = null;

    [SerializeField] bool bGrowRage = false;
    [SerializeField] float fRageAmount = 0, fRageMax = 100, fPassifRageGrow = 0.1f;

    private void Update()
    {
        UpdateRage();
    }
    private void OnDestroy()
    {
        OnMaxRage = null;
        OnRagePercent = null;
    }

    void UpdateRage()
    {
        if (!bGrowRage) return;
        AddRage(fPassifRageGrow * Time.deltaTime);
    }

    public void AddRage(float _amount = 1)
    {
        fRageAmount += _amount;
        fRageAmount = fRageAmount > fRageMax ? fRageMax : fRageAmount < 0 ? 0 : fRageAmount;

        OnRagePercent?.Invoke(fRageAmount / fRageMax);

        if (fRageAmount == fRageMax)
        {
            OnMaxRage?.Invoke();
        }
    }
    public void RemoveRage(float _amount = 1)
    {
        fRageAmount -= _amount;
        fRageAmount = fRageAmount > fRageMax ? fRageMax : fRageAmount < 0 ? 0 : fRageAmount;

        OnRagePercent?.Invoke(fRageAmount / fRageMax);

        if (fRageAmount == fRageMax)
        {
            OnMaxRage?.Invoke();
        }
    }
    public void SetGrowRage(bool _state)
    {
        bGrowRage = _state;
    }
    //onnight -> grow rage
}