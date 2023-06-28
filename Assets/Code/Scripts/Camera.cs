using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // 주인공의 Transform 컴포넌트를 참조하기 위한 변수

    private void LateUpdate()
    {
        // 주인공의 x와 y 좌표를 가져와서 카메라의 위치를 설정합니다.
        Vector3 newPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = newPosition;
    }


}
