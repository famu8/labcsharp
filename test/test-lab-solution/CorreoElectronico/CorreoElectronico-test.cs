using Moq;
using test_lab;

namespace CorreoElectronico
{
        [TestClass]
        public class CorreoElectronicoTest
        {
            [TestMethod]
            public void ValidarCorreoElectronico_CorreoYaValidado_RetornaTrue()
            {
                // Arrange
                var mockCorreosValidados = new Mock<List<string>>();
                mockCorreosValidados.Setup(m => m.Contains("correo@ejemplo.com")).Returns(true);

                // Act
                var resultado = CorreoElectronico.ValidarCorreoElectronico("correo@ejemplo.com", mockCorreosValidados.Object);

                // Assert
                Assert.IsTrue(resultado);
            }

            [TestMethod]
            public void ValidarCorreoElectronico_CorreoNoValidado_RetornaFalse()
            {
                // Arrange
                var mockCorreosValidados = new Mock<List<string>>();
                mockCorreosValidados.Setup(m => m.Contains("correo@ejemplo.com")).Returns(false);

                // Act
                var resultado = CorreoElectronico.ValidarCorreoElectronico("correo@ejemplo.com", mockCorreosValidados.Object);

                // Assert
                Assert.IsFalse(resultado);
            }

            [TestMethod]
            public void ValidarCorreoElectronico_CorreoValido_AgregaCorreoALaLista()
            {
                // Arrange
                var mockCorreosValidados = new Mock<List<string>>();
                mockCorreosValidados.Setup(m => m.Contains("correo@ejemplo.com")).Returns(false);

                // Act
                var resultado = CorreoElectronico.ValidarCorreoElectronico("correo@ejemplo.com", mockCorreosValidados.Object);

                // Assert
                Assert.IsTrue(resultado);
                mockCorreosValidados.Verify(m => m.Add("correo@ejemplo.com"), Times.Once);
            }
        }

}