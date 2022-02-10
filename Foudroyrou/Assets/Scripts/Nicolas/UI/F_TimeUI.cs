using UnityEngine;
using TMPro;
using System;

public class F_TimeUI : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] TextMeshProUGUI timeUI = null;

    public bool IsValid => timeUI;

    #endregion

    #region Methods

    public void UpdateTimeText(string _time)
    {
        if (!IsValid) return;
        timeUI.text = _time;
    }

    #endregion
}
