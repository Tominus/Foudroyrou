using System;
using UnityEngine;

[Serializable]
public struct SQ_Quest
{
    [SerializeField] string title, description, reward, position;
    [SerializeField] Vector3 vPosition;

    public string Title => title;
    public string Description => description;
    public string Reward => reward;
    public Vector3 Position => vPosition;

    public void Init()
    {
        vPosition = JsonUtility.FromJson<Vector3>(position);
    }
}