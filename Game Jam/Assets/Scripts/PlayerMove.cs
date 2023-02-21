using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController characterController;
   

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 movement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        if(movement == Vector3.zero && PlayerStats.currentMoveState != PlayerStats.MoveState.Idle)
        {
            PlayerStats.currentMoveState = PlayerStats.MoveState.Idle;
            GetComponent<PlayerAnimations>().UpdateMoveState();
        }
        else if(movement != Vector3.zero && PlayerStats.currentMoveState != PlayerStats.MoveState.Walking)
        {
            PlayerStats.currentMoveState = PlayerStats.MoveState.Walking;
            GetComponent<PlayerAnimations>().UpdateMoveState();
        }


        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
        characterController.SimpleMove(movement * PlayerStats.speed);
    }
}
