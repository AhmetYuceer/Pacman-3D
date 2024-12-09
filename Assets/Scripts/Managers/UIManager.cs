using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("Skills")]
    [SerializeField] private Image _smallSkillCooldown;
    [SerializeField] private Image _midSkillCooldown;
    [SerializeField] private Image _largeSkillCooldown;
    [SerializeField] private Image _dashSkillCooldown;
    
    [Header("Foods")]
    [SerializeField] private TextMeshProUGUI _pelletCountText;
    [SerializeField] private TextMeshProUGUI _cherryCountText;
    [SerializeField] private TextMeshProUGUI _powerPelletCountText;
    
    [Header("health")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _energyBar;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void SetHealthBar(float health , float maxHealth)
    {
        _healthBar.fillAmount = health / maxHealth;
    }

    public void SetEnergyBar(float energy, float maxEnergy)
    {
        _energyBar.fillAmount = energy / maxEnergy;
    }
    
    public IEnumerator SkillCooldown(float time)
    {
        float timer = 0;
        
        while (timer < time)
        {
            timer += Time.deltaTime;
            _smallSkillCooldown.fillAmount = timer;
            _midSkillCooldown.fillAmount = timer;
            _largeSkillCooldown.fillAmount = timer;
            yield return null;
        }
    }
    
    public IEnumerator DashCooldown(float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            _dashSkillCooldown.fillAmount = timer;
            yield return null;
        }
    }
    
    public void AteFood(int count)
    {
        _pelletCountText.text = count.ToString();
    }   
    
    public void AtePowerFood(int count)
    {
        _powerPelletCountText.text = count.ToString();
    }
    
    public void AteAteCherry(int count)
    {
        _cherryCountText.text = count.ToString();
    }
}
