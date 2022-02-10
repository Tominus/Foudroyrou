using UnityEngine;
using System;

public abstract class F_CameraBehaviour : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField] protected F_CameraSettings settings = new F_CameraSettings();

    public bool IsValid => settings.IsValid;


    #endregion

    #region Methods

    virtual protected void LateUpdate()
    {
        MoveTo(settings.TargetOffset);
        RotateTo(settings.TargetView);
    }

    protected abstract void MoveTo(Vector3 _position);
    protected abstract void RotateTo(Vector3 _position);

    #endregion
}
