using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAnim : PlayerMove
{
    protected override void PlayerMoving()
    {
        base.PlayerMoving();
        if (PlayerHealth.isDead)
        {
            return;
        }
        //set animation
        if (verticalMove > 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isStrafe", false);
        }
        if (verticalMove < 0)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isBackward", true);
        }

        if (horizontalMove != 0)
        {
            animator.SetBool("isStrafe", true);
            animator.SetBool("isWalking", false);
        }
        if ((verticalMove == 0 && horizontalMove == 0) || !isGrounded)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isStrafe", false);
            animator.SetBool("isBackward", false);
        }
    }

    protected override void PlayerJump()
    {
        base.PlayerJump();
        if (!isGrounded)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
