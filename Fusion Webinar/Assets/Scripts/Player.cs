using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;

public class Player : NetworkBehaviour
{
    // ��Ʈ��ũ����ȭ�� ���ؼ� int��� int32�����

    // [Networked] // <- ��Ʈ��ũ�� ����ȭ �Ǵ� ����

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

    // �������� FixedUpdate�� ��Ȯ�� ����
    // Ŭ���̾�Ʈ�� �������� �޾ƿ� fixedupdate�� ȣ����
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            // ���������� ��������ȭ ���Ѽ� �밢������(���ÿ� Ű 2���Է�)�̵��� �ӵ��� �� �������� ����
            data.direction.Normalize();
            // �������� ���� tick time. FixedUpdateNetworkȯ�濡�� ��ŸŸ�Ӵ�� ���ʵ�ŸŸ�� ���. �����Ӱ��� �ð� ����
            _cc.Move(5 * data.direction * Runner.DeltaTime);

        }
    }

    private void Update()
    {
        // update�� ����Ʈ, ���� ���ÿ� ȣ���ϱ⿡ ��ġ���� ����� �߻��ϹǷ� �ٸ� ������ �߰�������Ѵ�
        // Object.HasInputAuthority �����߰�
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
