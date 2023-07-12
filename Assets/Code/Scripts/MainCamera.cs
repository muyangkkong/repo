using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target; // ���ΰ��� Transform ������Ʈ�� �����ϱ� ���� ����

    private void LateUpdate()
    {
        // ���ΰ��� x�� y ��ǥ�� �����ͼ� ī�޶��� ��ġ�� �����մϴ�.
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = newPosition;
    }


}
