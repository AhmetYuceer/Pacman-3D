using UnityEngine;

public abstract class BaseFood : MonoBehaviour
{
    public FoodEnum FoodType;
    public virtual void Eat(){}
}