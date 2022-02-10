using UnityEngine;
using System;

[Serializable]
public class F_CameraSettings 
{
    [SerializeField] Transform target = null;

    [SerializeField, Header("Settings"), Range(0, 250)] float moveSpeed = 10;
    [SerializeField, Range(0, 500)] float rotateSpeed = 100;
    [SerializeField] bool smoothMove = true, smoothRotation = true, isLocal = true;

    [SerializeField, Header("Offset - Position"), Range(-20, 20)] float xOffet = 0;
    [SerializeField, Range(-20, 20)] float yOffet = 0, zOffset = 0;

    [SerializeField, Header("Offset - View"), Range(-10, 10)] float xView = 0;
    [SerializeField, Range(-10, 10)] float yView = 0, zView = 0;

    public bool IsValid => target;

    public Transform Target => target;

    public float MoveSpeed => moveSpeed;
    public float RotateSpeed => rotateSpeed;

    public bool SmoothMove => smoothMove;
    public bool SmoothRotation => smoothRotation;

    public Vector3 Offset => new Vector3(xOffet, yOffet, zOffset);
    public Vector3 View => new Vector3(xView, yView, zView);

    public Vector3 TargetOffset
    {
        get
        {
            if (!IsValid) return Vector3.zero;
            return target.position + (isLocal ? GetLocalOffset() : Offset);
        }
    }
    public Vector3 TargetView
    {
        get
        {
            if (!IsValid) return Vector3.zero;
            return target.position + target.forward * xView + target.right * zView + target.up * yView;
        }
    }

    Vector3 GetLocalOffset()
    {
        if (!target) return Vector3.zero;
        return target.forward * xOffet + target.right* zOffset + target.up * yOffet;
    }
}
