using Chapter.Web.API.Controllers;
using Chapter.Web.API.Interfaces;
using Chapter.Web.API.Models;
using Chapter.Web.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteXunit.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void LoginController_RetornarUsuarioInvalido()
        {
            //Arrange
            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuarios)null);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email@emailcom";
            dadosUsuario.senha = "12345";

            var Controller = new LoginController(repositorioFalso.Object);
            //Act
            var resultado = Controller.Login(dadosUsuario);

            //Assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]

        public void LoginController_Retornar_Usuario()
        {
            //Arrange
            string issuerValidacao = "chapter.webAp";

            Usuarios usuarioFalso = new Usuarios();
            usuarioFalso.Email = "email@email.com";
            usuarioFalso.Senha ="12345";

            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioFalso);

            var controller = new LoginController(repositorioFalso.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email@email.com";
            dadosUsuario.senha="12345";

            //Act
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            var token = resultado.Value.ToString().Split(' ')[3];

            var jstHandler = new JwtSecurityTokenHandler();
            var jwtToken = jstHandler.ReadJwtToken(token);

            //Assert

            Assert.Equal(issuerValidacao, jwtToken.Issuer);
        }
    }
}