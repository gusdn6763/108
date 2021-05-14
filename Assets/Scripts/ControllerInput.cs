using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    // 전진 속도
    public int speedForward = 6;
    // 옆 걸음 속도
    public int speedSide = 6;
    // 플레이어 트랜스폼
    private Transform tr;
    private float dirX = 0;
    private float dirZ = 0;

    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        dirX = 0;
        dirZ = 0;

        Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        var abxX = Mathf.Abs(coord.x);
        var abxY = Mathf.Abs(coord.y);

        if(abxX > abxY)
        {
            if(coord.x > 0)                                 // 우측
            {
                dirX = +1;
            }
            else                                            // 좌측
            {
                dirX = -1;
            }

        }
        else
        {
            if(coord.y >0)                                  // 위쪽
            {
                dirZ = +1;
            }
            else                                            // 아래쪽
            { 
                dirZ = -1;
            }
        }

        // 이동 방향 설정 후 이동
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

}
