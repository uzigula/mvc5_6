using System;
using OpenQA.Selenium;
using System.Threading;

namespace Pruebas.Automaticas.Paginas.Paginas.Paginas
{
    internal class DialogoInscripcion
    {
        private IWebDriver browser;
        private IWebElement dialogo;

        public DialogoInscripcion(IWebDriver browser)
        {
            this.browser = browser;
            dialogo = browser.FindElement(By.ClassName("modal-dialog"));
        }

        public string Titulo()
        {
            return dialogo.FindElement(By.ClassName("modal-title")).Text;
        }

        public void InscribirA(string usuario)
        {
            dialogo.FindElement(By.Name("Nombre")).SendKeys(usuario);
            Thread.Sleep(500);
            dialogo.FindElement(By.ClassName("btn-success")).Click();
        }
    }
}