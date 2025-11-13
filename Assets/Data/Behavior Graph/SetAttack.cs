using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "New Action", story: "Set [IsAttack] to [True]", category: "Action", id: "a7090a401ee11f7f2cde4e1074d0068a")]
public partial class SetAttack : Action
{
    [SerializeReference] public BlackboardVariable<bool> IsAttack;
    [SerializeReference] public BlackboardVariable<bool> True;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

