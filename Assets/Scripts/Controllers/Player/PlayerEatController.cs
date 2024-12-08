using UnityEngine;

public class PlayerEatController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Food") && other.transform.TryGetComponent(out BaseFood food))
        {
            food.Eat();
        } 
    }
}