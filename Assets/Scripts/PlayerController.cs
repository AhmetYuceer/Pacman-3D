using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _dashSpeed = 20f;
    [SerializeField] private float _dashDuration = 0.2f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private bool _isDashing;

    private float _speed;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        SetSpeed(_moveSpeed);
    }

    private void Update()
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
        
        _characterController.Move( transform.forward * (_speed * Time.deltaTime));
    }

    #region Dash
    private void Dash()
    {
        if (_isDashing)
            return;
        
        StartCoroutine(Cooldown());
        StartCoroutine(DashDuration());
    }
    private IEnumerator DashDuration()
    {
        SetSpeed(_dashSpeed);
        yield return new WaitForSeconds(_dashDuration);
        SetSpeed(_moveSpeed);
    }
    private IEnumerator Cooldown()
    {
        _isDashing = true;
        yield return new WaitForSeconds(_dashCooldown);
        _isDashing = false;
    }
    #endregion
    
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

    private void SetSpeed(float speed)
    {
        _speed = speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Food"))
        {
            other.transform.gameObject.SetActive(false);
        }
        else if (other.transform.CompareTag("PowerFood"))
        {
            other.transform.gameObject.SetActive(false);
        }
    }
}

public enum Direction
{
    Forward,
    Backward,
    Left,
    Right
}
