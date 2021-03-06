﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour {

    // 自定變數 Custom Variables
    public bool fadeIn = true;     // 是否淡入(開始時) Whether to fade in(start)
    public float fadeInDuration = 1.0f;  // 淡入時間(秒) Fade in duration
    [Range(0f, 1f)] public float fadeInVolume = 1.0f;  // 淡入目標音量 Fade in target volume
    public bool fadeOut = true;    // 是否淡出(結束時) Whether to fade out(end)
    public float fadeOutDuration = 1.0f; // 淡出時間(秒) Fade out duration
    [Range(0f, 1f)] public float fadeOutVolume = 0.0f;  // 淡出目標音量 Fade out target volume
                                                        // 固定變數 Constant Variables
    AudioSource au;  // AudioSource元件 AudioSource component

    // 開始 Awake
    void Awake()
    {
        au = GetComponent<AudioSource>();
        // 偵錯 Debug  可能会在一开始没找到
        if (au == null)
        {
            Debug.Log("錯誤!找不到AudioSource元件。  Error! GameObject has no AudioSource component.");
            this.enabled = false;
        }
    }

    void Update()
    {

        if (au.isPlaying)
        {
            // 淡入 Fade in
            if (fadeIn && (au.time <= fadeInDuration + 0.1))
            {
                au.volume = fadeInVolume * (au.time / fadeInDuration);
            }
            // 淡出 Fade out
            if (fadeOut && (au.time >= (au.clip.length - fadeOutDuration)))
            {
                au.volume = (fadeInVolume - fadeOutVolume) * ((au.clip.length - au.time) / fadeOutDuration) + fadeOutVolume;
            }
        }
    }
}
