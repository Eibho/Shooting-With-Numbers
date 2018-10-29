using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour {

    private Animator m_animator;
    public float m_forward;

    
    void Start () {
        
        m_animator = GetComponent<Animator>();
    }

    public void Move(float forward)
    {
        //walk animation
        

        m_animator.SetFloat("Forward", forward);
    }
}
