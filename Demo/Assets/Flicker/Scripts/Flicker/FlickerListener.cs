using UnityEngine;
using UnityEngine.Events;

namespace Flicker
{
    [AddComponentMenu("Flicker/Flicker Listener")]
    public class FlickerListener : MonoBehaviour
    {
        [SerializeField] FlickBookSO flickBook;
        public UnityEvent<Flick> Found;

        [Range(0f,1f)]
        [SerializeField] public float shortCodeAccuracy = 0.66f;
        [Range(0f,1f)]
        [SerializeField] public float patternAccuracy = 0.75f;

        void OnEnable()
        {
            FlickerInput.instance.onFlickCompleted.AddListener(ReceiveFlickerData);
        }

        void OnDisable()
        {
            FlickerInput.instance.onFlickCompleted.RemoveListener(ReceiveFlickerData);
        }

        public void ReceiveFlickerData(FlickData flickData)
        {
            var bestMatch = FlickerCheck.GetBestMatch(flickBook.flicks, flickData, shortCodeAccuracy, patternAccuracy);
            if (bestMatch == null) return;
            Flick matchingItem = flickBook.flicks.Find(flick => flick.flickDataSO.pattern == bestMatch.flickDataSO.pattern);

            if(matchingItem != null )
                Found?.Invoke(matchingItem);
        }
    }
}
