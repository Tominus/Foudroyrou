using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

using System;

public class F_RageUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Image rageBar = null;

    [SerializeField] Volume volume = null;
    Bloom bloom = null;

    public bool IsValid => rageBar;

    public bool IsValidHDRP => volume;

    #endregion

    #region Methods

    private void Start() => InitRageUI();

    void InitRageUI()
    {
        if (!IsValidHDRP)
            return;
        VolumeProfile _profile = volume.sharedProfile;
        _profile.TryGet<Bloom>(out bloom);            
    }

    public void UpdateRageBar(float _amount)
    {
        if (!IsValid) return;
        rageBar.fillAmount = _amount;

        if (!IsValidHDRP) return;
        bloom.intensity.value = _amount;
    }

    #endregion
}
