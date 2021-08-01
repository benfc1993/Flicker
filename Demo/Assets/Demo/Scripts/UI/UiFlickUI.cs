using System.Collections;
using Flicker;
using TMPro;
using UnityEngine;

public class UiFlickUI : MonoBehaviour
{
    [SerializeField] TMP_Text pattern;

    readonly WaitForSeconds _timeout = new WaitForSeconds(20);

    public void CustomFlickListener(FlickData flickData)
    {
        StopAllCoroutines();
        ClearUI();
        pattern.SetText(flickData.Pattern);

        StartCoroutine(Timeout());
    }

    void ClearUI()
    {
        pattern.SetText("");
    }

    IEnumerator Timeout()
    {
        yield return _timeout;
        ClearUI();
    }
}
