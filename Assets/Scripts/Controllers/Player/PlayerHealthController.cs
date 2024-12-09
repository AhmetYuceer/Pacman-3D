using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnTransform;
    [SerializeField] private int maxHealth = 3;
    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        UIManager.Instance.SetHealthBar(_currentHealth, maxHealth);
    }

    private void TakeDamage(int damage)
    {
        this.gameObject.transform.position = _playerSpawnTransform.position;        
        _currentHealth -= damage;
        UIManager.Instance.SetHealthBar(_currentHealth, maxHealth);
        Death();
    }

    private void Death()
    {
        if (_currentHealth <= 0)
        {
            Debug.Log("End Game");
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BaseEnemy enemy))
        {
            TakeDamage(enemy.DamageValue);
        }
    }
}
