using System.Collections.Generic;
using UnityEngine;
using System;

public class LabelTextureGenerator : MonoBehaviour {

    // This script is responsible for the creation and manipulation of textures for the purpose of
    // having each package have its own destination and lane letter visible.

    Dictionary<String, Texture2D> Texturemap = new Dictionary<String, Texture2D>();

    public Texture2D Font; // 12x18 per char.

    const int fontWidth = 12;
    const int fontHeight = 18;

    // Returns a texture of the passed string.
    // Used for generating the lane and destination textures for the label.
    public Texture2D getTexture(String letters)
    {

        // If texture already exists, don't create it again.
        if (!Texturemap.ContainsKey(letters))
        {
                                                                     // TODO: Assign buffers to variables.
            int textureWidth = letters.Length * (fontWidth + 5) +4;  // The +5 adds spacing to the texture for each character and 
                                                                     // the +4 adds a +2 buffer to both sides between the letters abd label edge.

            // Generate the texture. 
            var texture = new Texture2D(textureWidth  , fontHeight, TextureFormat.ARGB32, false);
            
            // Clear the color from the generated texture.
            for (int y = 0; y < fontHeight; y++)
            {
                for (int x = 0; x < textureWidth * 2; x++)
                {
                    texture.SetPixel(x, y, Color.clear);
                }
            }

            int offset = 5;
            int offset_y = Font.height;

            // Copy each letter to the texture.
            // For each letter.
            for (int i = 0; i < letters.Length; i++)
            {

                // Uses Unicode to determine the ID of the letter we are on.
                // We subtract '0' to find the distance in Unicode our letter is from '0'. 
                // Our Image is properly spaced to where the cur_id * fontWidth will equal the beginning pixel of our letter.
                int cur_id = (int)(letters[i] - '0');

                // For each pixel high.
                for (int y = 0; y < fontHeight; y++)  
                {
                    // For each pixel wide.
                    for (int x = 0; x < fontWidth; x++) 
                    {
                        Color tempColor;

                        // The color of the pixel from our 12 x 18 font map.
                        tempColor = Font.GetPixel(cur_id * fontWidth + x, offset_y - y); 

                        // We set the pixel in our generated texture to equal the tempColor, essentially copying the letter pixel by pixel 
                        texture.SetPixel(offset + x, offset_y - y + 10, tempColor);
                    }
                }

                // Moves + 3 pixel spacing between characters. TODO: Better integrate this with the buffers
                offset += fontWidth+3;
            }

            // Apply all SetPixel calls
            texture.Apply();

            // Saves textures of strings for future use.
            Texturemap[letters] = texture;
        }

        return Texturemap[letters];
    }


    // Generates the texture for the full label.
    public Texture2D GenLabelTexture()
    {
        // The dimentions of the label in pixels.
        int textureWidth = 100;
        int textureHeight = 150;

        // Generate the texture. 

        var texture = new Texture2D(textureWidth , textureHeight, TextureFormat.ARGB32, false);

        for (int y = 0; y < textureHeight; y++)
        {
            for (int x = 0; x < textureWidth * 2; x++)
            {
                texture.SetPixel(x, y, Color.white);
            }
        }
        return texture;
    }

    // Adds the destination and lane texture to the label on an offset.
    // Returns the merged texture.
    public Texture2D MergeTextures(Texture2D label, Texture2D destination, Texture2D lane)
    {
        var texture = label;

        Texture2D[] list = new Texture2D[2];
        list[0] = destination;
        list[1] = lane;
        int y_offset = 0;

        for (int i = 0; i < 2; i++)
        {
            var textureToBeCopied = list[i];

            for (int y = 0; y < textureToBeCopied.height; y++)
            {
                for (int x = 0; x < textureToBeCopied.width; x++)
                {
                    Color tempColor;
                    tempColor = textureToBeCopied.GetPixel(x, y);
                    texture.SetPixel(((label.width / 2) - textureToBeCopied.width / 2) + x, label.height / 2 + y_offset + y, Color.clear);
                    texture.SetPixel(((label.width / 2) - textureToBeCopied.width / 2) + x, label.height / 2 + y_offset + y, tempColor);
                }
            }
            y_offset += destination.height;
        }
        texture.Apply();
        return texture;
    }

}