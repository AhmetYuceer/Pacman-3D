using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController _player; 
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _fallowSpeed;
    private Camera _camera;

    private void Start()
    {
        _camera = this.gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 targetPosition = _player.transform.position + _offset;
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition,_fallowSpeed * Time.deltaTime);
    }
}
