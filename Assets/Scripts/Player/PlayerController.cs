using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    
    private Vector2 _movement;
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
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
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
