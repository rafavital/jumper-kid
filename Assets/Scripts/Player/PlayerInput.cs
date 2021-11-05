using System;
using UnityEngine;

namespace Player
{
    [DisallowMultipleComponent]
    public class PlayerInput : MonoBehaviour
    {
        // the following events avoid constant monitoring of values during Update
        public static event Action<float> OnChangeHorizontalAxis;
        public static event Action<float> OnChangeVerticalAxis;

        [SerializeField] private Vector2 axisDeadzone = new Vector2(0.1f, 0.1f);
        [SerializeField] private KeyCode jumpButton = KeyCode.Space;

        [HideInInspector] public bool JumpDown;
        [HideInInspector] public bool JumpHeld;
        public float HorizontalAxis
        {
            get => Mathf.Abs(_horizontalAxis) > axisDeadzone.x ? _horizontalAxis : 0f;
            set
            {
                if (value != _horizontalAxis)
                {
                    OnChangeHorizontalAxis?.Invoke(value);
                }

                _horizontalAxis = value;
            }
        }
        private float _horizontalAxis;
        public float VerticalAxis
        {
            get => Mathf.Abs(_verticalAxis) > axisDeadzone.y ? _verticalAxis : 0f;
            set
            {
                if (value != _verticalAxis)
                {
                    OnChangeVerticalAxis?.Invoke(value);
                }

                _verticalAxis = value;
            }
        }
        private float _verticalAxis;

        private void Update()
        {
            HorizontalAxis = Input.GetAxisRaw("Horizontal");
            VerticalAxis = Input.GetAxisRaw("Vertical");

            JumpHeld = Input.GetKey(jumpButton);
            JumpDown = Input.GetKeyDown(jumpButton);
        }
    }
}