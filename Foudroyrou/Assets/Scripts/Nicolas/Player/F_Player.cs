using UnityEngine;
using System;

[RequireComponent(typeof(F_PlayerMovement), typeof(F_PlayerRageComponent))]
public class F_Player : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Components")] F_PlayerMovement movement = null;
    [SerializeField, Header("Components")] F_PlayerRageComponent rage = null;

    public bool IsValid => movement && rage;

    #endregion

    #region Methods

    private void Start() => InitPlayer();
    void InitPlayer()
    {
        movement = GetComponent<F_PlayerMovement>();
        rage = GetComponent<F_PlayerRageComponent>();

        if (!IsValid) return;

        movement.InitMovement();
    }

    #endregion
}
