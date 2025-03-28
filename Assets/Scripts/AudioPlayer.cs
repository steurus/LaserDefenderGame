using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume=1f;

    [Header("Damage")]
    [SerializeField] AudioClip DamageClip;
    [SerializeField] [Range(0f,1f)] float DamageVolume=1f;

    public static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance!=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    

    public void PlayShootingClip()
    {
        PlayClip(shootingClip,shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(DamageClip,DamageVolume);
    }

    void PlayClip(AudioClip clip,float volume)
    {
        if(clip!=null)
        {
            Vector3 cameraPos=Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }
}
