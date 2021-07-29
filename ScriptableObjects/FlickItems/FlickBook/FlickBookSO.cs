using System.Collections.Generic;
using UnityEngine;

namespace Dist.ScriptableObjects.FlickItems.FlickBook
{
    [CreateAssetMenu(fileName = "New Flick Book", menuName = "Flick/Flick Book", order = 0)]
    public class FlickBookSO : ScriptableObject
    {
        public List<FlickASO> flicks;
    }
}
