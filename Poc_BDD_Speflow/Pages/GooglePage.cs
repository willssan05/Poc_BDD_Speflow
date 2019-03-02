using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poc_BDD_Speflow.Pages
{
    public class GooglePage
    {
        private readonly IWebDriver _webDriver;
        private IWebElement _inputNome;
        private IWebElement _inputSobrenome;
        private IWebElement _inputUsuario;
        private IWebElement _inputSenha;
        private IWebElement _inputConfirmarSenha;

        public GooglePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void PreencherNome(string nome)
        {
            _inputNome = _webDriver.FindElement(By.Id("firstName"));
            _inputNome.SendKeys(nome);
        }

        public void PreencherSobrenome(string sobrenome)
        {
            _inputSobrenome = _webDriver.FindElement(By.Id("lastName"));
            _inputSobrenome.SendKeys(sobrenome);
        }
        public void PreencherUsuario(string usuario)
        {
            _inputUsuario = _webDriver.FindElement(By.Id("username"));
            _inputUsuario.SendKeys(usuario);
        }

        public void PreencherSenha(string senha)
        {
            _inputSenha = _webDriver.FindElement(By.XPath("/ html / body / div[1] / div / div[2] / div[1] / div[2] / form / div[2] / div / div[1] / div[3] / div[1] / div[1] / div / div / div[1] / div / div[1] / input"));
            _inputSenha.SendKeys(senha);
        }

        public void PreencherConfirmarSenha(string confsenha)
        {
            _inputConfirmarSenha = _webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div[2]/form/div[2]/div/div[1]/div[3]/div[1]/div[3]/div/div/div[1]/div/div[1]/input"));
            _inputConfirmarSenha.SendKeys(confsenha);
        }

        public void ClickbtnProximo()
        {
            _webDriver.FindElement(By.XPath("/ html / body / div[1] / div / div[2] / div[1] / div[2] / form / div[2] / div / div[2] / div[1] / div / content / span")).Click();
        }
    }
}
