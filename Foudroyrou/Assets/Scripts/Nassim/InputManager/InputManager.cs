using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class InputManager : F_Singleton<InputManager>
{
    event Action OnUpdate = null;
    [SerializeField] List<InputAction> actions = new List<InputAction>();
    [SerializeField] List<InputAxis> axis = new List<InputAxis>();
    public List<InputAction> AllAction => actions;
    public List<InputAxis> AllAxis => axis;
    private void Update() => OnUpdate?.Invoke();
    public void BindAction(ActionType _actionType,Action<bool> _actionCall)
    {
        List<InputAction> _actions = actions.Where(_action => _action.ActionType == _actionType).ToList();
        _actions.ForEach(_action => { _action.Bind(_actionCall); OnUpdate += _action.Execute; });
    }
    public void BindAxis(AxisType _axisType,Action<float> _actionCall)
    {
        List<InputAxis> _axis = axis.Where(_Axis => _Axis.AxisType == _axisType).ToList();
        _axis.ForEach(_Axis => { _Axis.Bind(_actionCall); OnUpdate += _Axis.Execute; });
    }
    public void BindAxis(string _axisName, Action<float> _actionCall)
    {
        List<InputAxis> _axis = axis.Where(_Axis => string.Equals(_Axis.AxisName, _axisName)).ToList();
        _axis.ForEach(_Axis => { _Axis.Bind(_actionCall); OnUpdate += _Axis.Execute; });
    }
    public void UnbindAction(ActionType _actionType, Action<bool> _actionCall)
    {
        List<InputAction> _actions = actions.Where(_action => _action.ActionType == _actionType).ToList();
        _actions.ForEach(_action => { _action.Unbind(_actionCall); });
    }
    public void UnbindAxis(AxisType _axisType, Action<float> _actionCall)
    {
        List<InputAxis> _axis = axis.Where(_Axis => _Axis.AxisType == _axisType).ToList();
        _axis.ForEach(_Axis => { _Axis.Unbind(_actionCall); });
    }
    public void UnbindAxis(string _axisType, Action<float> _actionCall)
    {
        List<InputAxis> _axis = axis.Where(_Axis => string.Equals(_Axis.AxisName, _axisType)).ToList();
        _axis.ForEach(_Axis => { _Axis.Unbind(_actionCall); });
    }
    public void UnbindAllAction(ActionType _actionType, Action<bool> _actionCall)
    {
        List<InputAction> _actions = actions.Where(_action => _action.ActionType == _actionType).ToList();
        _actions.ForEach(_action => { _action.UnbindAll(); });
    }
    public void UnbindAllAxis(AxisType _axisType, Action<float> _actionCall)
    {
        List<InputAxis> _axis = axis.Where(_Axis => _Axis.AxisType == _axisType).ToList();
        _axis.ForEach(_Axis => { _Axis.UnbindAll(); });
    }
}
