using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class unityAds　: MonoBehaviour
{
#if UNITY_ANDROID
            
            public string bannerId = "Banner_Android";
#elif UNITY_IOS
            public string bannerId = "Banner_iOS";
#else
#endif
    void Start()
    {
#if UNITY_ANDROID
            Advertisement.Initialize("4669425");
#elif UNITY_IOS
            Advertisement.Initialize("4669424");
#else
#endif
        StartCoroutine(showBanner());
    }




    IEnumerator showBanner()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.1f); // 0.1秒後に広告表示
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER); //バナーを下部中央にセット
        Advertisement.Banner.Show(bannerId);
    }
}

