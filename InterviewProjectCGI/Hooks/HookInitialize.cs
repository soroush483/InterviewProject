using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Io.Cucumber.Messages;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace InterviewProjectCGI.Hooks
{
    [Binding]
    public sealed class HookInitialize
    {
        
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        private ScenarioContext _scenarioContext;
        public HookInitialize()=>_scenarioContext = ScenarioContext.Current;
        //public RemoteWebDriver Driver { get; set; }
        //public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        //{
        //    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
        //    return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,Name).Build();
        //}
        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Soroush\Desktop\InterviewCGI\InterviewProjectCGI\InterviewProjectCGI\Report.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]

        public static void TearDownReport()
        {
            extent.Flush();
        }

        [BeforeFeature]

        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        
        [AfterStep]
        
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                //ScreenShot
                //MediaEntityModelProvider mediaEntity = CaptureScreenshotAndReturnModel("Failedddddd");
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]

        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        
    }

    
}
