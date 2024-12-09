using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private PlayerEatController _playerEatController;

    public bool isPoweredUp;
    
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
   
    [Header("Dash Settings")]
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _dashCooldown;
    [SerializeField] private bool _isDashing;
    [SerializeField] private ParticleSystem _dashParticleEffect;
    [SerializeField] private int _energyCost = 30;
    
    private float _speed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerEatController = GetComponent<PlayerEatController>();
        SetSpeed(_moveSpeed);
    }

    private void Update()
    {
        Inputs();
        Move();
    }
    
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            SetDirection(Direction.Forward);
        
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            SetDirection(Direction.Backward);
       
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SetDirection(Direction.Right);
       
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            SetDirection(Direction.Left);
 
        if (Input.GetKeyDown(KeyCode.Space))
            Dash();
    }

    private void Move()
    {
        Vector3 move = transform.position;
        move.y = 0;
        transform.position = move;
        
        _characterController.Move( transform.forward * (_speed * Time.deltaTime));
    }
    
    private void SetDirection(Direction direction)
    {
        Vector3 moveDirection = Vector3.forward;

        switch (direction)
        {
            case Direction.Forward:
                moveDirection = Vector3.forward;
                break;
            case Direction.Backward:
                moveDirection = Vector3.back;
                break;
            case Direction.Left:
                moveDirection = Vector3.left;
                break;
            case Direction.Right:
                moveDirection = Vector3.right;
                break;
        }
        transform.forward = moveDirection;
    }

    
    private void Dash()
    {
        if (_isDashing)
            return;

        if (_playerEatController.GetCurrentEnergy() < _energyCost)
            return;
        
        _playerEatController.EnergyCost(_energyCost);
        StartCoroutine(Cooldown());
        StartCoroutine(DashDuration());
    }
    
    private IEnumerator DashDuration()
    {
        SetSpeed(_dashSpeed);
        _dashParticleEffect.Play();
        yield return new WaitForSeconds(_dashDuration);
        _dashParticleEffect.Stop();
        SetSpeed(_moveSpeed);
    }
    
    private IEnumerator Cooldown()
    {
        _isDashing = true;
        StartCoroutine(UIManager.Instance.DashCooldown(_dashCooldown));
        yield return new WaitForSeconds(_dashCooldown);
        _isDashing = false;
    }

    private void SetSpeed(float speed)
    {
        _speed = speed;
    }
}