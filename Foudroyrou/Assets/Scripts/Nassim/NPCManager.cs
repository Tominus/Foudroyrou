using System.Collections.Generic;
using UnityEngine;

public class NPCManager : F_Singleton<NPCManager>
{
    [SerializeField] List<NPC> items = new List<NPC>();
    [SerializeField] Transform target = null;
    Transform currentTarget = null;
    private void Start()
    {
        //On Start 
        //DayManager.Instance.OnNightFall += () => currentTarget = target;
    }
    void Update()
    {
        int _count = items.Count;
        for (int i = 0; i < _count; i++)
            items[i].MakeAction(currentTarget);
    }
}
