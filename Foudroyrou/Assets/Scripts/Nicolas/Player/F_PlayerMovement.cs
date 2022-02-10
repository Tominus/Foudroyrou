using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class F_PlayerMovement : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Components")] CharacterController controller = null;

    [SerializeField, Header("Settings"), Range(1, 100)] float moveSpeed = 50;
    [SerializeField, Range(1, 300)] float rotateSpeed = 150;

    public bool IsValid => controller;

    #endregion

    #region Methods

    public void InitMovement()
    {
        controller = GetComponent<CharacterController>();
        if (!IsValid) return;

        InputManager.Instance.BindAxis(AxisType.HORIZONTAL_AXIS, HorizontalMovement);
        InputManager.Instance.BindAxis(AxisType.VERTICAL_AXIS, VerticalMovement);
        InputManager.Instance.BindAxis(AxisType.YAW_AXIS, YawRotation);
    }

    void HorizontalMovement(float _axis)
    {
        if (!IsValid) return;
        controller.Move(transform.right * _axis * moveSpeed * Time.deltaTime);
    }
    void VerticalMovement(float _axis)
    {
        if (!IsValid) return;
        controller.Move(transform.forward * _axis * moveSpeed * Time.deltaTime);
    }
    void YawRotation(float _axis)
    {
        transform.RotateAround(transform.position, Vector3.up, _axis * rotateSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1.5f);
    }

    #endregion
}
