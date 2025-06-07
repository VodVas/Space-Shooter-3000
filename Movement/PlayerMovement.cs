using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
//public class PlayerMovement : MonoBehaviour
//{
//    [SerializeField] private float _moveSpeed = 5f;

//    private Vector3 _moveDirection;
//    private CharacterController _characterController;
//    private InputHandler _inputHandler;
//    private GravityApplier _gravityApplier;
//    private Mover _mover;

//    private void Awake()
//    {
//        _characterController = GetComponent<CharacterController>();
//        _inputHandler = new InputHandler();
//        _gravityApplier = new GravityApplier();
//        _mover = new Mover(_moveSpeed);
//    }

//    private void Update()
//    {
//        ProcessInput();
//        ApplyGravity();
//        Move();
//    }

//    private void OnValidate()
//    {
//        if (_moveSpeed < 0)
//        {
//            _moveSpeed = 0;
//        }
//    }

//    private void ProcessInput()
//    {
//        Vector3 inputDirection = _inputHandler.GetInputVector(transform);

//        SetMoveDirection(inputDirection);
//    }

//    private void SetMoveDirection(Vector3 direction)
//    {
//        _moveDirection.x = direction.x;
//        _moveDirection.z = direction.z;
//    }

//    private void ApplyGravity()
//    {
//        float verticalVelocity = _gravityApplier.ApplyGravity(_characterController);
//        _moveDirection.y = verticalVelocity;
//    }

//    private void Move()
//    {
//        _mover.Move(_characterController, _moveDirection);
//    }
//    private bool IsGrounded()
//    {
//        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);

//        return Physics.Raycast(transform.position, Vector3.down, 0.2f);

//    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.cyan;
//        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.2f);
//    }
//}

public class PlayerMover1 : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private KeyCode _runningKey = KeyCode.LeftShift;
    [SerializeField] private bool _canRun = true;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _visualRoot;
    [SerializeField] private bool _FPSControlType = false;

    private bool _isRunning;
    private float _targetMovingSpeed;
    private float _horizontalInput;
    private float _verticalInput;

    private void FixedUpdate()
    {
        GetPlayerInput();
        UpdateRunningState();

        if (_FPSControlType)
        {
            UpdateCharacterVelocityShooterMov();
        }
        else
        {
            UpdateCharacterVelocity();
            UpdateCharacterRotation();
        }

    }

    private void UpdateRunningState()
    {
        _isRunning = _canRun && Input.GetKey(_runningKey);

        if (_isRunning)
        {
            _targetMovingSpeed = _runSpeed;
        }
        else
        {
            _targetMovingSpeed = _speed;
        }
    }

    private void UpdateCharacterVelocity()
    {
        Vector3 movementDirection = transform.rotation * new Vector3(_horizontalInput, 0f, _verticalInput * _targetMovingSpeed);

        _rigidbody.velocity = movementDirection;
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }


    private void UpdateCharacterVelocityShooterMov()
    {
        // Движение вперед/назад и вбок (в локальных координатах)
        Vector3 localMovement = new Vector3(_horizontalInput * _targetMovingSpeed, 0f, _verticalInput * _targetMovingSpeed);

        // Преобразуем локальное направление в мировое
        Vector3 worldMovement = transform.rotation * localMovement;

        _rigidbody.velocity = worldMovement;
    }

    private void UpdateCharacterRotation()
    {
        float horizontalRotation = Input.GetAxis("Horizontal");

        _visualRoot.Rotate(Vector3.up * horizontalRotation * _rotationSpeed * Time.deltaTime, Space.Self);
    }
}



public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _checkDistance = 0.2f;
    [SerializeField] private LayerMask _groundLayer = ~0; // Все слои по умолчанию

    // Основной метод проверки
    public bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _checkDistance, _groundLayer);
    }

    // Вариант с временной визуализацией луча (для отладки)
    public bool CheckGroundedWithDebug()
    {
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, _checkDistance, _groundLayer);

        Debug.DrawRay(transform.position, Vector3.down * _checkDistance, isGrounded ? Color.green : Color.red, _checkDistance);

        return isGrounded;
    }
}