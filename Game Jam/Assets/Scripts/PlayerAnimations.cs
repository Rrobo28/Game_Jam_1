using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator thisAnim;

    private void Start()
    {
        thisAnim = GetComponent<Animator>();
    }

    public void UpdateMoveState()
    {
        thisAnim.SetInteger("MoveState", (int)PlayerStats.currentMoveState);
    }
}
