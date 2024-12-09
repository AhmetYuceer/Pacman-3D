public class PowerPellet : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.PowerPellet;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AtePowerFood();
    }
}
 