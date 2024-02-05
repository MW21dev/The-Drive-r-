using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundManager;

    public AudioClip dmg;
    public AudioClip speedUp;
    public AudioClip point;
    public AudioClip lose;

    public void PlaySound(int soundnb)
    {
        switch(soundnb)
        {
            case 0:
                    soundManager.clip = dmg;
                soundManager.Play();

                break;
            case 1:
                    soundManager.clip = speedUp;
                soundManager.Play();

                break;
            case 2:
                    soundManager.clip = point;
                soundManager.Play();

                break;
            case 3:
                    soundManager.clip = lose;
                soundManager.Play();

                break;
                
        }
    }
}
