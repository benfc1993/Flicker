using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFlickItem : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text text;

    public void Init(Sprite newIcon, string name)
    {
        icon.sprite = newIcon;
        text.SetText(name);
    }
}
