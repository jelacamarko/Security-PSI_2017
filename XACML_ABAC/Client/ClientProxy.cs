﻿using Contracts;
using System;
using System.ServiceModel;

namespace Client
{
    public class ClientProxy : DuplexChannelFactory<IContract>, IContract, IDisposable
    {
        private IContract factory;

        public ClientProxy(NetTcpBinding binding, EndpointAddress address)
            : base(new InstanceContext(new LocationService()), binding, address)
        {
            factory = CreateChannel();
        }

        public string AccessDenied()
        {
            try
            {
                return factory.AccessDenied();
            }
            catch (Exception e)
            {
                Console.WriteLine("Proxy error. Message: {0}", e.Message);
                return null;
            }
        }

        public string AccessPermit()
        {
            try
            {
                return factory.AccessPermit();
            }
            catch (Exception e)
            {
                Console.WriteLine("Proxy error. Message: {0}", e.Message);
                return null;
            }
        }

        public string ExamRegistration()
        {
            try
            {
                return factory.ExamRegistration();
            }
            catch (Exception e)
            {
                Console.WriteLine("Proxy error. Message: {0}", e.Message);
                return null;
            }
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }

            this.Close();
        }
    }
}