using System.Collections;
using Demo.Scripts.Skateboard;
using Flicker;
using TMPro;
using UnityEngine;

public class SkateboardFlickUI : MonoBehaviour
{
    [SerializeField] TMP_Text trickName;
    [SerializeField] TMP_Text stanceText;
    [SerializeField] SkateboardStateSO skateboardStateSO;

    readonly WaitForSeconds _timeout = new WaitForSeconds(20);

    void Awake()
    {
        skateboardStateSO.OnStanceChanged += ChangeStanceUI;
        stanceText.SetText(skateboardStateSO.stance.ToString());
    }

    void ChangeStanceUI(Stance stance)
    {
        stanceText.SetText(stance.ToString());
    }

    public void OnNewFlick(Flick flick)
    {
        TrickFlickSO trickFlickFlick = (TrickFlickSO) flick;
        StopAllCoroutines();
        ClearUI();
        trickName.SetText(trickFlickFlick.TrickName(skateboardStateSO.stance));
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
