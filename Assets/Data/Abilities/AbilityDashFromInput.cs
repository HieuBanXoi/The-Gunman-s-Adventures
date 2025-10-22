using UnityEngine;

public class AbilityDashFromInput : AbilityDash
{
    protected override void Update()
    {
        base.Update();
        this.UpdateKeySpace();
    }
    protected virtual void UpdateKeySpace()
    {
        //if (!InputManager.Instance.OnSpaceDown) return;      
        //this.onSpace = true;

        onSpace = InputManager.Instance.OnSpaceDown;
    }
}
