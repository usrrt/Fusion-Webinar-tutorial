using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

// 입력권한이 있으면 클라이언트가 객체의 네트워크상태를 직접수정 방지가능
// 호스트가 네트워크 상태업데이트위해 해석할 입력구조 제공가능
// 사용자로부터 입력을 수집하기위해 입력을 보유할 데이터 [구조체] 정의필요
public struct NetworkInputData : INetworkInput
{
    public Vector3 direction;
}
