using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    private bool isFullScreened = false;
    private int baseWidth = 800;
    private int baseHeight = 600;

    private int newWidth;
    private int newHeight;

    public static ResolutionManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Initialize fullscreen state based on user's initial resolution
        isFullScreened = Screen.fullScreen;
        SetResolution(isFullScreened);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            ToggleFullscreen();
        }
    }

    public void ToggleFullscreen()
    {
        isFullScreened = !isFullScreened;
        SetResolution(isFullScreened);
    }

    private void SetResolution(bool fullscreen)
    {
        if (fullscreen)
        {
            int screenWidth = Screen.currentResolution.width;
            int screenHeight = Screen.currentResolution.height;

            if (screenHeight < 1200)
            {
                newWidth = 1200;
                newHeight = 900;
            }
            else
            {
                newWidth = 1600;
                newHeight = 1200;
            }

            // Set the resolution and upscale the pixel art
            Screen.SetResolution(newWidth, newHeight, true);
        }
        else
        {
            // Set the resolution back to the base resolution
            Screen.SetResolution(baseWidth, baseHeight, false);
        }
    }

    /*private bool isFullscreen = false;

    private void Start()
    {
        // Set initial fullscreen mode if needed
        SetFullscreen(isFullscreen);
    }

    private void Update()
    {
        // Toggle fullscreen mode on a key press, button click, etc.
        if (Input.GetKeyDown(KeyCode.F4))
        {
            isFullscreen = !isFullscreen;
            SetFullscreen(isFullscreen);
        }
    }

    private void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }*/
}
