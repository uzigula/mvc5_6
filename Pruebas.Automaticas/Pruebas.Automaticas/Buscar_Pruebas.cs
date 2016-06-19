using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pruebas.Automaticas.Paginas;
using FluentAssertions;

namespace Pruebas.Automaticas
{
    [TestFixture]
    public class Buscar_Pruebas
    {
        private IWebDriver browser;

        [TestFixtureSetUp]
        public void ConfigurarBrowser()
        {
            browser = new ChromeDriver();
        }

        [TestFixtureTearDown]
        public void CerrarBrowser()
        {
            browser.Close();
            browser.Dispose();
        }

        [Test]
        public void BusquedaEventoJS_DevuelveUnResultado()
        {
            // Arrange -> Preparacion del Ambiente
            var paginaDeBusqueda = new PaginaDeBusqueda(browser);
            
            // Act  -> Ejecución de la Accion

            paginaDeBusqueda.Buscar("js");

            //Assert  ->  Verificacion

            int resultados = paginaDeBusqueda.Resultados.Count;

            Assert.AreEqual(1, 
                resultados, 
                "Solo debe Haber un Evento de JS");
        }

        [Test]
        public void InscribirmeAlEventoJavaScript()
        {
            var paginaDeBusqueda = new PaginaDeBusqueda(browser);

            paginaDeBusqueda.Buscar("Conferencia JS");

            paginaDeBusqueda.Resultados.Count.Should().Be(1, "Se encontro mas de un resultado para Conferencia JS");

            var dialogoInscripcion = paginaDeBusqueda.Resultados[0].Inscripcion();

            dialogoInscripcion.Titulo().Should().Be("Inscribirse a: Conferencia JS");

            dialogoInscripcion.InscribirA("Uzi");
            //

        }
    }
}
