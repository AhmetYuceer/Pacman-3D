using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : BaseEnemy
{
    [SerializeField] private PlayerController player; 
    private NavMeshAgent _agent;

    [SerializeField] private List<Transform> _aiDots = new List<Transform>();
    [SerializeField] private List<Transform> _targetDots = new List<Transform>();
    [SerializeField] private int _targetIndex = 0;
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private float _moveSpeed = 4;
    private bool _isTargetPlayer;
    private Vector3 _startPosition;
    private int _playerDistance = 5;
    private float _searchRadius = 5;

    private bool _isMove;
    
    void Start()
    {
        EnemyEnum = EnemyEnum.Ghost;
        DamageValue = 1;
        _agent = GetComponent<NavMeshAgent>();
        _startPosition = transform.position;
        _isMove = true;
    }

    private void Update()
    {
        if (GameManager.Instance.IsPlay && _isMove)
        {
            SetTargetDots();
        }
    }

    public void RestartGhostPosition()
    {
        transform.position = _startPosition;
        _agent.speed = _moveSpeed;
        _isMove = true;
    }

    public void PlayerIsDie()
    {
        _agent.speed = 0;
        _isMove = false;
        transform.position = _startPosition;
    }
    
    public IEnumerator TakeDamage()
    {
        if (TryGetComponent(out SkinnedMeshRenderer renderer))
        {
            _isMove = false;
            renderer.enabled = false;
            transform.position = _startPosition;
            _agent.speed = 0;
            
            yield return new WaitForSeconds(2f);
            
            _agent.speed = _moveSpeed;
            renderer.enabled = true;
            _isMove = true;
        }
    }
    
    private void SetTargetDots()
    {
        if (player.isPoweredUp && Vector3.Distance(transform.position, player.transform.position) <= _playerDistance)
        {
            MoveToFurthestPoint();
            return;
        }
        
        CheckPlayerDistance();
        
        if (_targetDots.Count <= 0 || _isTargetPlayer)
        {
            _agent.SetDestination(player.transform.position);
        }
        else if(!_isTargetPlayer && _targetDots.Count > 0)
        {
            if (Vector3.Distance(transform.position, _targetDots[_targetIndex].position) <= 0.1f)
            {
                _targetIndex++;
                if (_targetIndex >= _targetDots.Count)
                    _targetIndex = 0;
            }
            
            _targetPosition = _targetDots[_targetIndex].position;
            _agent.SetDestination(_targetPosition);
        }     
    }
    
    private void MoveToFurthestPoint()
    {
        Transform bestPoint = null;
        float maxCombinedDistance = float.MinValue;

        foreach (var dot in _aiDots)
        {
            if (Vector3.Distance(transform.position, dot.position) <= _searchRadius)
            {
                float distanceToPlayer = Vector3.Distance(dot.position, player.transform.position);
                float distanceFromCurrentPosition = Vector3.Distance(transform.position, dot.position);

                if (distanceToPlayer > Vector3.Distance(transform.position, player.transform.position))
                {
                    float combinedDistance = distanceToPlayer - distanceFromCurrentPosition;

                    if (combinedDistance > maxCombinedDistance)
                    {
                        maxCombinedDistance = combinedDistance;
                        bestPoint = dot;
                    }
                }
            }
        }

        if (bestPoint != null)
        {
            _agent.SetDestination(bestPoint.position);
        }
    }

    private void CheckPlayerDistance()
    {
        _isTargetPlayer = Vector3.Distance(transform.position, player.transform.position) <= _playerDistance;
    }
}
