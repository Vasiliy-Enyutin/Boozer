using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<Dictionary<MovementDirection, ControlButton>> OnControlsChanged;

        [SerializeField]
        private float _moveSpeed;        
        
        private const int MOVEMENT_DIRECTIONS_COUNT = 4;

        public Dictionary<ControlButton, bool> PressedButtons { get; } = new();
        public Dictionary<MovementDirection, ControlButton> KeyAssignment { get; } = new();
        
        public Vector2 MoveDirection { get; private set; } = Vector2.zero;

        public void ChangeControlButtons()
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
            OnControlsChanged?.Invoke(KeyAssignment);
        }

        private void Start()
        {
            SetPressedButtons();
            SetDefaultButtons();
        }

        private void Update()
        {
            SetPressedButtons();
            SetMoveDirection();
            Move();
        }

        private void Move()
        {
            if (MoveDirection.magnitude > 1) 
            {
                MoveDirection.Normalize();
            }
            
            transform.Translate(MoveDirection * _moveSpeed * Time.deltaTime);
        }

        private void SetPressedButtons()
        {
            if (Input.GetKey("w"))
                PressedButtons[ControlButton.W] = true;
            else
                PressedButtons[ControlButton.W] = false;
            
            if (Input.GetKey("s"))
                PressedButtons[ControlButton.S] = true;
            else
                PressedButtons[ControlButton.S] = false;
            
            if (Input.GetKey("a"))
                PressedButtons[ControlButton.A] = true;
            else
                PressedButtons[ControlButton.A] = false;
            
            if (Input.GetKey("d"))
                PressedButtons[ControlButton.D] = true;
            else
                PressedButtons[ControlButton.D] = false;
        }

        private void SetMoveDirection()
        {
            Vector2 direction = Vector2.zero;
            
            foreach (KeyValuePair<ControlButton, bool> buttonToState in PressedButtons)
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

            if (direction.magnitude > 1)
            {
                direction.Normalize();
            }

            MoveDirection = direction;
        }

        private void SetDefaultButtons()
        {
            KeyAssignment.Clear();
            KeyAssignment.Add(MovementDirection.Up, ControlButton.W);
            KeyAssignment.Add(MovementDirection.Down, ControlButton.S);
            KeyAssignment.Add(MovementDirection.Left, ControlButton.A);
            KeyAssignment.Add(MovementDirection.Right, ControlButton.D);
            OnControlsChanged?.Invoke(KeyAssignment);
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
}
