public class Cherry : BaseFood
{
    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteCherry();
    }
}