using UnityEngine;

public abstract class BaseFood : MonoBehaviour
{
    public FoodEnum FoodType;
    public int EnergyValue;
    public virtual void Eat(){}
}