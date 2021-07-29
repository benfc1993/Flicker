using Flicker;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class SpellSO : Flick
{
    public string spellName;
    public SpellType type;
}


public enum SpellType { Projectile, Aoe}
