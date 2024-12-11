using System;
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
    [SerializeField] private Image _dashSkillCooldown;
    
    [Header("Foods")]
    [SerializeField] private TextMeshProUGUI _pelletCountText;
    [SerializeField] private TextMeshProUGUI _cherryCountText;
    [SerializeField] private TextMeshProUGUI _powerPelletCountText;
    
    [Header("health")]
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _energyBar;
    
    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _messageText;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {
        _timerText.text = "";
        _messageText.text = "";
    }

    private string msg2 = "You Won!";
    private string msg3 = "You Lose!";
    private string msg4 = "You Die!";
    
    public IEnumerator ShowMessage(string message, float time)
    {
        _messageText.text = message;
        yield return new WaitForSeconds(time);
        _messageText.text = "";
    }
    
    public IEnumerator Timer(float time)
    {
        _timerText.text = time.ToString("0");
        
        float timer = time;
        while (timer > 0)
        {
            timer -= Time.deltaTime; 
            _timerText.text = timer.ToString("0");
            yield return null;
        }
        
        _timerText.text = "";
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
