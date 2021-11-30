using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class captureImage : MonoBehaviour
{
    public int resWidth = 2000;
    public int resHeight = 2000;
    private bool takeImage = false;

    public static string imageName(int width, int height) {
        return string.Format("{0}/Screenshots/TerrainImage_{1}x{2}_{3}.png", Application.dataPath, width, height, System.DateTime.Now.ToString("MM-dd-yyyy_HH-mm-ss"));
    }

    public void TakeImage() {
        takeImage = true;
    }

    void Update() {
        takeImage |= Input.GetKeyDown(KeyCode.I);
        if (takeImage) {
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null;
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = imageName(resWidth, resHeight);
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Saved image to: {0}", filename));
            takeImage = false;
        }
    }
}