using UnityEngine;

[RequireComponent(typeof(F_StreetLampAnimation), typeof(F_StreetLampBehaviour))]
public class F_StreetLamp : MonoBehaviour
{
    [SerializeField] F_StreetLampAnimation anim = null;
    [SerializeField] F_StreetLampBehaviour behaviour = null;

    public bool IsValid => anim && behaviour;
    public F_StreetLampAnimation Anim => anim;
    public F_StreetLampBehaviour Behaviour => behaviour;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        anim = GetComponent<F_StreetLampAnimation>();
        behaviour = GetComponent<F_StreetLampBehaviour>();

        if (!IsValid) return;

        F_StreetLampManager.Instance.AddStreetLamp(this);

        behaviour.OnAnimLightStart += anim.SetLightOnParam;
    }
}