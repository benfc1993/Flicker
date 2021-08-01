using Flicker;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public Transform particleEmitter;
    public void CastSpell(Flick flick)
    {
         SpellSO spell = (SpellSO)flick;
         Instantiate(spell.particles, particleEmitter);
    }
}
