using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class Test : MonoBehaviour, INetworkRunnerCallbacks
{
    // NetworkRunner�� ������ ȣ��Ʈ�� ���Ἲ��
    public void OnConnectedToServer(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    // ������ ȣ��Ʈ�� �������
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
        throw new NotImplementedException();
    }

    // NetworkRunner�� ����Ʈ Ŭ���̾�Ʈ�κ��� ���� ��û�� ����
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
        throw new NotImplementedException();
    }

    // ???
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
        throw new NotImplementedException();
    }

    // NetworkRunner�� ������ ȣ��Ʈ���� ������ ����
    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    // ???
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
        throw new NotImplementedException();
    }

    // Update���� ����
    // NetworkRunner�� ����� �Է��� �ν���
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
        throw new NotImplementedException();
    }

    // ����� �Է��� ����    ��) ����
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
        throw new NotImplementedException();
    }

    // NetworkRunner�� �����. ����(Runner)�� ������
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    // �������. Runner�� ����
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        throw new NotImplementedException();
    }

    // data receive???
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
        throw new NotImplementedException();
    }

    // �� �ε尡 �Ϸ�
    public void OnSceneLoadDone(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    // ���ε尡 ����
    public void OnSceneLoadStart(NetworkRunner runner)
    {
        throw new NotImplementedException();
    }

    // List�� �� �������� �����
    // ����(��)�� ������Ʈ��
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
        throw new NotImplementedException();
    }

    // ������ ������ Shutdown
    // NetworkRunner�� �˴ٿ��
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        throw new NotImplementedException();
    }

    // ����ƮŬ���̾�Ʈ�κ��� �������� ���޵� �޽����� ���ŵ�
    // �޽����� �������� ���� �� ���� ����
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
        throw new NotImplementedException();
    }

    
}
