using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraController : MonoBehaviour
{
    public Transform _playerTransform;
    public Vector3 _offset;
    public float _camPositionSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 _newCamPositiom = new  Vector3(_playerTransform.position.x + _offset.x,_playerTransform.position.y + _offset.y, _offset.z) ; // для перемезщения камеры за персонажм 
        transform.position = Vector3.Lerp(transform.position, _newCamPositiom, _camPositionSpeed * Time.deltaTime);// для плавного перерещения и торорможения камеры 
    }
}
