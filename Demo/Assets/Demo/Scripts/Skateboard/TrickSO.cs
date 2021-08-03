using UnityEngine;

namespace Demo.Scripts.Skateboard
{
    [CreateAssetMenu(fileName = "New Trick", menuName = "Skateboard/Trick")]
    public class TrickSO : ScriptableObject
    {
        public string trickName;
    }
}
