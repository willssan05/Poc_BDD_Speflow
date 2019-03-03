using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Poc_BDD_Speflow.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace Poc_BDD_Speflow.Steps
{
    [Binding]
    public class CadastroNoGoogleSteps
    {
        GooglePage _googlePage;
        IWebDriver Browser;
        public string screenshotsPasta;
        int contador = 1;
        private string url = "https://accounts.google.com/signup/v2/webcreateaccount?hl=pt-BR&flowName=GlifWebSignIn&flowEntry=SignUpxxx";

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
            this._googlePage = new GooglePage(Browser);
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

            _googlePage.PreencherNome(table.Rows[0][1]);
            _googlePage.PreencherSobrenome(table.Rows[1][1]);
            _googlePage.PreencherUsuario(table.Rows[2][1]);
            _googlePage.PreencherSenha(table.Rows[3][1]);
            _googlePage.PreencherConfirmarSenha(table.Rows[4][1]);

        }

        [When(@"prossigo para tela seguinte")]
        public void QuandoProssigoParaTelaSeguinte()
        {
            _googlePage.ClickbtnProximo();

        }

        [Then(@"é apresentada tela para informar o número de celular")]
        public void EntaoEApresentadaTelaParaInformarONumeroDeCelular()
        {
            Thread.Sleep(1000);
        }
    }
}
