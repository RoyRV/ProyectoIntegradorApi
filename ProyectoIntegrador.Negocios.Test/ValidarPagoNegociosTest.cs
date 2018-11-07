using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoIntegrador.Datos;
using Moq;
using ProyectoIntegrador.Modelos;

namespace ProyectoIntegrador.Negocios.Test
{
    [TestClass]
    public class ValidarPagoNegociosTest
    {
        //clase a testear
        ValidarPagoNegocios negocios;
        //clases para el constructor
        Mock<ITarjetaDatos> datos;
        
        [TestInitialize]
        public void Init() {
            negocios = new ValidarPagoNegocios();
            datos = new Mock<ITarjetaDatos>();
            negocios.tarjetaDatos = datos.Object;
        }

        [TestCleanup]
        public void Clean() {
            negocios = null;
            datos = null;
        }

        [TestMethod]
        public void ValidarPagoNegocios_TarjetaNula()
        {
            //esperado
            string mensajeEsperado = "Tarjeta no Existe";
            bool resultadoEsperado = false;
            //resultado
            string mensajeResultado = "";
            var resultado = negocios.ValidarPago(out mensajeResultado, 0, "", "", 0, "", "", "");
            //assert
            Assert.AreEqual(mensajeEsperado, mensajeResultado);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void ValidarPagoNegocios_TarjetaNoHabilitada()
        {
            //Stub 
            datos.Setup(x => x.ObtenerInformacionTarjeta(It.IsAny<int>(),
                                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                                 It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new TarjetaInfo { });
            //esperado
            string mensajeEsperado = "Tarjeta No Habilitada";
            bool resultadoEsperado = false;
            //resultado
            string mensajeResultado = "";
            var resultado = negocios.ValidarPago(out mensajeResultado, 0, "", "", 0, "", "", "");
            //assert
            Assert.AreEqual(mensajeEsperado, mensajeResultado);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void ValidarPagoNegocios_TarjetaSaldoInsuficiente()
        {
            //Stub 
            var tarjetaInfo = new TarjetaInfo
            {
                tarjetaHabilitada = true,
                creditoDisponible = 20
            };
            datos.Setup(x => x.ObtenerInformacionTarjeta(It.IsAny<int>(),
                                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                                 It.IsAny<string>(), It.IsAny<string>()))
                .Returns(tarjetaInfo);
            //esperado
            string mensajeEsperado = "Linea de credito insuficiente";
            bool resultadoEsperado = false;
            //resultado
            string mensajeResultado = "";
            var resultado = negocios.ValidarPago(out mensajeResultado, 0, "", "", 100, "", "", "");
            //assert
            Assert.AreEqual(mensajeEsperado, mensajeResultado);
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        public void ValidarPagoNegocios_TarjetaCorrecta()
        {
            //Stub 
            var tarjetaInfo = new TarjetaInfo
            {
                tarjetaHabilitada = true,
                creditoDisponible = 20
            };
            datos.Setup(x => x.ObtenerInformacionTarjeta(It.IsAny<int>(),
                                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                                 It.IsAny<string>(), It.IsAny<string>()))
                .Returns(tarjetaInfo);
            //esperado
            string mensajeEsperado = "";
            bool resultadoEsperado = true;
            //resultado
            string mensajeResultado = "";
            var resultado = negocios.ValidarPago(out mensajeResultado, 0, "", "", 10, "", "", "");
            //assert
            Assert.AreEqual(mensajeEsperado, mensajeResultado);
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
