using Demo.Scripts.Skateboard;
using Flicker;
using UnityEngine;

public class UIFlickList : MonoBehaviour
{
    [SerializeField] GameStateSO gameStateSO;
    [SerializeField] SkateboardStateSO skateboardStateSO;
    [SerializeField] GameObject flickListContainer;
    [SerializeField] GameObject column;
    [SerializeField] GameObject item;
    [SerializeField] FlickBookSO skateboardBook;
    [SerializeField] FlickBookSO spellBook;

    GameObject _currentFlickListContainer;

    void Awake()
    {
        gameStateSO.onPausedChanged += ClearFlickList;
        GenerateFlickList();
    }

    void ClearFlickList(bool paused)
    {
        if (!paused)
                Destroy(_currentFlickListContainer);
    }

    public void GenerateFlickList()
    {

        if (_currentFlickListContainer != null) return;

        _currentFlickListContainer = Instantiate(flickListContainer, transform);
        GameObject currentColumn = null;

        switch (gameStateSO.scenario)
        {
            case (GameStateSO.Scenario.Magic):
                for (int index = 0; index < spellBook.flicks.Count; index++)
                {
                    SpellSO flick = (SpellSO)spellBook.flicks[index];
                    if (index % 6 == 0) currentColumn = Instantiate(column, _currentFlickListContainer.transform);
                    var newItem = Instantiate(item, currentColumn.transform);
                    newItem.GetComponent<UIFlickItem>().Init(flick.icon, flick.spellName);
                }

                break;
            case (GameStateSO.Scenario.Skateboarding):
                for (int index = 0; index < skateboardBook.flicks.Count; index++)
                {
                    TrickFlickSO flick = (TrickFlickSO)skateboardBook.flicks[index];
                    if (index % 6 == 0) currentColumn = Instantiate(column, _currentFlickListContainer.transform);
                    var newItem = Instantiate(item, currentColumn.transform);
                    newItem.GetComponent<UIFlickItem>().Init(flick.icon, flick.TrickName(skateboardStateSO.stance));
                }

                break;
        }
    }
}
