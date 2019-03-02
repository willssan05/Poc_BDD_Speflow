using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;

namespace Poc_BDD_Speflow.Steps
{
    [Binding]
    public class CadastroNoGoogleSteps
    {
        IWebDriver Browser;
        public string screenshotsPasta;
        int contador = 1;
        private string url = "https://accounts.google.com/signup/v2/webcreateaccount?hl=pt-BR&flowName=GlifWebSignIn&flowEntry=SignUp";

        public void Screenshot(IWebDriver Browser, string screenshotsPasta)
        {
            ITakesScreenshot camera = Browser as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();
            screenshotsPasta = @"C:\Users\will_\OneDrive\Documentos\Visual Studio 2017\Desenvolvimento\Poc_BDD_Speflow\Poc_BDD_Speflow\Evidencias\";
        }

        [AfterScenario]
        public void capturaImagem()
        {
            Screenshot(Browser, screenshotsPasta + "Cenario_" + contador++ + ".png");
            Thread.Sleep(500);
        }

        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"que eu acesse a página de cadastro do Google")]
        public void DadoQueEuAcesseAPaginaDeCadastroDoGoogle()
        {
            this.Browser.Navigate().GoToUrl(url);
            capturaImagem();
        }

        [When(@"preencho os dados para criar um usuário novo")]
        public void QuandoPreenchoOsDadosParaCriarUmUsuarioNovo(Table table)
        {
            var nome = this.Browser.FindElement(By.Id("firstName"));
            nome.SendKeys("Wilson");

            var sobrenome = this.Browser.FindElement(By.Id("lastName"));
            sobrenome.SendKeys("Barboza");

            var usuario = this.Browser.FindElement(By.Id("username"));
            usuario.SendKeys("wilsonbarboza12345678901");

            var senha = this.Browser.FindElement(By.XPath("/ html / body / div[1] / div / div[2] / div[1] / div[2] / form / div[2] / div / div[1] / div[3] / div[1] / div[1] / div / div / div[1] / div / div[1] / input"));
            senha.SendKeys("Teste@123");

            var confsenha = this.Browser.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[1]/div[2]/form/div[2]/div/div[1]/div[3]/div[1]/div[3]/div/div/div[1]/div/div[1]/input"));
            confsenha.SendKeys("Teste@123");

        }

        [When(@"prossigo para tela seguinte")]
        public void QuandoProssigoParaTelaSeguinte()
        {

            var btnProximo = this.Browser.FindElement(By.XPath("/ html / body / div[1] / div / div[2] / div[1] / div[2] / form / div[2] / div / div[2] / div[1] / div / content / span"));
            btnProximo.Click();

        }

        [Then(@"é apresentada tela para informar o número de celular")]
        public void EntaoEApresentadaTelaParaInformarONumeroDeCelular()
        {
            Thread.Sleep(1000);
        }
    }
}
