using System.Collections;
using Flicker;
using TMPro;
using UnityEngine;

public class MagicFlickUI : MonoBehaviour
{
    [SerializeField] TMP_Text spellName;

    readonly WaitForSeconds _timeout = new WaitForSeconds(3);

    public void OnNewFlick(FlickSO flickSO)
    {
        SpellSO spellFlick = (SpellSO) flickSO;
        StopAllCoroutines();
        ClearUI();
        spellName.SetText(spellFlick.spellName);
        StartCoroutine(Timeout());
    }

    void ClearUI()
    {
        spellName.SetText("");
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
