using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スクショ
/// 適当なオブジェクトにアタッチ
/// </summary>
public class Screenshot : MonoBehaviour
{
    [SerializeField] private Button _ssButton;
    [SerializeField] private Camera _camera;

    void Start()
    {
        _ssButton.onClick.AddListener(SaveScreenShotToGallery);
    }

    private void OnDestroy()
    {
        _ssButton.onClick.RemoveListener(SaveScreenShotToGallery);
    }

    /// <summary>
    /// ボタンに登録するスクショ処理
    /// </summary>
    private void SaveScreenShotToGallery()
    {
        var ct = this.GetCancellationTokenOnDestroy();
        SaveScreenShotToGalleryAsync(ct).Forget();
    }

    /// <summary>
    /// スクショを作成して保存する
    /// </summary>
    private async UniTask SaveScreenShotToGalleryAsync(CancellationToken ct)
    {
        //任意のフレームの描画処理が終わるまで待つ
        await UniTask.WaitForEndOfFrame(ct);

        //Cameraの描画領域をRenderTextureとして取り出す
        var rt = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, 24);
        var prev = _camera.targetTexture;
        _camera.targetTexture = rt;
        _camera.Render();
        _camera.targetTexture = prev;
        RenderTexture.active = rt;

        var screenShot = new Texture2D(
            _camera.pixelWidth,
            _camera.pixelHeight,
            TextureFormat.RGB24,
            false);
        screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);
        screenShot.Apply();

        var date = DateTime.Now.ToString("yyyyMMdd");

        //CameraのRenderTextureを元に画像を作成して保存
        NativeGallery.SaveImageToGallery(screenShot, "GalleryTest", $"{date}.png");
    }
}