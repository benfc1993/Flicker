using Flicker;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public void CastSpell(Flick testing)
    {
         SpellSO spell = (SpellSO)testing;
         print(spell.spellName);
    }
}
