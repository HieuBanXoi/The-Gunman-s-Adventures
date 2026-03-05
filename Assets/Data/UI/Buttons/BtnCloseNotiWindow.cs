using UnityEngine;

public class BtnCloseNotiWindow : BaseButton
{
    protected override void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
