using System.Collections.Generic;
using UnityEngine;

public class F_StreetLampManager : F_Singleton<F_StreetLampManager>
{
    [SerializeField] List<F_StreetLamp> allStreetLamp = new List<F_StreetLamp>();

    public List<F_StreetLamp> AllStreetLamp => allStreetLamp;

    public void AddStreetLamp(F_StreetLamp _lamp)
    {
        allStreetLamp.Add(_lamp);
    }
    public void RemoveStreetLamp(F_StreetLamp _lamp)
    {
        allStreetLamp.Remove(_lamp);
    }
}