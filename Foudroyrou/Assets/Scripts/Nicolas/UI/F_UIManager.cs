using UnityEngine;
using System;

public class F_UIManager : F_Singleton<F_UIManager>
{
    #region Fields&Properties

    [SerializeField, Header("UI")] F_RageUI rageUI = null;
    [SerializeField] F_AmmoUI ammoUI = null;
    [SerializeField] F_TimeUI timeUI = null;
    public bool IsValid => rageUI && ammoUI && timeUI;

    public F_RageUI RageUI => rageUI;
    public F_AmmoUI AmmoUI => ammoUI;
    public F_TimeUI TimeUI => timeUI;

    #endregion

    #region Methods

    #endregion
}
