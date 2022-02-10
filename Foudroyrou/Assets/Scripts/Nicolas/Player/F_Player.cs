using UnityEngine;
using System;

[RequireComponent(typeof(F_PlayerMovement))]
public class F_Player : MonoBehaviour
{
    #region Fields&Properties

    [SerializeField, Header("Components")] F_PlayerMovement movement = null;

    public bool IsValid => movement;

    #endregion

    #region Methods

    private void Start() => InitPlayer();
    void InitPlayer()
    {
        movement = GetComponent<F_PlayerMovement>();

        if (!IsValid) return;

        movement.InitMovement();
    }

    #endregion
}
