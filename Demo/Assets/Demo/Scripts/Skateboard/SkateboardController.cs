using Demo.Scripts.Skateboard;
using Flicker;
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    Animator _animator;
    bool _grounded;
    [SerializeField] SkateboardStateSO skateboardStateSO;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PreformTrick(FlickSO data)
    {
        TrickFlickSOSO trickFlick = (TrickFlickSOSO) data;

        if (_grounded)
        {
            _animator.enabled = true;
            _animator.Play(trickFlick.clip.name);
        }
    }

    void Update()
    {
        if (transform.position.y <= 0.001f)
            _grounded = true;
        else
            _grounded = false;
    }
}

public enum Stance
{
    Regular,
    Goofy
}
