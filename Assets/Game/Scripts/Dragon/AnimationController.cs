using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    static readonly int s_Vertical = Animator.StringToHash("Vertical");
    static readonly int s_Horizontal = Animator.StringToHash("Horizontal");
    static readonly int s_Stand = Animator.StringToHash("Stand");
    static readonly int s_Jump = Animator.StringToHash("Jump");
    static readonly int s_Fly = Animator.StringToHash("Fly");

    private void Awake()
    {
        //m_Animator.SetBool(s_Stand, true);
    }

    public void SetStand(bool stand)
    {
        m_Animator.SetBool(s_Stand, stand);
    }

    public void SetFly(bool fly)
    {
        m_Animator.SetBool(s_Fly, fly);
    }
}
