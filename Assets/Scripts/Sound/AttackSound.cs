using UnityEngine;

namespace Sound
{
    public class AttackSound : MonoBehaviour
    {
        [SerializeField] private AudioSource attackSound;
        [SerializeField] private AudioSource eyeBrowSound;
        void OnEnable()
        {
        attackSound.Play();
        eyeBrowSound.Play();
        }

    
    }
}
