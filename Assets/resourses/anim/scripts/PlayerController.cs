using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigetbody;
    public float _speed = 2f;
    public float _rotationSpeed = 10f;
    public Transform _groundChackerTranform;
    public LayerMask _notPlayerMask;
    public float _jumpForce = 2f;


    // компоненты аниматора
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigetbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float _h = Input.GetAxis("Horizontal"); // переменые для управления на клвиатуре Горизонталь
        float _v = Input.GetAxis("Vertical"); // переменые для управления на клвиатуре Вертикаль

        Vector3 _directionVector = new Vector3(-_h, 0,-_v);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_directionVector),Time.deltaTime * _rotationSpeed); // повороты персонажа

        _animator.SetFloat("Speed", Vector3.ClampMagnitude(_directionVector, 1).magnitude);
        Vector3 _moveDir = Vector3.ClampMagnitude(_directionVector,1) * _speed;


        _rigetbody.velocity = new Vector3(_moveDir.x, _rigetbody.velocity.y, _moveDir.z);
        _rigetbody.angularVelocity = Vector3.zero; // убираем рвки придвижении


        // кнопка прыжка
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        // анимации прыжка и падения и приземления
        if (Physics.Raycast(_groundChackerTranform.position, Vector3.down, 0.2f, _notPlayerMask))

        {
            _animator.SetBool("isInAir", false); // если мы приземлились сразу
        }
        else
        { 
            _animator.SetBool("isInAir", true); // если мы летим в воздухе
        }

    }
    // создаем прыжок
    void Jump()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_groundChackerTranform.position, Vector3.down, 0.2f, _notPlayerMask))
        {
            _animator.SetTrigger("Jump");
            _rigetbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Did not find ground layer");
        }

    }
}
