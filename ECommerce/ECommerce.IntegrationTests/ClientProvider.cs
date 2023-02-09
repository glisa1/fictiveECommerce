using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.IntegrationTests
{
    public static class ClientProvider
    {
        public static HttpClient HttpClient
        {
            get
            {
                if (_client == null)
                    _client = GetHttpClient();

                return _client;
            }
        }

        private static HttpClient _client;
        private static HttpClient GetHttpClient()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            return webAppFactory.CreateDefaultClient();
        }
    }
}
