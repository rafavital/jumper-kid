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

        private bool jumpLastFrame;
        private bool eventJump;
        private float eventHorizontal, leftEventHorizontal, rightEventHorizontal;


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

        private void Update()
        {
            eventHorizontal = rightEventHorizontal - leftEventHorizontal;

#if UNITY_EDITOR
            HorizontalAxis = Input.GetAxisRaw("Horizontal");

            JumpHeld = Input.GetKey(jumpButton);
            JumpDown = Input.GetKeyDown(jumpButton);
#else
            HorizontalAxis = eventHorizontal;

            JumpDown = eventJump;
            JumpHeld = eventJump && jumpLastFrame;
#endif
        }

        private void LateUpdate()
        {
            jumpLastFrame = JumpDown;
        }

        public void SetRightInput(float value) => rightEventHorizontal = value;
        public void SetLeftInput(float value) => leftEventHorizontal = value;
        public void ReceiveJump(bool value) => eventJump = value;
    }
}