using System;

[System.Serializable]
public abstract class Input<T>
{
    public abstract T InputValue { get; }
    protected Action<T> Callback = null;
    public void Execute() => Callback?.Invoke(InputValue);
    public void Bind(Action<T> _callback) => Callback += _callback;
    public void Unbind(Action<T> _callback) => Callback -= _callback;
    public void UnbindAll() => Callback = null;
}
