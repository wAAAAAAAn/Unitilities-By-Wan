using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Img2Base64
{
    public static string Sprite2Base64(Sprite sprite)
    {
        Texture2D texture = SpriteToTexture2D(sprite);
        return Texture2DToBase64(texture);
    }

    static Texture2D SpriteToTexture2D(Sprite sprite)
    {
        Texture2D texture = sprite.texture;
        Rect spriteRect = sprite.rect;

        // ���ο� Texture2D ����
        Texture2D newText = new Texture2D((int)spriteRect.width, (int)spriteRect.height, texture.format, false);

        Color[] newColors = texture.GetPixels((int)spriteRect.x, (int)spriteRect.y, (int)spriteRect.width, (int)spriteRect.height);
        newText.SetPixels(newColors);
        newText.Apply();
        return newText;
    }

     static string Texture2DToBase64(Texture2D texture)
    {
        byte[] textureBytes = texture.EncodeToPNG();
        return Convert.ToBase64String(textureBytes);
    }
}
