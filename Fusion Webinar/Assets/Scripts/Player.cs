using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    // 네트워크동기화를 위해선 int대신 int32사용함

    // [Networked] // <- 네트워크로 동기화 되는 상태

    [Networked(OnChanged = nameof(MyByteChanged))]
    public byte myByte
    {
        get;
        set;
    }

    public static void MyByteChanged(Changed<Player> changed)
    {
        if (changed.Behaviour)
        {
            changed.Behaviour.MyByteChangedPrint();
        }
    }

    private void MyByteChangedPrint()
    {
        Debug.Log(myByte);
    }

    private NetworkCharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterController>();
    }

    // 서버에선 FixedUpdate를 정확히 실행
    // 클라이언트는 서버에서 받아온 fixedupdate를 호출함
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            // 모든방향으로 단위벡터화 시켜서 대각선방향(동시에 키 2개입력)이동시 속도가 더 빨라짐을 방지
            data.direction.Normalize();
            // 서버에서 도는 tick time. FixedUpdateNetwork환경에선 델타타임대신 러너델타타임 사용. 프레임간의 시간 보간
            _cc.Move(5 * data.direction * Runner.DeltaTime);

        }
    }

    private void Update()
    {
        // update는 리모트, 로컬 동시에 호출하기에 원치않은 결과가 발생하므로 다른 조건을 추가해줘야한다
        // Object.HasInputAuthority 조건추가
        if (Input.GetKeyDown(KeyCode.V) && Object.HasInputAuthority)
        {
            myByte = (byte)Random.Range(0, 255);
        }

        if (Object.HasInputAuthority && Input.GetKeyDown(KeyCode.R))
        {
            RPC_SendMessage("Hello Fusion!");
        }
    }

    //private Text _messages;

    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    public void RPC_SendMessage(string message, RpcInfo info = default)
    {
        //if (_messages == null)
        //    _messages = FindObjectOfType<Text>();
        if (info.Source == Runner.Simulation.LocalPlayer)
            message = $"You said: {message}\n";
        else
            message = $"Some other player said: {message}\n";
        FindObjectOfType<Text>().text += message;
    }
}
