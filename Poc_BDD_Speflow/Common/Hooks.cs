using System;
using System.Drawing.Imaging;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Poc_BDD_Speflow.ExtensionMethods;
using TechTalk.SpecFlow;
namespace Poc_BDD_Speflow.Common
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest _feature; // nodo para a Feature
        private static ExtentTest _scenario; // nodo para o Scenario
        private static ExtentReports _extent; // objeto do ExtentReports que será criado


        // aqui estou salvando na pasta bin/debug do projeto, o arquivo de relatório chamado ExtentReportAmazon.html
        private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentReportGoogle.html";

        [BeforeTestRun]
        public static void ConfigureReport()
        {
            // aqui informo o caminho do arquivo que será gerado criando um objeto ExtentHtmlReporter
            var reporter = new ExtentHtmlReporter(PathReport);

            // instancio o objeto ExtentReports
            _extent = new ExtentReports();

            // aqui dou attach no ExtentHtmlReporter
            _extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void CreateFeature()
        {
            // antes de iniciar uma Feature, crie o meu novo de Feature
            // o SpecFlow permite pegar o nome da Feature usando o FeatureContext
            // se não permitisse teríamos que adicionar o nome da nossa feature
            _feature = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public static void CreateScenario()
        {
            // antes de iniciar um cenário, crie o meu nodo de Scenario
            _scenario = _feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            // aqui vou verificar o tipo de passos que nosso teste automatizado terá
            // por padrão temos o 3 principais: Given, When e Then que podem ser acompanhados de And
            switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
            {
                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                    _scenario.StepDefinitionGiven(); // extension method
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                    _scenario.StepDefinitionThen(); // extension method
                    break;

                case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                    _scenario.StepDefinitionWhen(); // extension method
                    break;
            }
        }

        [AfterTestRun]
        public static void FlushExtent()
        {
            // depois de rodar os testes, finalize o objeto do ExtentReports
            // essa função destrói o objeto e cria o arquivo html
            _extent.Flush();
        
        }

    }
}
