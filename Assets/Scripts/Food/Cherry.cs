
public class Cherry : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.Cherry;
        EnergyValue = 100;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteCherry();
    }
}