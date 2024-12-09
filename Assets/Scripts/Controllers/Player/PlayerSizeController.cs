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

    private CharacterSize _currentSize;
    
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
        if (!_isReady || _currentSize == nextSize)
            return;
        
        Vector3 sizeValue = transform.localScale;
        
        switch (nextSize)
        {
            case CharacterSize.Small:
                _currentSize = CharacterSize.Small;
                sizeValue = _smallSize;
                break;
            case CharacterSize.Medium:
                _currentSize = CharacterSize.Medium;
                sizeValue = _mediumSize;
                break;
            case CharacterSize.Large:
                _currentSize = CharacterSize.Large;
                sizeValue = _largeSize;
                break;
        }
        
        transform.localScale = sizeValue;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        _isReady = false;
        yield return new WaitForSeconds(_cooldown);
        _isReady = true;
    }
}