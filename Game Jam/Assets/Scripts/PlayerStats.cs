using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float speed = 2f;

    public enum MoveState { Idle,Walking, Running}
    public static MoveState currentMoveState = MoveState.Idle;
}
