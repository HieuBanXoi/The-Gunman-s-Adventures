using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FollowTarget", story: "[Follow] [Target]", category: "Action", id: "96f4188589c28eb5fca8fef3bf6f4f56")]
public partial class FollowTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<FollowTarget> Follow;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

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

