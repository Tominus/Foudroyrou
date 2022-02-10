using UnityEngine;
using TMPro;
using System;

public class F_AmmoUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] TextMeshProUGUI ammoUI = null;

    public bool IsValid => ammoUI;

    #endregion

    #region Methods

    public void UpdateAmmoText(int _currentAmmo, int _maxAmmo)
    {
        if (!IsValid) return;
        ammoUI.text = $"{_currentAmmo} / {_maxAmmo}";
    }

    #endregion
}
