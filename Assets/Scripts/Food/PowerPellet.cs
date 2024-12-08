public class PowerPellet : BaseFood
{
    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AtePowerFood();
    }
}
 