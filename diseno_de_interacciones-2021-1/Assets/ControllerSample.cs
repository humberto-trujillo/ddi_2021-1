using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSample : MonoBehaviour
{
    private Animator _animator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _animator.SetBool("Walk", true);
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            _animator.SetBool("Walk", false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("Death");
        }
    }
}
