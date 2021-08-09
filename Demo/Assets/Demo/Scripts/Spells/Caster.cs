using Flicker;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public Transform particleEmitter;
    public void CastSpell(FlickSO flickSO)
    {
         SpellSO spell = (SpellSO)flickSO;
         Instantiate(spell.particles, particleEmitter);
    }
}
