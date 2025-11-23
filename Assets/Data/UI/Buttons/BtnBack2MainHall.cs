using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnBack2MainHall : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("MainHall");
    }
}
