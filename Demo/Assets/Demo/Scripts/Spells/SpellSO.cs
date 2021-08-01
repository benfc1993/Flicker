using Flicker;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class SpellSO : Flick
{
    public string spellName;
    public SpellType type;
    public ParticleSystem particles;
}


public enum SpellType { Projectile, Aoe}
