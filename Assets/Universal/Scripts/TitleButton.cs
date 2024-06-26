using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    public Sprite mySplashImage;
    public Image splashImage;

    public void OnMouseEnter()
    {
        splashImage.sprite = mySplashImage;
        splashImage.enabled = true;
    }

    public void OnMouseExit()
    {
        splashImage.enabled = false;
    }
}
