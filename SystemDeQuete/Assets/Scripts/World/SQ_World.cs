using UnityEngine;

public class SQ_World : SQ_Singleton<SQ_World>
{
    [SerializeField] SQ_Player player = null;

    public bool IsValid => player;
    public SQ_Player Player => player;
}