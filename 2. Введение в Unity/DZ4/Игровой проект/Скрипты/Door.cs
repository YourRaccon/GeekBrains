using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider _collider;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        _animator = gameObject.GetComponent<Animator>();
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Open()
    {
        _animator.SetTrigger("Open");
        _audioSource.Play();
    }
}
