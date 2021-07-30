using UnityEngine;

namespace Flicker
{
    [CreateAssetMenu(fileName = "New Flick Data", menuName = "Flicker/Flick Data")]
    public class FlickDataSO : ScriptableObject
    {
        public string shortCode;
        public string pattern;
    }
}
