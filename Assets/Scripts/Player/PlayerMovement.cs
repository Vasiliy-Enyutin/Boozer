using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _moveSpeed;        
        
        private const int MOVEMENT_DIRECTIONS_COUNT = 4;
        private readonly Dictionary<ControlButton, bool> _pressedButtons = new ();
        private Vector2 _moveDirection = Vector2.zero;

        public Dictionary<MovementDirection, ControlButton> KeyAssignment { get; } = new();

        private void Awake()
        {
            ChangeControlButtons();
        }

        private void Update()
        {
            SetPressedButtons();
            SetMoveDirection();
            Move();
        }

        private void Move()
        {
            if (_moveDirection.magnitude > 1) 
            {
                _moveDirection.Normalize();
            }
            
            transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime);
        }

        private void SetPressedButtons()
        {
            if (Input.GetKey("w"))
                _pressedButtons[ControlButton.W] = true;
            else
                _pressedButtons[ControlButton.W] = false;
            
            if (Input.GetKey("s"))
                _pressedButtons[ControlButton.S] = true;
            else
                _pressedButtons[ControlButton.S] = false;
            
            if (Input.GetKey("a"))
                _pressedButtons[ControlButton.A] = true;
            else
                _pressedButtons[ControlButton.A] = false;
            
            if (Input.GetKey("d"))
                _pressedButtons[ControlButton.D] = true;
            else
                _pressedButtons[ControlButton.D] = false;
        }

        private void ChangeControlButtons()
        {
            List<int> randomNumbers = GetRandomNumbers(4);
            KeyAssignment.Clear();
            for (int i = 0; i < MOVEMENT_DIRECTIONS_COUNT; i++)
            {
                KeyAssignment.Add((MovementDirection) i, (ControlButton) randomNumbers[i]);
            }

            foreach (KeyValuePair<MovementDirection, ControlButton> directionToButton in KeyAssignment)
            {
                Debug.Log($"Direction = {directionToButton.Key}, button = {directionToButton.Value}");
            }
        }

        private void SetMoveDirection()
        {
            Vector2 direction = Vector2.zero;
            
            foreach (KeyValuePair<ControlButton, bool> buttonToState in _pressedButtons)
            {
                if (buttonToState.Value == false)
                {
                    continue;
                }
                
                MovementDirection movementDirection = KeyAssignment.FirstOrDefault(x => x.Value == buttonToState.Key).Key;
                switch (movementDirection)
                {
                    case MovementDirection.Up:
                        direction += Vector2.up;
                        break;
                    case MovementDirection.Down:
                        direction += Vector2.down;
                        break;
                    case MovementDirection.Left:
                        direction += Vector2.left;
                        break;
                    case MovementDirection.Right:
                        direction += Vector2.right;
                        break;
                }
            }

            _moveDirection = direction;
        }

        private List<int> GetRandomNumbers(int length)
        {
            List<int> numbers = new();
            while (numbers.Count < length)
            {
                int randomNumber = Random.Range(0, length);
                if (numbers.Contains(randomNumber))
                {
                    continue;
                }
                
                numbers.Add(randomNumber);
            }

            return numbers;
        }
    }


    public enum MovementDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum ControlButton
    {
        W,
        A,
        S,
        D
    }
}
