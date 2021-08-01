using System;
using Flicker;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class SkateboardController : MonoBehaviour
{
    Animator _animator;
    bool _grounded;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PreformTrick(Flick data)
    {
        TrickSO trick = (TrickSO) data;
        print(trick.clip.name);

        if (_grounded)
        {
            _animator.enabled = true;
            _animator.Play(trick.clip.name);
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
