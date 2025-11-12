using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    //Attributs
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollingSpeed;
    private float initialSpeed;
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isRolling;

    //Components
    private Rigidbody2D rig;

    #endregion

    #region Capsules
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        _isRunning = false;
    }
    private void Update()
    {
        OnInput();
        OnRoll();
        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    #region Movement Methods
    public void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    public void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    public void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed = rollingSpeed;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = initialSpeed;
        }
    }
    #endregion
}
