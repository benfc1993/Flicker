using System.Collections;
using Dist.ScriptableObjects.UIItems;
using Flicker;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlickUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Image image;

    WaitForSeconds timeout = new WaitForSeconds(20);

    public void CustomFlickListener(FlickData flickData)
    {
        StopAllCoroutines();
        ClearUI();
        text.SetText(flickData.Pattern);
        StartCoroutine(Timeout());
    }

    public void OnNewFlick(Flick flick)
    {
        UiFlickSO uiFlick = (UiFlickSO) flick;
        // StopAllCoroutines();
        // ClearUI();
        // text.SetText(uiFlick.flickDataSO.pattern);
        // StartCoroutine(Timeout());
        // image.sprite = uiFlick.icon;
        // image.color = Color.white;
        // StartCoroutine(Timeout());
    }

    void ClearUI()
    {
        text.SetText("");
        image.sprite = null;
        image.color = new Color(0, 0, 0, 0);
    }

    IEnumerator Timeout()
    {
        yield return timeout;
        ClearUI();
    }
}
