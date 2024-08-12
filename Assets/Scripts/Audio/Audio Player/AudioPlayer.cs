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
    

    public void PlayShootingClip()
    {
        PlayClip(shootClip, shootingVolume);
    }

    public void PlayEnemyShootingClip()
    {
        PlayClip(shootEnemyClip, shootingEnemyVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    private void PlayClip(AudioClip _audioClip, float clipVolume)
    {
        if(_audioClip != null)
        {
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, clipVolume);
        }
    }
}
