using UnityEngine;

[RequireComponent(typeof(Animator))]
public class F_StreetLampAnimation : MonoBehaviour
{
    [SerializeField] Animator anim = null;

    public bool IsValid => anim;
    public Animator Anim => anim;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void SetLightOnParam(bool _state)
    {
        anim.SetBool(F_StreetLampAnimationParam.LIGHT_ON_PARAM, _state);
    }
}