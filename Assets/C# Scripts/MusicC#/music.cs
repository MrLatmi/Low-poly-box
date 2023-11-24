
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public List<AudioSource> musics;
    public float fadeOutTime;
    public float fadeInTime;

    private AudioSource currentMusic;

    private void Start()
    {
        currentMusic = musics[0];
    }

    public void PlayMusic(int musicIndex)
    {
        if (musicIndex < 0 || musicIndex >= musics.Count)
        {
            return;
        }

        // Плавно затухаем текущую музыку и включаем новую
        LeanTween.value(gameObject, currentMusic.volume, 0f, fadeOutTime)
            .setEase(LeanTweenType.easeInOutSine)
            .setOnUpdate((float val) => { currentMusic.volume = val; })
            .setOnComplete(() =>
            {
                currentMusic.Stop();
                currentMusic = musics[musicIndex];
                currentMusic.volume = 0f;
                currentMusic.Play();
                LeanTween.value(gameObject, 0f, 1f, fadeInTime)
                    .setEase(LeanTweenType.easeInOutSine)
                    .setOnUpdate((float val) => { currentMusic.volume = val; });
            });
    }

}