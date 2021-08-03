using Demo.Scripts.Skateboard;
using Flicker;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trick", menuName = "Skateboard/Trick Flick")]
public class TrickFlickSO : Flick
{
    public AnimationClip clip;
    [SerializeField] TrickSO regular;
    [SerializeField] TrickSO goofy;
    public Sprite icon;

    public string TrickName(Stance stance)
    {
        return stance == Stance.Regular ? regular.trickName : goofy.trickName;
    }
}

