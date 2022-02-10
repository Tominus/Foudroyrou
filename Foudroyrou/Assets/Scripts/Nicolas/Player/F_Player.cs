using UnityEngine;

[RequireComponent(typeof(F_PlayerMovement), typeof(F_PlayerRageComponent))]
public class F_Player : MonoBehaviour
{
    #region Fields&Properties
    F_PlayerMovement movement = null;
    F_PlayerRageComponent rage = null;
    [SerializeField, Header("Components")] F_Gun gun = null;
    public bool IsValid => movement && rage && gun;
    #endregion
    #region Methods
    private void Start() => InitPlayer();
    void InitPlayer()
    {
        Cursor.lockState = CursorLockMode.Locked;
        movement = GetComponent<F_PlayerMovement>();
        rage = GetComponent<F_PlayerRageComponent>();
        if (!IsValid) return;
        InputManager.Instance?.BindAction(ActionType.SHOOT, (shoot) => { if (shoot) gun.Shoot(); });
        movement.InitMovement();
    }
    #endregion
}
