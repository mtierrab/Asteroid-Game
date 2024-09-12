using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        Vector3 moveAdjust = Vector3.zero;
        if(viewportPos.x < 0)
        {
            moveAdjust.x += 1;
        } else if (viewportPos.x > 1) {
            moveAdjust.x -= 1;
        } else if (viewportPos.y < 0){
            moveAdjust.y += 1;
        } else if (viewportPos.y > 1){
            moveAdjust.y -= 1;
        }
        transform.position = Camera.main.ViewportToWorldPoint(viewportPos + moveAdjust);
    }
}
