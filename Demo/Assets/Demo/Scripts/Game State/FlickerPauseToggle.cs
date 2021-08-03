using Flicker;
using UnityEngine;

public class FlickerPauseToggle : MonoBehaviour
{
    [SerializeField] GameStateSO _gameStateSO;
    FlickerInput _flickerInput;
    void Awake()
    {
        _flickerInput = GetComponent<FlickerInput>();
        _flickerInput.disabled = _gameStateSO.paused;
        _gameStateSO.onPausedChanged += ToggleFlicker;
    }

    void ToggleFlicker(bool paused)
    {
        _flickerInput.disabled = paused;
    }
}
