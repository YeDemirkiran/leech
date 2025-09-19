using System;
using UnityEngine;

public class CopyFileToDesktop : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] string copyFilename;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CopyToDesktop", 0f);
    }

    public void CopyToDesktop()
    {
        string fileFullPath = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string destinationPath = System.IO.Path.Combine(desktopPath, copyFilename);

        try
        {
            System.IO.File.Copy(fileFullPath, destinationPath, true);
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to copy file! Error: {e.Message}\nTarget file path: {fileFullPath}\nDestination: {destinationPath}");
        }
        Application.Quit();
    }
}
