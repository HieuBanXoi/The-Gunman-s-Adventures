using UnityEngine;

public class BtnOpenNotiWindow : BaseButton
{
    [SerializeField] private GameObject notiWindow;
    protected override void OnClick()
    {
        notiWindow.SetActive(true);
    }
}
