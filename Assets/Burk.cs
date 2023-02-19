using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Burk : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;
    
    private PlayerMovement _playerMovement;
    private AudioSource _audioSource;

    private void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerMovement.OnControlsChanged += PlayBurk;
        _audioSource = GetComponent<AudioSource>();
    }

    private void PlayBurk(Dictionary<MovementDirection, ControlButton> obj)
    {
        _audioSource.PlayOneShot(_clip);
    }
}
