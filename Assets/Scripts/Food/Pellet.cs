public class Pellet : BaseFood
{
    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteFood();
    }
}