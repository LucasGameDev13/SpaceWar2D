using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Sound Play Shooting")]
    [SerializeField] private AudioClip shootClip;  
    [SerializeField] [Range(0f, 1f)] private float shootingVolume;

    [Header("Sound Enemy Shooting")]
    [SerializeField] private AudioClip shootEnemyClip;
    [SerializeField][Range(0f, 1f)] private float shootingEnemyVolume;

    [Header("Damage Shooting")]
    [SerializeField] private AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] private float damageVolume;
    

    //Method to play the player shoot sound
    public void PlayShootingClip()
    {
        PlayClip(shootClip, shootingVolume);
    }

    //Method to play the enemy shoot sound
    public void PlayEnemyShootingClip()
    {
        PlayClip(shootEnemyClip, shootingEnemyVolume);
    }

    //Method to play the damage sound
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    //Method to control the audio clip
    //It is not necessary to have the AudioSource to acess this, because we are playing them on the camera position
    //And the camera has already a listener
    private void PlayClip(AudioClip _audioClip, float clipVolume)
    {
        //If there is an audio clip attached .. Then play it
        if (_audioClip != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, clipVolume);
        }
    }
}
