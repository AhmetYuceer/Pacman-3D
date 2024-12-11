using UnityEngine;

public class PlayerEatController : MonoBehaviour
{
    private PlayerController _player;
    
    private int _maxEnergy = 100;
    private int _currentEnergy;

    private void Start()
    {
        _player = GetComponent<PlayerController>();
        _currentEnergy = _maxEnergy;
        UIManager.Instance.SetEnergyBar(_currentEnergy, _maxEnergy);
    }

    public int GetCurrentEnergy()
    {
        return _currentEnergy;
    }
    
    public void EnergyCost(int energyAmount)
    {
        if (_currentEnergy <= 0)
             return;
        
        _currentEnergy -= energyAmount;

        if (_currentEnergy < 0)
            _currentEnergy = 0;
        
        UIManager.Instance.SetEnergyBar(_currentEnergy, _maxEnergy);
    }
    
    private void AddEnergy(int amount)
    {
        if (_currentEnergy >= _maxEnergy)
            return;
        
        _currentEnergy += amount;

        if (_currentEnergy > _maxEnergy)
            _currentEnergy = _maxEnergy;
        
        UIManager.Instance.SetEnergyBar(_currentEnergy, _maxEnergy);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BaseFood food) && !_player.isDead)
        {
            SoundManager.Instance.PlayEatSfx();
            food.Eat();
            AddEnergy(food.EnergyValue);

            if (food.FoodType == FoodEnum.PowerPellet)
                _player.PowerUP();
            
            if (FoodManager.Instance.CheckLevelComplate())
            {
                StartCoroutine(GameManager.Instance.EndGame());
            }
        } 
    }
}