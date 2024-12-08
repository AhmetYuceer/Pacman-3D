using UnityEngine;
using System.Collections;

public class PlayerSizeController : MonoBehaviour
{
    private CharacterController _characterController;
    
    [Header("Character Size")]
    [SerializeField] private CharacterSize _startingCharacterSize;
    [SerializeField] private float _cooldown;
    [SerializeField] private Vector3 _smallSize;
    [SerializeField] private Vector3 _mediumSize;
    [SerializeField] private Vector3 _largeSize;
    [SerializeField] private bool _isReady;
    
    private void Start()
    {
        _isReady = true;
        ChangeSize(_startingCharacterSize);
    }

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSize(CharacterSize.Small);
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSize(CharacterSize.Medium);
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSize(CharacterSize.Large);
    }
    
    private void ChangeSize(CharacterSize nextSize)
    {
        if (!_isReady)
            return;
        
        StartCoroutine(Cooldown());
        
        Vector3 sizeValue = transform.localScale;
        switch (nextSize)
        {
            case CharacterSize.Small:
                sizeValue = _smallSize;
                break;
            case CharacterSize.Medium:
                sizeValue = _mediumSize;
                break;
            case CharacterSize.Large:
                sizeValue = _largeSize;
                break;
        }
        transform.localScale = sizeValue;
    }

    private IEnumerator Cooldown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
    }
}