using UnityEngine;
using VT.Audio;

namespace Player
{
    public class PlayerAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioObject jumpSound;
        [SerializeField] private AudioObject walkSound;
        [SerializeField] private AudioObject headHit;

        public void PlayJumpSound() => AudioManager.PlaySound(jumpSound);
        public void PlayWalkSound() => AudioManager.PlaySound(walkSound);
        public void PlayHeadHit() => AudioManager.PlaySound(headHit);

    }
}