using UnityEngine;
using System.Collections.Generic;

public class FoodManager : MonoBehaviour
{
    public static FoodManager Instance;

    [SerializeField] List<BaseFood> AllFoods = new List<BaseFood>();
    
    private int AteFoodCount;
    private int AtePowerFoodCount;
    private int AteCherryCount;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public bool CheckLevelComplate()
    {
        bool isComplated = true;
        
        foreach (var item in AllFoods)
        {
            if (item.gameObject.activeSelf)
                isComplated = false;
        }

        return isComplated;
    }
    
    public void AteFood()
    {
        AteFoodCount += 1;
        UIManager.Instance.AteFood(AteFoodCount);
    }   
    
    public void AtePowerFood()
    {
        AtePowerFoodCount += 1;
        UIManager.Instance.AtePowerFood(AtePowerFoodCount);
    }   
    
    public void AteCherry()
    {
        AteCherryCount += 1;
        UIManager.Instance.AteAteCherry(AteCherryCount);
    }
}