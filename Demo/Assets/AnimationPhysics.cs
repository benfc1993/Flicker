using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPhysics : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void TrickEnd()
    {
        _animator.enabled = false;
    }
}
