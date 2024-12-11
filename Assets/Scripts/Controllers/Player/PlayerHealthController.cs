using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
   
    [SerializeField] private int maxHealth = 3;
    private int _currentHealth;
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _currentHealth = maxHealth;
        UIManager.Instance.SetHealthBar(_currentHealth, maxHealth);
    }

    private void TakeDamage(int damage)
    {
        _playerController.isDead = true;
        _currentHealth -= damage;
        SoundManager.Instance.PlayDieSfx();
        UIManager.Instance.SetHealthBar(_currentHealth, maxHealth);
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(UIManager.Instance.ShowMessage("You Lose!" , 3f));
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(UIManager.Instance.ShowMessage("You Die!" , 3f));
            StartCoroutine(GameManager.Instance.Respawn());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BaseEnemy enemy) && !_playerController.isDead)
        {
            if (!_playerController.isPoweredUp)
                TakeDamage(enemy.DamageValue);
            else if (enemy.EnemyEnum == EnemyEnum.Ghost)
            {
                Ghost ghost = (Ghost)enemy;
                StartCoroutine(ghost.TakeDamage());
            }
        }
    }
}
