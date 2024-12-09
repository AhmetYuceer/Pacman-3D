using System;

public class Cherry : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.Cherry;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteCherry();
    }
}