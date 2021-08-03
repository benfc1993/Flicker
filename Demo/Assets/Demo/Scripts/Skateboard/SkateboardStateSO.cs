using System;
using UnityEngine;

namespace Demo.Scripts.Skateboard
{
    [CreateAssetMenu(fileName = "new Skateboard state", menuName = "Skateboard/state")]
    public class SkateboardStateSO : ScriptableObject
    {
        public Stance stance;
        public Action<Stance> OnStanceChanged;

        public void ChangeStance()
        {
            var newStance = (int) (stance + 1) % 2;
            stance = (Stance)newStance;
            OnStanceChanged?.Invoke(stance);
        }
    }
}
