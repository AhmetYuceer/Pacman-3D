public class Pellet : BaseFood
{
    private void Start()
    {
        FoodType = FoodEnum.Pellet;
    }

    public override void Eat()
    {
        this.gameObject.SetActive(false);
        FoodManager.Instance.AteFood();
    }
}