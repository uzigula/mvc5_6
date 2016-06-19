using System;
using OpenQA.Selenium;
using Pruebas.Automaticas.Paginas.Paginas.Paginas;
using System.Threading;

namespace Pruebas.Automaticas.Paginas.Paginas
{
    internal class ResultadoBusqueda
    {
        private IWebDriver browser;
        private IWebElement resultado;

        public ResultadoBusqueda(IWebElement resultado, IWebDriver browser)
        {
            this.resultado = resultado;
            this.browser = browser;
        }

        public DialogoInscripcion Inscripcion()
        {
            var link = resultado.FindElement(By.CssSelector("div a[data-ajax='true']"));
            link.Click();
            Thread.Sleep(1000);
            return new DialogoInscripcion(browser);
        }
    }
}
 