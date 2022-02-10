using UnityEngine;

public class F_World : F_Singleton<F_World>
{
    F_Player player = null;
    public F_Player GetFirstPlayer => player;

    /// <summary>
    /// Add the player to the manager
    /// </summary>
    /// <param name="_player">the player to add</param>
    /// <returns>true if succeed false otherwise</returns>
    public bool AddPlayer(F_Player _player)
    {
        if (player)
            return false;
        player = _player;
        return true;
    }
}
