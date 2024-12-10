using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : BaseEnemy
{
    [SerializeField] private PlayerController player; 
    private NavMeshAgent _agent;

    [SerializeField] private List<Transform> _aiDots = new List<Transform>();
    [SerializeField] private List<Transform> _targetDots = new List<Transform>();
    [SerializeField] private int targetIndex = 0;
    [SerializeField] private Vector3 targetPosition;
    private bool _isTargetPlayer;
    private Vector3 _startPosition;
    private int _playerDistance = 5;
    private float _searchRadius = 5;

    void Start()
    {
        EnemyEnum = EnemyEnum.Ghost;
        DamageValue = 1;
        _agent = GetComponent<NavMeshAgent>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        SetTargetDots();
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
        else if(!_isTargetPlayer)
        {
            if (Vector3.Distance(transform.position, _targetDots[targetIndex].position) <= 0.1f)
            {
                targetIndex++;
                if (targetIndex >= _targetDots.Count)
                    targetIndex = 0;
            }
            
            targetPosition = _targetDots[targetIndex].position;
            _agent.SetDestination(targetPosition);
        }     
    }
    
    private void MoveToFurthestPoint()
    {
        Transform bestPoint = null;
        float maxCombinedDistance = float.MinValue;

        foreach (var dot in _aiDots)
        {
            // AI'nın kendi menzilinde mi?
            if (Vector3.Distance(transform.position, dot.position) <= _searchRadius)
            {
                float distanceToPlayer = Vector3.Distance(dot.position, player.transform.position);
                float distanceFromCurrentPosition = Vector3.Distance(transform.position, dot.position);

                // Noktanın player'dan uzak olmasını ve player’a yaklaşmamayı kontrol et
                if (distanceToPlayer > Vector3.Distance(transform.position, player.transform.position))
                {
                    // Hem AI'nın kendi pozisyonundan uzak hem de player’dan uzak noktayı seç
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
