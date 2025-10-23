using UnityEngine;

public class BtnInventoryClose : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
