using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game State", menuName = "Game State / Game State")]
public class GameStateSO : ScriptableObject
{
    public enum Scenario
    {
        Magic,
        Skateboarding
    }
    public Scenario scenario;
    public bool paused;
    public Action<bool> onPausedChanged;
    public Action<Scenario> onScenarioChanged;

    void OnEnable()
    {
        ResetState();
    }

    void ResetState()
    {
        paused = true;
        scenario = Scenario.Skateboarding;
    }

    public void TogglePause()
    {
        paused = !paused;
        onPausedChanged?.Invoke(paused);
    }

    public void Resume()
    {
        if (paused == false) return;
        paused = false;
        onPausedChanged?.Invoke(false);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void ChangeScenario()
    {
        var newScenario = ((int)scenario + 1) % 2;
        scenario = (Scenario) newScenario;
        onScenarioChanged?.Invoke(scenario);
    }
}
