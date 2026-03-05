using Unity.VisualScripting;
using UnityEngine;

public class ShootByMouse : GunShooting
{  
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
