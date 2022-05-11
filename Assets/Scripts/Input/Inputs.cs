using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    // este script lee las inputs y vos
    // luego las lees de otro y haces las cosas
    #region Movement
    private bool _canMove = true;
    public Vector2 move;
    #endregion

    #region Aiming
    private bool _cursorInputForLook = true;
    public Vector2 look;
    #endregion

    #region Jumping
    public bool jump;
    #endregion

    #region Shooting
    public bool CannonShooting;
    public bool IsShooting;
    #endregion

    #region OnControlChange
    public delegate void ControlChanged(string control);
    public ControlChanged OnControlChanged;
    #endregion

    public void OnPause()
    {
        GameManager.GetInstance.PauseGame();
    }

    #region Movement
    public void OnMove(InputValue value)
    {
        if (!_canMove) return;
        MoveInput(value.Get<Vector2>());
    }

    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }
    #endregion

    #region Aiming
    public void OnAim(InputValue value)
    {
        // chequear cual es el input
        if (_cursorInputForLook && _canMove)
            LookInput(value.Get<Vector2>());
    }

    public void LookInput(Vector2 newLookDirection)
    {
        // Debug.Log(newLookDirection);
        look = newLookDirection;
    }
    #endregion

    #region Jumping
    public void OnJump(InputValue value)
    {
        if (!_canMove) return;
        JumpInput(value.isPressed);
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }
    #endregion

    #region Shooting
    public void OnShoot(InputValue value)
    {
        ShootInput(value.isPressed);
    }

    public void ShootInput(bool newShootState)
    {
        IsShooting = newShootState;
    }

    public void CannonShootInput(bool newShootState)
    {
        CannonShooting = newShootState;
    }
    #endregion

    #region OnControlChange
    public void OnCannonShoot(InputValue value)
    {
        CannonShootInput(value.isPressed);
    }

    private void OnControlsChanged(PlayerInput action)
    {
        if (OnControlChanged != null)
        {
            string device = action.devices[0].ToString();
            string splitDevice = device.Split(":/")[0]; // divide el nombre del dispositivo en algo mas legible
                                                        // Debug.Log(splitDevice);
            OnControlChanged.Invoke(splitDevice);
        }
    }
    #endregion
}