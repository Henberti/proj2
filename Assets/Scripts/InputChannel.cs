using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static CustomInput;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Input Channel", menuName ="Channels/Input Channel", order = 0)]
public class InputChannel : ScriptableObject, IPlayerActions
{

    CustomInput input = null;
    public Action<Vector3> moveEvent;
    public Action<float> cameraEvent;
    public Action<bool> shootingEvent, switchAmmoEvent;



    private void OnEnable()
    {
        if (input == null)
            input = new CustomInput();

        input.Player.SetCallbacks(this);
        input.Enable();
    }
    private void OnDestroy()
    {
        input = null;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveEvent?.Invoke(context.ReadValue<Vector3>());
    }
    private void OnDisable()
    {
        input = null;
    }

   
    void IPlayerActions.OnCameraMove(InputAction.CallbackContext context)
    {
        //if (context.phase == InputActionPhase.Performed)
            cameraEvent?.Invoke(context.ReadValue<float>());

    }

    public void OnShooting(InputAction.CallbackContext context)
    {
        bool shootingValue = context.ReadValue<float>() > 0;
        shootingEvent?.Invoke(shootingValue);


    }

    public void OnSwitchAmmo(InputAction.CallbackContext context)
    {
        bool shootingValue = context.ReadValue<float>() > 0;
        switchAmmoEvent?.Invoke(shootingValue);
    }
}
