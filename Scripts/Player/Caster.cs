using UnityEngine;

public class Caster : MonoBehaviour
{
    public void CastSpell(FlickASO testing)
    {
         SpellSO spell = (SpellSO)testing;
         print(spell.type);
    }
}
