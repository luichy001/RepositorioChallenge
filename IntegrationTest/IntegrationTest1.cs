using AutoMapper;
using Backend.Me.Appservice;
using Backend.Me.Appservice.Interface;
using Backend.Me.Contracts;
using Backend.Me.Domain;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using Xunit;

namespace IntegrationTest
{
    public class IntegrationTest1
    {
        private IConfiguration _configuration;
        [Fact]
        public void Test1()
        {

            _configuration = InitConfiguration();
            
            Assert.NotNull(_configuration["ConnectionStrings:SQLConnection"]);

        }


        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
    }
}
