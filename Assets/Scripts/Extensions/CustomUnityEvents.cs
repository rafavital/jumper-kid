using UnityEngine;
using UnityEngine.Events;

namespace CustomUnityEvents
{
    [System.Serializable] public class UnityTransformEvent : UnityEvent<Transform> { }
    [System.Serializable] public class UnityHitboxEvent : UnityEvent<Hitbox> { }
    [System.Serializable] public class UnityHurtboxEvent : UnityEvent<Hurtbox> { }
}