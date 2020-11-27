using UnityEngine;
using UnityEngine.UI;

public class ShowHide : MonoBehaviour
{
    public RawImage image;

    public void CanHide()
    {
        image.enabled = true;
    }

    public void CantHide()
    {
        image.enabled = false;
    }

}
