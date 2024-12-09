public class PowerPellet : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.PowerPellet;
        EnergyValue = 20;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AtePowerFood();
    }
}
 