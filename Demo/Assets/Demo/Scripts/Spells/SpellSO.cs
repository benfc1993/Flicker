using Flicker;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class SpellSO : FlickSO
{
    public string spellName;
    public SpellType type;
    public ParticleSystem particles;
    public Sprite icon;
}


public enum SpellType { Projectile, Aoe}
