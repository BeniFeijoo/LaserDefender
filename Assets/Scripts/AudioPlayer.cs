using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClips;
    [SerializeField][Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]

    [SerializeField] AudioClip damageClips;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;
    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        // int instanceCount = FindObjectsOfType(GetType()).Length;
        // if (instanceCount > 1)
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        if (shootingClips != null)
        {
            PlayClip(shootingClips, shootingVolume);
        }
    }

    public void PlayDamageClip()
    {
        if (damageClips != null)
        {
            PlayClip(damageClips, damageVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,
                                        Camera.main.transform.position,
                                        volume);
        }
    }

}
