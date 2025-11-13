using UnityEngine;

public class WallCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Obstacle.ToString();
    }
}
