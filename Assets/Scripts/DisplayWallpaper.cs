using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWallpaper : MonoBehaviour
{
    [SerializeField] RawImage rawImage;

    void Start()
    {
        string wallpaperPath = GetCurrentDesktopWallpaperPath();
        rawImage.texture = LoadTextureFromPath(wallpaperPath);
    }

    private Texture2D LoadTextureFromPath(string path)
    {
        Debug.Log(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(System.IO.File.ReadAllBytes(path));
        return (texture);
    }

    private string GetCurrentDesktopWallpaperPath()
    {
        byte[] path = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop").GetValue("TranscodedImageCache") as byte[];
        return System.Text.Encoding.Unicode.GetString(SliceByteArray(path, 24)).TrimEnd("\0".ToCharArray());
    }

    private static byte[] SliceByteArray(byte[] input, int index)
    {
        byte[] output = new byte[input.Length - index];
        System.Array.Copy(input, index, output, 0, output.Length);
        return output;
    }
}
