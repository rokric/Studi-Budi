﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    public class Server
    {
        public Hashtable clientsList = new Hashtable();
        private List<PairTalk> pairs = new List<PairTalk>();

        public Server()
        {

        }

        public void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();

            Console.WriteLine("Chat Server Started ....");

            TcpClient clientSocket;

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                clientSocket.ReceiveBufferSize = 4096;

                byte[] bytesFrom = new byte[4096];

                //when client connects to server he sends:
                // -his username
                // -person username that he wants to chat with
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);

                string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                string[] data = dataFromClient.Split(':');

                clientsList.Add(data[0], clientSocket);

                if (!data[1].Equals(""))
                {
                    UpdatePairTalk(data[0], data[1]);
                }

                PairTalk pair = CheckIfPairExist();

                if (pair != null)
                {

                    PairHandler pairHandler = new PairHandler(
                        (TcpClient)clientsList[pair.ClientName1], pair.ClientName1,
                        (TcpClient)clientsList[pair.ClientName2], pair.ClientName2);
                    BroadcastOldChat(pairHandler.OldChatHistory, pairHandler.Client1, pairHandler.Client2);

                    clientsList.Remove(pair.ClientName1);
                    clientsList.Remove(pair.ClientName2);
                    pairs.Remove(pair);

                    Console.WriteLine("Conversation started between " + pair.ClientName1 + " and " + pair.ClientName2);
                    NotifyThatConversationStarted(pairHandler);
                }
            }
        }

        private PairTalk CheckIfPairExist()
        {
            List<string> names = new List<string>();
            PairTalk pair = null;

            foreach (DictionaryEntry item in clientsList)
            {
                names.Add(item.Key.ToString());
            }

            foreach (PairTalk pairTalk in pairs)
            {
                if (names.Contains(pairTalk.ClientName1) && names.Contains(pairTalk.ClientName2))
                {
                    pair = pairTalk;
                    pairs.Remove(pairTalk);
                    break;
                }
            }

            return pair;
        }

        private void NotifyThatConversationStarted(PairHandler pair)
        {
            string message = "Conversation started between " + pair.ClientName1 + " and " + pair.ClientName2;
            BroadcastMessage(pair.Client1, message);
            BroadcastMessage(pair.Client2, message);

        }

        private void BroadcastMessage(TcpClient tcpClient, string message)
        {
            NetworkStream broadcastStream = tcpClient.GetStream();
            byte[] broadcastBytes = Encoding.ASCII.GetBytes(message);
            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
            broadcastStream.Flush();
        }

        private void UpdatePairTalk(string client1, string client2)
        {
            PairTalk pair = new PairTalk(client1, client2);
            bool alreadyExist = false;
            foreach(PairTalk pairTalk in pairs)
            {
                if(pair.Equals(pairTalk))
                {
                    alreadyExist = true;
                    break;
                }
            }

            if (!alreadyExist)
            {
                pairs.Add(new PairTalk(client1, client2));
            }
        }

        public static void Broadcast(string message, string userName, TcpClient client1, TcpClient client2)
        {

            List<TcpClient> pair = new List<TcpClient>();
            pair.Add(client1);
            pair.Add(client2);

            foreach (TcpClient tcpClient in pair)
            {
                NetworkStream broadcastStream = tcpClient.GetStream();
                byte[] broadcastBytes = null;
                broadcastBytes = Encoding.ASCII.GetBytes(userName + " : " + message);
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }

        public void BroadcastOldChat(List<string> messages, TcpClient client1, TcpClient client2)
        {
            foreach(string message in messages)
            {
                BroadcastMessage(client1, message);
                BroadcastMessage(client2, message);
                Thread.Sleep(10); //without it messages are printed without breaklines
            }
        }
    }
}
