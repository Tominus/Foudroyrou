using UnityEngine;

[System.Serializable]
public class InputAxis : Input<float>
{
    #pragma warning disable 414
    [SerializeField] private int indexAxis = 0;
    #pragma warning restore 414
    [SerializeField] string axisName = "Axis";
    public string AxisName => axisName;
    [SerializeField] AxisType axisType = AxisType.NONE;
    public AxisType AxisType => axisType;
    public override float InputValue => Input.GetAxis(axisName);
}
[System.Serializable]
public enum AxisType
{
    NONE,
    HORIZONTAL_AXIS,
    VERTICAL_AXIS,
    MOUSEX,
    MOUSEY,
}