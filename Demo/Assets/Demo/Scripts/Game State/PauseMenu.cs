using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameStateSO _gameStateSO;
    CanvasGroup _canvasGroup;
    void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _gameStateSO.onPausedChanged += ToggleMenu;
    }

    void ToggleMenu(bool paused)
    {
        _canvasGroup.interactable = paused;
        _canvasGroup.alpha = paused ? 1 : 0;
    }
}
