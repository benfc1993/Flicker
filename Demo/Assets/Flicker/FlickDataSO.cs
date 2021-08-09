using UnityEngine;

namespace Flicker
{
    [CreateAssetMenu(fileName = "New Flick Data", menuName = "Flicker/Flick Data")]
    public class FlickDataSO : ScriptableObject
    {
        [HideInInspector]
        public string shortCode;
        [HideInInspector]
        public string pattern;

        void OnEnable()
        {
            shortCode = name.Replace("0", "").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "");
            pattern = name;
        }
    }
}
