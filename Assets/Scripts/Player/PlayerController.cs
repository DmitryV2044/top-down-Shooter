using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _shotPoint;
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;
    private PoolBullets _poolBullets;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        UpdateService.OnUpdate += GetInput;
        UpdateService.OnFixedUpdate += MovePlayer;
        UpdateService.OnUpdate += Shot;
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

    private void Shot()
    {
        if (Input.GetMouseButtonDown(0))
            this._poolBullets.CreateBullet(_shotPoint);
    }

    private void OnDisable()
    {
        UpdateService.OnUpdate -= GetInput;
        UpdateService.OnFixedUpdate -= MovePlayer;
        UpdateService.OnUpdate -= Shot;
    }
}
