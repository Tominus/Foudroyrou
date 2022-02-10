using System.Collections.Generic;
using UnityEngine;

public class F_NPCManager : F_Singleton<F_NPCManager>, IManager<string, F_NPC>
{
    [SerializeField] Transform target = null;
    Transform currentTarget = null;
    public Dictionary<string, F_NPC> items = new Dictionary<string, F_NPC>();
    public Dictionary<string, F_NPC> Items => items;

    private void Start()
    {
        //F_DayManager.Instance.OnNight += TransformAllNPC;
        //F_DayManager.Instance.OnNight += () => currentTarget = target;
    }
    void Update()
    {
        foreach (KeyValuePair<string,F_NPC> item in items)
            item.Value.MakeAction(currentTarget);
    }
    void TransformAllNPC()
    {
        foreach (KeyValuePair<string, F_NPC> item in items)
            //items.Value.MetamorphComponent.Metamorph();
            ;
    }

    public void Add(F_NPC _item)
    {
        if (Exist(_item.ID)) return;
        items.Add(_item.ID, _item);
    }

    public void Remove(F_NPC _item)
    {
        if (!Exist(_item)) return;
        items.Remove(_item.ID);
    }

    public void Remove(string _id)
    {
        if (!Exist(_id)) return;
        items.Remove(_id);
    }

    public void Enable(F_NPC _item)
    {
        if (!Exist(_item)) return;
        _item.Enable();
    }

    public void Enable(string _id)
    {
        if (!Exist(_id)) return;
        Get(_id).Enable();
    }

    public void Disable(F_NPC _item)
    {
        if (!Exist(_item)) return;
        _item.Disable();
    }

    public void Disable(string _id)
    {
        if (!Exist(_id)) return;
        Get(_id).Disable();
    }

    public F_NPC Get(string _id)
    {
        if (!Exist(_id)) 
            return null;
        return items[_id];
    }

    public bool Exist(string _id) => items.ContainsKey(_id);

    public bool Exist(F_NPC _item) => items.ContainsValue(_item);
}
