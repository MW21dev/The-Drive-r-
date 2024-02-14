using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite sprite1;
    public Sprite sprite2;

    float waveTime = 0;

    private void Update()
    {
        waveTime += Time.deltaTime;

        if (waveTime >= 2f)
        {
            waveTime = 2f;
        }


        if (waveTime == 2f)
        {
            if(render.sprite == sprite1)
            {
                render.sprite = sprite2;
                waveTime = 0;
            }
            else if (render.sprite == sprite2)
            {
                render.sprite = sprite1;
                waveTime = 0;
            }
        }
    }
}
