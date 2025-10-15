using AuthApi.DTOs.UsuariosDTOs;
using AuthApi.Entidades;
using AuthApi.Interfaces;
using AuthApi.Repositorios;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.TestXUnit
{
    public class AuthRepositoryTest
    {
        private IConfiguration GetTestConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                { "Jwt:key", "11111111111111111111111111111111111"},
                { "Jwt:Issuer", "AuthApiTest"},
                {"Jwt:Audience", "AuthClients" },
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

        }

        [Fact]
        public async Task RegistrarAsync_LoginWithTokenReturn()
        {
            //Arrange
            var mockRepo = new Mock<IUsuarioRepository>();
            var config = GetTestConfiguration();
            var usuario = new Usuarios
            {
                Id = 1,
                Nombre = "Fernando",
                Email = "FernandoMorales@gmail.com",
                Password = "hash",
                Rol = new Rol { Id = 2, Nombre = "Usuario" }
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Usuarios>())).ReturnsAsync(usuario);
            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(usuario);

            var services = new AuthRepository(mockRepo.Object, config);

            var registroDTO = new UsuarioRegistroDTO
            {
                Nombre = "Fernando",
                Email = "Fer1@Gmail.com",
                Password = "123",
            };

            //Act
            var result = await services.RegistrarAsync(registroDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Fernando", result.Nombre);
            Assert.Equal("Fer1@Gmail.com", result.Email);
            Assert.False(string.IsNullOrEmpty(result.Token));

        }

        [Fact]
        public async Task LoginAsync_LoginReturnNullIfUserDoesNotExist()
        {
            //Average
            var mockRepo = new Mock<IUsuarioRepository>();
            var config = GetTestConfiguration();

            mockRepo.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((Usuarios?)null);
            var service = new AuthRepository(mockRepo.Object, config);

            var loginDTo = new UsuarioLoginDTO
            {
                Email = "FernandoFake@Gmail.com",
                Password = "123",
            };

            //Act
            var result = service.LoginAsync(loginDTo);

            // Assert
            Assert.NotNull(result);

        }
    }
}

