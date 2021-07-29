using System.Collections;
using Dist.ScriptableObjects.UIItems;
using TMPro;
using UnityEngine;

public class FlickUI : MonoBehaviour
{
    public TMP_Text text;

    public void OnNewFlick(FlickASO flick)
    {
        UiFlickSO uiFlick = (UiFlickSO) flick;
        StopCoroutine(Timeout());
        text.SetText(uiFlick.pattern);
        StartCoroutine(Timeout());
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(1);
        text.SetText("");
    }
}
