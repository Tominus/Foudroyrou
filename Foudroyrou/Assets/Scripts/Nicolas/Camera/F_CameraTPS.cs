using UnityEngine;
using System;

public class F_CameraTPS : F_CameraBehaviour
{
    #region Fields&Properties



    #endregion

    #region Methods

    #endregion
    protected override void MoveTo(Vector3 _position)
    {
        transform.position = settings.SmoothMove ? Vector3.MoveTowards(transform.position, _position, Time.deltaTime * settings.MoveSpeed) : _position;
    }

    protected override void RotateTo(Vector3 _position)
    {
        Vector3 _dir = _position - transform.position;
        if (_dir == Vector3.zero) return;
        Quaternion _rotation = Quaternion.LookRotation(_dir);

        transform.rotation = settings.SmoothRotation ? Quaternion.RotateTowards(transform.rotation, _rotation, Time.deltaTime * settings.RotateSpeed) : _rotation;
    }

    private void OnDrawGizmosSelected()
    {
        if (!settings.IsValid) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(settings.Target.position, 1f);

        Gizmos.DrawSphere(settings.TargetOffset, .2f);
        Gizmos.DrawLine(settings.Target.position, settings.TargetOffset);

        Gizmos.DrawSphere(settings.TargetView, .1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, Vector3.one * .5f);
    }
}
