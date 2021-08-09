using System.Collections.Generic;
using UnityEngine;

namespace Flicker
{
    [CreateAssetMenu(fileName = "New Flick Book", menuName = "Flicker/Flick Book", order = 0)]
    public class FlickBookSO : ScriptableObject
    {
        public List<FlickSO> flicks;
    }
}
