using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Joystick moveJoystick;
    [SerializeField] private Joystick attackJoystick;

    private Vector2 _movement;
    private float _dirX, _dirY;
    private Rigidbody2D _rigidbody;
    private GameObject _gun;
    
    
    private EnumGuns.TypeOfGun _typeOfGun;

    private void Start()
    {
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._gun = GameObject.FindWithTag("Gun");

    }

    private void OnEnable()
    {
        UpdateService.OnUpdate += GetInput;
        UpdateService.OnFixedUpdate += MovePlayer;
    }
    private void GetInput()
    {
        this._dirX = this.moveJoystick.Horizontal * this.moveSpeed;
        this._dirY = this.moveJoystick.Vertical * this.moveSpeed;
        
        this._movement = new Vector2(this._dirX, this._dirY);

        if (this._typeOfGun == EnumGuns.TypeOfGun.Glock17)
        {
            var glock17 = this._gun.GetComponent<Glock17>();
            if(Math.Abs(this.attackJoystick.Horizontal) > 0.3f || Math.Abs(this.attackJoystick.Vertical) > 0.3f)
            {
                glock17.rotZ = Mathf.Atan2(this.attackJoystick.Vertical, this.attackJoystick.Horizontal) * Mathf.Rad2Deg;
            }

            glock17.transform.rotation = Quaternion.Euler(0f, 0f, glock17.rotZ + glock17.offset);

            if(this.attackJoystick.Horizontal != 0 || this.attackJoystick.Vertical != 0)
                glock17.Shot();
            if(Input.GetKeyDown(KeyCode.R))
                glock17.ReloadGun();
        }
            
        
    }
    private void MovePlayer()
    {
        this._rigidbody.MovePosition(this._rigidbody.position + this._movement * this.moveSpeed * Time.deltaTime);
    }
    private void OnDisable()
    {
        UpdateService.OnUpdate -= GetInput;
        UpdateService.OnFixedUpdate -= MovePlayer;
    }

    public void WhatIsGun(EnumGuns.TypeOfGun typeOfGun)
    {
        this._typeOfGun = typeOfGun;
    }
}
