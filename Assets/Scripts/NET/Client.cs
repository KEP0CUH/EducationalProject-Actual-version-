using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class Client
{
    private Socket client = null;
    private IPAddress ip;
    private int port;
    public Client(int port = 29988)
    {
        this.ip = GetIP();
        Debug.Log(ip);
        this.port = port;
    }

    public bool Connect()
    {
        try
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ip, port);
            return true;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
            return false;
        }
    }

    public void SendResponse(string message)
    {
        if (client != null)
        {

            StringBuilder sb = new StringBuilder();

            string response = message;
            byte[] data = Encoding.Unicode.GetBytes(response);
            client.Send(data);

            data = new byte[256];
            int readBytes = 8;

            do
            {
                readBytes = client.Receive(data);
                sb.Append(Encoding.Unicode.GetString(data, 0, readBytes));
            }
            while (client.Available > 0);

            Debug.Log("Сервер получил ответ: " + sb.ToString());

        }
    }

    private IPAddress GetIP()
    {
        var allIps = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
        foreach (var ip in allIps)
        {
            if (ip.ToString().Contains("192.168.0."))
            {
                return ip;
            }
        }
        return null;
    }
}
