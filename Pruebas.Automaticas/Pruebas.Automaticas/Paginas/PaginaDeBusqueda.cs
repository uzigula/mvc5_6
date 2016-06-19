using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pruebas.Automaticas.Paginas.Paginas;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Pruebas.Automaticas.Paginas
{
    internal class PaginaDeBusqueda
    {
        private IWebDriver browser;
        public PaginaDeBusqueda(IWebDriver browser)
        {
            Resultados = new List<ResultadoBusqueda>();
            this.browser = browser;
            this.browser
                .Navigate()
                .GoToUrl("http://192.168.15.10/YoVoy/Buscar");
            Thread.Sleep(1000);
        }

        public List<ResultadoBusqueda> Resultados { get; private set; }

        internal void Buscar(string terminoBusqueda)
        {
            browser.FindElement(By.Name("Busqueda"))
                .SendKeys(terminoBusqueda);

            browser.FindElement(By.ClassName("btn-success"))
                .Click();
            Thread.Sleep(1000);
            LlenarResultados();
        }

        private void LlenarResultados()
        {
            var resultados = browser.FindElements(By.CssSelector("div[class='well'"));

            foreach(var resultado in resultados)
            {
                Resultados.Add(new ResultadoBusqueda(resultado, browser));
            }
        }
    }
}