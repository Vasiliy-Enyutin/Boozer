using System;
using UnityEngine;

namespace Player
{
    public class EndgameInformer : MonoBehaviour
    {
        public event Action OnCatched;
        public event Action OnFinishReached;

        public void InvokeOnCatched()
        {
            OnCatched?.Invoke();
        }

        public void InvokeOnFinishReached()
        {
            OnFinishReached?.Invoke();
        }
    }
}
