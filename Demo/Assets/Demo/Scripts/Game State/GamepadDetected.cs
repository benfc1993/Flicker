using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadDetected : MonoBehaviour
{
    Gamepad _gamepad;

    void Awake()
    {
        _gamepad = Gamepad.current;
        if(_gamepad == null) print("no game pad");
    }

    public void OnGamepadDisconnected(PlayerInput playerInput)
    {
        print(playerInput.user.lostDevices[playerInput.playerIndex]);
    }
}
