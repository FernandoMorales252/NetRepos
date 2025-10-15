using AuthApi.Entidades;
using AuthApi.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApi.TestXUnit
{
    public class UsuarioRepositoryTest
    {
        private AppDbContext GetInMemoryDbContext()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{System.Guid.NewGuid()}").Options;

            var context = new AppDbContext(options);

            context.Roles.Add(
                new Entidades.Rol 
                { Id = 1, 
                  Nombre = "Admin" 
                });

            context.Usuarios.Add(
                new Entidades.Usuarios 
                { Id = 2, 
                  Nombre = "Fernando" ,
                  Email = "Fernando@123", 
                  Password ="123" ,
                  RolId= 1
                });

            context.SaveChanges();
            return context;

 
        }

        [Fact]
        public async Task GetByEmaiLAsync_ReturnUser()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            //Act
            var usuario = await repo.GetByEmailAsync("Fernando@123");

            //Assert
            Assert.NotNull(usuario);
            Assert.Equal("Fernando",  usuario.Nombre);
            Assert.Equal("Admin", usuario.Rol.Nombre);
        }

        [Fact]
        public async Task AddAsync_AddUser()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            var nuevousuario = new Usuarios()
            {
                Nombre = "Maria",
                Email = "Maria@gmail.com",
                Password = "123",
                RolId = 1

            };

            //Act
            await repo.AddAsync(nuevousuario);
            //Assert
            var usuarioGuardado = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == "Maria@gmail.com");
            Assert.NotNull(usuarioGuardado);
            Assert.Equal("Maria", usuarioGuardado.Nombre);
        }

        [Fact]
        public async Task GetAllAsync_AllUserReturn()
        {
            //Arrange
            var context = GetInMemoryDbContext();
            var repo = new UsuarioRepository(context);

            //Act
            var lista = await repo.GetAllUsuariosAsync(); 

            //Assert
            Assert.NotEmpty(lista);
            Assert.Contains(lista,u=> u.Email == "Fernando@123");
        }

    }
}
