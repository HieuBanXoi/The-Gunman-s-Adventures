using UnityEngine;

public abstract class AbilityObjectCtrl : CoreMonoBehaviour
{
    [Header("Ability Object Ctrl")]
    [SerializeField] protected PlayerCtrl PlayerCtrl;
    public PlayerCtrl playerCtrl { get => PlayerCtrl; }

}
