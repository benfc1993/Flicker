using TMPro;
using UnityEngine;

public class ScenarioText : MonoBehaviour
{
    [SerializeField] GameStateSO _gameStateSO;
    TMP_Text text;
    void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.SetText($"Switch to {GetNextScenario(_gameStateSO.scenario).ToString()}");

        _gameStateSO.onScenarioChanged += ChangeScenario;
    }

    void ChangeScenario(GameStateSO.Scenario scenario)
    {
        text.SetText($"Switch to {GetNextScenario(scenario).ToString()}");
    }

    GameStateSO.Scenario GetNextScenario(GameStateSO.Scenario scenario)
    {
        var newScenario = ((int)scenario + 1) % 2;
        return (GameStateSO.Scenario) newScenario;
    }
}
