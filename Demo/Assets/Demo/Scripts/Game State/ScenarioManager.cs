using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] GameStateSO _gameStateSO;
    [SerializeField] GameObject caster;
    [SerializeField] GameObject casterUI;
    [SerializeField] GameObject skateBoard;
    [SerializeField] GameObject skateBoardUI;


    void Awake()
    {
        _gameStateSO.onScenarioChanged += ChangeScenario;
    }

    void ChangeScenario(GameStateSO.Scenario scenario)
    {
        switch (scenario)
        {
            case (GameStateSO.Scenario.Magic):
                caster.SetActive(true);
                casterUI.SetActive(true);
                skateBoard.SetActive(false);
                skateBoardUI.SetActive(false);
                break;
            case (GameStateSO.Scenario.Skateboarding):
                caster.SetActive(false);
                casterUI.SetActive(false);
                skateBoard.SetActive(true);
                skateBoardUI.SetActive(true);
                break;
        }
    }
}
