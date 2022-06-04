using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Joystick _joystick;
    
    private Vector2 _movement;
    private float dirX, dirY;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        UpdateService.OnUpdate += GetInput;
        UpdateService.OnFixedUpdate += MovePlayer;
    }

    private void GetInput()
    {
        dirX = _joystick.Horizontal * _moveSpeed;
        dirY = _joystick.Vertical * _moveSpeed;
        
        _movement = new Vector2(dirX, dirY);
    }
    private void MovePlayer()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _moveSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        UpdateService.OnUpdate -= GetInput;
        UpdateService.OnFixedUpdate -= MovePlayer;
    }
}
