using UnityEngine;
using UnityEngine.Events;

namespace Flicker
{
    [AddComponentMenu("Flicker/Flicker Listener")]
    public class FlickerListener : MonoBehaviour
    {
        [SerializeField] FlickBookSO flickBook;
        public UnityEvent<Flick> Found;

        public void LinkToInput(FlickerInput input)
        {
            input.onFlickCompleted.AddListener(ReceiveFlickerData);
        }

        public void ReceiveFlickerData(FlickDataStruct flickData)
        {
            var bestMatch = FlickerCheck.GetBestMatch(flickBook.flicks, flickData);

            if (bestMatch == null) return;
            Flick matchingItem = flickBook.flicks.Find(flick => flick.flickData.pattern == bestMatch.flickData.pattern);

            if(matchingItem != null )
                Found?.Invoke(matchingItem);
        }
    }
}
