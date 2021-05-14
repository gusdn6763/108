using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    // ���� �ӵ�
    public int speedForward = 6;
    // �� ���� �ӵ�
    public int speedSide = 6;
    // �÷��̾� Ʈ������
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
            if(coord.x > 0)                                 // ����
            {
                dirX = +1;
            }
            else                                            // ����
            {
                dirX = -1;
            }

        }
        else
        {
            if(coord.y >0)                                  // ����
            {
                dirZ = +1;
            }
            else                                            // �Ʒ���
            { 
                dirZ = -1;
            }
        }

        // �̵� ���� ���� �� �̵�
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

}
