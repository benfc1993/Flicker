using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameStateSO _gameStateSO;
    CanvasGroup _canvasGroup;

    [SerializeField] CanvasGroup pauseCanvasGroup;
    [SerializeField] CanvasGroup infoCanvasGroup;
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ShowFlickInfo();
        _gameStateSO.onPausedChanged += TogglePause;
    }

    public void ShowFlickInfo()
    {
        ToggleMenu(pauseCanvasGroup, false);
        ToggleMenu(infoCanvasGroup, true);
    }

    public void HideFlickInfo()
    {
        ToggleMenu(infoCanvasGroup, false);
        ToggleMenu(pauseCanvasGroup, true);
    }

    void TogglePause(bool paused)
    {
        ToggleMenu(_canvasGroup, paused);
        ToggleMenu(pauseCanvasGroup, paused);
        ToggleMenu(infoCanvasGroup, false);
    }

    void ToggleMenu(CanvasGroup canvas, bool show)
    {
        canvas.interactable = show;
        canvas.alpha = show ? 1 : 0;
    }
}
