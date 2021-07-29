using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/Spell")]
public class SpellSO : FlickASO
{
    public SpellType type;
}


public enum SpellType { Projectile, Aoe}
