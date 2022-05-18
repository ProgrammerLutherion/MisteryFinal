using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharPueblo_Movement : Player
{

    public Animator animator;
    public Rigidbody2D rb;
    public float Movement_Speed = 5f;
    Vector2 movement;
    

    void Update()
    {
        if(base.canMove == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
            animator.SetFloat("movement", movement.sqrMagnitude);

            startDialogue();
        }
        openInventory();  
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * Movement_Speed * Time.fixedDeltaTime);
    }

    public override void openInventory()
    {
        base.openInventory();
    }

    public override void startDialogue()
    {
        base.startDialogue();
    }


}
