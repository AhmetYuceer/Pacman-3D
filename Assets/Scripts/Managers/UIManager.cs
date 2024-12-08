using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void AteFood(int count)
    {
        Debug.Log("Ate Food : " + count);
    }   
    public void AtePowerFood(int count)
    {
        Debug.Log("Ate Power Food : " + count);
    }
    public void AteAteCherry(int count)
    {
        Debug.Log("Ate Cherry : " + count);
    }
}
