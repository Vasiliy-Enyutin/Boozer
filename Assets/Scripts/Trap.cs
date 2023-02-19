using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] 
    private EndgameInformer _endgameInformer;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out PlayerMovement playerMovement)) {
            return;
        }
        _endgameInformer.InvokeOnCatched();
        playerMovement.GetComponent<Collider2D>().enabled = false;
    }
}
