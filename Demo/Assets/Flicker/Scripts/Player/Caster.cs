using Flicker;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public Transform ParticleEmitter;
    public void CastSpell(Flick testing)
    {
         SpellSO spell = (SpellSO)testing;
         print(spell.spellName);
         Instantiate(spell.particles, ParticleEmitter);
    }
}
