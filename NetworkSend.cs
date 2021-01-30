using System;
using KaymakNetwork;

namespace NewServer
{
    enum ServerPackets
    {
        SWelcomeMsg = 1,
    }

    internal static class NetworkSend
    {
        public static void WelcomeMsg(int connectionID, string msg)
        {
            ByteBuffer buffer = new ByteBuffer(4);
            buffer.WriteInt32((int)ServerPackets.SWelcomeMsg);
            buffer.WriteString(msg);
            NetworkConfig.socket.SendDataTo(connectionID, buffer.Data, buffer.Head);

            buffer.Dispose();
        }
    }
}
