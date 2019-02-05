using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTemp : MonoBehaviour
{
    Animator animator;
    bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attacking", attacking);
        if (Input.GetButtonDown("Fire1"))
        {
            attacking = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("OverhandAttack"))
        {
            attacking = false;
        }
    }

    private void LateUpdate()
    {

    }
}
