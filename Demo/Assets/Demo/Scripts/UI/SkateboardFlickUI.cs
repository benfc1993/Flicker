using System.Collections;
using Flicker;
using TMPro;
using UnityEngine;

public class SkateboardFlickUI : MonoBehaviour
{
    [SerializeField] TMP_Text trickName;

    readonly WaitForSeconds _timeout = new WaitForSeconds(20);

    public void OnNewFlick(Flick flick)
    {
        TrickSO trickFlick = (TrickSO) flick;
        StopAllCoroutines();
        ClearUI();
        trickName.SetText(trickFlick.trickName);
        StartCoroutine(Timeout());
    }

    void ClearUI()
    {
        trickName.SetText("");
    }

    IEnumerator Timeout()
    {
        yield return _timeout;
        ClearUI();
    }


    void OnEnable()
    {
        ClearUI();
    }
}
