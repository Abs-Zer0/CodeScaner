﻿using CodeScaner.Model;
using CodeScaner.Model.Requests;
using CodeScaner.Model.Responses;
using CodeScaner.Model.Settings;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CodeScaner.Service.Server
{
    public class ProtobufServer : IProtobufServer
    {

        public async Task ChangeStatusAsync(string barcode, Status newStatus, string description)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient();

                ServerUrl urlPort = Services.Settings.GetUrlPort(new ServerUrl());
                await client.ConnectAsync(urlPort.Url, int.Parse(urlPort.Port));

                client.GetStream().WriteTimeout = Constants.DEFAULT_TIMEOUT;
                Person person = Services.Settings.GetPerson(new Person());
                ServerRequest request = new ServerRequest(person.Login, person.Password, barcode, newStatus, description);
                Serializer.Serialize(client.GetStream(), request);

                client.GetStream().ReadTimeout = Constants.DEFAULT_TIMEOUT;
                ServerResponse response = Serializer.Deserialize<ServerResponse>(client.GetStream());

                if (response.Type == ResponseType.SIGN_IN_ERROR)
                    throw new Exception("Не найден пользователь с такими логином и паролем");

                if (response.Type == ResponseType.ALREADY_SETTED)
                    throw new Exception("Вы не можете изменить статус не этот");

                if (response.Type == ResponseType.ERROR)
                    throw new Exception(response.Description);
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            finally
            {
                if (client != null)
                {
                    client.GetStream().Close();
                    client.Close();
                }
            }
        }

        public async Task SignInAsync(string login, string password)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient();

                ServerUrl urlPort = Services.Settings.GetUrlPort(new ServerUrl());
                await client.ConnectAsync(urlPort.Url, int.Parse(urlPort.Port));

                client.GetStream().WriteTimeout = Constants.DEFAULT_TIMEOUT;
                ServerRequest request = new ServerRequest(login, password);
                Serializer.Serialize(client.GetStream(), request);

                client.GetStream().ReadTimeout = Constants.DEFAULT_TIMEOUT;
                ServerResponse response = Serializer.Deserialize<ServerResponse>(client.GetStream());

                if (response.Type == ResponseType.SIGN_IN_ERROR)
                    throw new Exception("Не найден пользователь с такими логином и паролем");

                if (response.Type == ResponseType.ERROR)
                    throw new Exception(response.Description);
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            finally
            {
                if (client != null)
                {
                    client.GetStream().Close();
                    client.Close();
                }
            }
        }
    }
}