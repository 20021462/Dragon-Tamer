using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator m_Animator;

    static readonly int s_Stand = Animator.StringToHash("Stand");
    static readonly int s_Jump = Animator.StringToHash("Jump");
    static readonly int s_Fly = Animator.StringToHash("Fly");

    private void Awake()
    {
        //m_Animator.SetBool(s_Stand, true);
    }
}
