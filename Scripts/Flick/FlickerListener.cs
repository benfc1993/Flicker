using Dist.ScriptableObjects.FlickItems.FlickBook;
using UnityEngine;
using UnityEngine.Events;

public class FlickerListener : MonoBehaviour
{
    [SerializeField] FlickBookSO flickBook;
    public UnityEvent<FlickASO> Found;

    public void LinkToInput(FlickerInput input)
    {
        input.onFlickCompleted.AddListener(ReceiveFlickerData);
    }

    public void ReceiveFlickerData(FlickData flickData)
    {
        var bestMatch = FlickerCheck.GetBestMatch(flickBook.flicks, flickData);

        if (bestMatch == null) return;

        FlickASO matchingItem = flickBook.flicks.Find(s => s.pattern == bestMatch.pattern);
        Debug.Log(matchingItem.flickName);

        if(matchingItem != null )
            print(matchingItem);
        Found?.Invoke(matchingItem);
    }
}
