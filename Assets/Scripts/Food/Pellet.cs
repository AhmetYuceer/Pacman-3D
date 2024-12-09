public class Pellet : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.Pellet;
        EnergyValue = 10;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteFood();
    }
}