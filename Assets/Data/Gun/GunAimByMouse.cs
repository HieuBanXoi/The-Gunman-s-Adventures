using UnityEngine;

public class GunAimByMouse : GunAim
{
    protected override void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}
