using UnityEngine;
using UnityEngine.UI;
using System;

public class F_RageUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] Image rageBar = null;

    public bool IsValid => rageBar;

    #endregion

    #region Methods

    public void UpdateRageBar(float _amount)
    {
        if (!IsValid) return;
        rageBar.fillAmount = _amount;
    }

    #endregion
}
