using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Set State", story: "Set [CurrentState] to [State]", category: "Action", id: "b24f2883ad4237645aa44bfe5ec8d197")]
public partial class SetStateAction : Action
{
    [SerializeReference] public BlackboardVariable<CurrentState> CurrentState;
    [SerializeReference] public BlackboardVariable<CurrentState> State;

    protected override Status OnStart()
    {
        CurrentState.Value = State.Value;
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

