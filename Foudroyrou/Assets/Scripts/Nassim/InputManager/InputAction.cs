using UnityEngine;
using System;

[System.Serializable]
public class InputAction : Input<bool>
{

    [SerializeField] KeyCode keyCode = KeyCode.None;
    [SerializeField] KeyType keyType = KeyType.KeyDown;
    [SerializeField] ActionType actionType = ActionType.NONE;
    public ActionType ActionType => actionType;
    bool GetKeyType(KeyType _keyType)
    {
        switch (_keyType)
        {
            case KeyType.KeyUp:
                return Input.GetKeyUp(keyCode);
            case KeyType.KeyDown:
                return Input.GetKeyDown(keyCode);
            case KeyType.KeyPressed:
                return Input.GetKey(keyCode);
        }
        return false;
    }
    public override bool InputValue => GetKeyType(keyType);
}

public enum ActionType
{
    NONE,
    JUMP,
    DASH,
}

public enum KeyType
{
    KeyUp,
    KeyDown,
    KeyPressed,
}
