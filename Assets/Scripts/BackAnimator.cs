using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAnimator : MonoBehaviour
{
    public SpriteRenderer sprite;

    float flipTime = 0;

    private void Update()
    {
        flipTime += Time.deltaTime;

        if(flipTime >= 2f)
        {
            if (sprite.flipX)
            {
                sprite.flipX = false;
                flipTime = 0;
            }
            else if (!sprite.flipX)
            {
                sprite.flipX = true;
                flipTime = 0;
            }
        }
    }
}
