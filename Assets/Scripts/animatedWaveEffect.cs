using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatedWaveEffect : MonoBehaviour
{
    public float distortionStrength = 0.1f;
    public float distortionSpeed = 1.0f;
    public Material waveMaterial;

    void Start() {
        FindFirstObjectByType<SAudioManager>().Play("name");

        // Get the sprite renderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the sprite's texture
        Texture2D spriteTexture = spriteRenderer.sprite.texture;

        // Assign the sprite's texture to the material
        waveMaterial.SetTexture("_MainTex", spriteTexture);

        // Assign the material to the sprite's renderer
        spriteRenderer.material = waveMaterial;
    }

    void Update() {
        waveMaterial.SetFloat("_DistortionStrength", distortionStrength);
        waveMaterial.SetFloat("_DistortionSpeed", distortionSpeed);
    }
}
