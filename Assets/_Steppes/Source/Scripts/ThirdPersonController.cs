using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThirdPersonController : MonoBehaviour
{
    public Animator _animator;
    public GameObject _lookSource;

    [Space(5)]
    public float _movementLerpSpeed;
    
    private Vector2 _inputDirection;
    private Vector2 _smoothedInputs;
    
    public void Update()
    {
        _smoothedInputs = Vector2.Lerp(_smoothedInputs, _inputDirection, _movementLerpSpeed * Time.deltaTime);
        var forward = Vector3.Cross(Vector3.up, _lookSource.transform.right);
        var relativeLookDirection = (forward * -_smoothedInputs.y) + (_lookSource.transform.right * _smoothedInputs.x);
        
        if (_smoothedInputs.magnitude > 0.05f)
        transform.LookAt(transform.position + relativeLookDirection);
        _animator.SetFloat("RunSpeed", relativeLookDirection.magnitude);
    }

    public void HandleHorizontal(float value)
    {
        _inputDirection.x = value;
    }
    
    public void HandleVertical(float value)
    {
        _inputDirection.y = value;
    }
}
