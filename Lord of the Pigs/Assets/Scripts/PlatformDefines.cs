﻿using UnityEngine;
using System.Collections;

public class PlatformDefines : MonoBehaviour
{
    private void Start()
    {
        #if UNITY_EDITOR
            Debug.Log("Unity Editor");
        #endif
        
        #if UNITY_ANDROID
            Debug.Log("ANDROID");
        #endif

        #if UNITY_IOS
              Debug.Log("Iphone");
        #endif

        #if UNITY_STANDALONE_OSX
            Debug.Log("Stand Alone OSX");
        #endif

        #if UNITY_STANDALONE_WIN
                Debug.Log("Stand Alone Windows");
        #endif
    }
}