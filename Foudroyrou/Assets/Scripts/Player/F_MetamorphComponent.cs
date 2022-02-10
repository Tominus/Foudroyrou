using System;
using UnityEngine;

public class F_MetamorphComponent : MonoBehaviour
{
    public event Action<Transform> OnMetamorph = null;

    [SerializeField] Transform humanBody = null, meshSocket = null, wereWolfBodyPrefab = null;

    public bool IsValid => humanBody && meshSocket && wereWolfBodyPrefab;

    private void Start()
    {
        MetaMorph();
    }
    private void OnDestroy()
    {
        OnMetamorph = null;
    }

    public void MetaMorph()
    {
        if (!IsValid) return;
        Destroy(humanBody.gameObject);
        Transform _wereWolf = Instantiate(wereWolfBodyPrefab, meshSocket);
        if (!_wereWolf) return;
        OnMetamorph?.Invoke(_wereWolf);
    }
}