using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : Input
{
    #region Inputs
    public  static bool HasJumped => GetKeyDown(KeyCode.Space);
    public static bool HasInteracted => GetKeyDown(KeyCode.F);
    public static bool HasReloaded => GetKeyDown(KeyCode.R);
    public  static bool IsSprinting => GetKey(KeyCode.LeftShift);
    public static bool IsShooting => GetKey(KeyCode.Mouse0);
    public static int InputScroll => Math.Sign(GetAxis("Mouse ScrollWheel"));
    public  static Vector2 InputMovement => new(GetAxis("Horizontal"), GetAxis("Vertical"));
    public  static Vector2 InputRotation => new(GetAxis("Mouse X"), GetAxis("Mouse Y"));
    public  static Vector3 MovementVector(Transform space)=>((space.right*InputMovement.x)+space.forward*InputMovement.y).normalized;

}
#endregion
