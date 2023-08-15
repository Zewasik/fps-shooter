using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerGuns playerGuns;

    void OnApplicationFocus(bool hasFocus)
    {

    }

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        playerGuns = GetComponent<PlayerGuns>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Shoot.started += ctx => playerGuns.StartShoot();
        onFoot.Shoot.canceled += ctx => playerGuns.EndShoot();
        onFoot.Reload.performed += ctx => playerGuns.TryReload();
        onFoot.SwitchWeapons.started += ctx => playerGuns.TrySwitchGun(ctx.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(), onFoot.Run.ReadValue<float>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
