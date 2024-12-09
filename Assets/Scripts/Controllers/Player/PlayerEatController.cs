using UnityEngine;

public class PlayerEatController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BaseFood food))
        {
            food.Eat();
        } 
    }
}