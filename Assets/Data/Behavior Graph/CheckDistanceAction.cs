using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Check distance", story: "Check distance between [Self] and [Target] and save it to [DistanceToTarget]", category: "Action", id: "98a07812603a2a2cde553c585c08241e")]
public partial class CheckDistanceAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> DistanceToTarget;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        DistanceToTarget.Value = Vector3.Distance(Self.Value.transform.position, Target.Value.transform.position);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

