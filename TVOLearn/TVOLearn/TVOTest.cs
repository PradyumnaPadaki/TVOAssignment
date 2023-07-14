using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TVOLearnTests
{
    [TestFixture]
    public class TVOLearnTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Set up Chrome driver
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();

            //Navigate to TVO Learn webpage
            driver.Navigate().GoToUrl("https://tvolearn.com/");

        }

        [Test]
        public void TestNavigationToElementaryDropdown()
        {

            // Click on Elementary (K-8) dropdown
            IWebElement elementaryDropdown = driver.FindElement(By.XPath("//*[@id='SiteNav']/li[1]/button"));
            elementaryDropdown.Click();
            Thread.Sleep(1000);

            // Dropdown Display
            IWebElement dropdownMenu = driver.FindElement(By.ClassName("site-nav__dropdown--left"));
            Thread.Sleep(1000);

            // Assert that the dropdown menu is displayed
            Assert.That(dropdownMenu.Displayed, Is.True);

        }

        [Test]
        public void TestSelectionOfGrade()
        {
            //Grade to be selected
            string grade = "Grade 1";

            // Click on Elementary (K-8) dropdown
            IWebElement elementaryDropdown = driver.FindElement(By.XPath("//*[@id='SiteNav']/li[1]/button"));
            elementaryDropdown.Click();
            Thread.Sleep(1000);

            // Select Grade from the dropdown menu
            IWebElement gradeOption = driver.FindElement(By.LinkText(grade));
            Thread.Sleep(1000);
            gradeOption.Click();

            // Selected Grade page display
            IWebElement gradeDisplayed = driver.FindElement(By.XPath("//*[@id='s-7a1fb153-c696-4afe-bb5e-b1b8a4c85222']/ol/li[2]"));
            Thread.Sleep(1000);

            // Validate that the URL contains Grade-1
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("grade-1"), Is.True);

            // Assert that Grade is displayed
            Assert.That(gradeDisplayed.Displayed, Is.True);

        }

        [Test]
        public void TestScrollToCurriculumSection()
        {
            // Click on Elementary (K-8) dropdown
            IWebElement elementaryDropdown = driver.FindElement(By.XPath("//*[@id='SiteNav']/li[1]/button"));
            elementaryDropdown.Click();
            Thread.Sleep(1000);

            // Select Grade from the dropdown menu
            IWebElement gradeOption = driver.FindElement(By.XPath("//*[@id='SiteNavLabel-elementary-k-8']/ul/li[2]/a"));
            gradeOption.Click();
            Thread.Sleep(1000);

            // Scroll to "Learn Forward in the Curriculum" section
            IWebElement learnForwardSection = driver.FindElement(By.XPath("//*[@id='s-491edbc4-74e8-4f5d-98a0-eb3c84f985cc']/div"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", learnForwardSection);
            Thread.Sleep(1000);

            // Assert that the section is in the viewport
            Assert.That(learnForwardSection.Displayed, Is.True);
        }

        [Test]
        public void TestClickOnCard()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Assert that the clicked card leads to the expected page
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("grade-1-mathematics"), Is.True); 

        }

        [Test]
        public void TestSearchBoxFunctionality()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Click on Search option
            IWebElement searchButton = driver.FindElement(By.XPath("//*[@id='SiteNav']/li[6]/button"));
            searchButton.Click();
            Thread.Sleep(1000);

            // Display search box in viewport
            IWebElement search = driver.FindElement(By.XPath("//*[@id='SearchDrawer']/div/div[1]/form/input[1]"));
            IWebElement searchBox = search;
            Thread.Sleep(1000);

            // Assert search box is in viewport
            Assert.That(searchBox.Displayed, Is.True);

            // Enter text to search in search box
            string textToSearch = "youtube";
            searchBox.SendKeys(textToSearch);
            Thread.Sleep(1000);
            searchBox.SendKeys(Keys.Enter);

            // Search results display
            IWebElement webElement = driver.FindElement(By.XPath("//*[@id='MainContent']/div[2]/h1/span[1]"));
            IWebElement searchResults = webElement;
            Thread.Sleep(1000);

            // Assert search results is in viewport
            Assert.That(searchResults.Displayed, Is.True);
        }

        [Test]
        public void TestLearningActivities()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to "Learning Activities" section
            IWebElement learningActivities = driver.FindElement(By.XPath("//*[@id='strandsTop']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", learningActivities);
            Thread.Sleep(1000);

            // Selection of topic "Number" for learning
            IWebElement topic = driver.FindElement(By.XPath("//*[@id='tab0']/button"));
            topic.Click();

            // Display topic details
            IWebElement topicDetails = driver.FindElement(By.XPath("//*[@id='strandsTop']/div[2]/p[1]"));
            IWebElement details = topicDetails;
            Thread.Sleep(1000);

            // Assert topic details are displayed
            Assert.That(details.Displayed, Is.True);

            // Display associated learning activities for topic Number
            IWebElement numberActivities = driver.FindElement(By.XPath("//*[@id='tab0']/div"));
            IWebElement activities = numberActivities;
            Thread.Sleep(1000);

            // Assert associated learning activities for topic Number are displayed
            Assert.That(activities.Displayed, Is.True);

            // Selection of learning activity 1
            IWebElement learningActivity1 = driver.FindElement(By.XPath("//*[@id='tab0']/div/div/div[1]/a"));
            learningActivity1.Click();
            Thread.Sleep(1000);

            // Validate that the URL contains grade-1-mathematics-number-learning-activity-1
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("grade-1-mathematics-number-learning-activity-1"), Is.True);

            // Display of Learning Activity 1 page
            IWebElement numberLearningActivity = driver.FindElement(By.XPath("//*[@id='MainContent']/div/div[2]/div"));
            IWebElement result = numberLearningActivity;

            // Assert that Grade is displayed
            Assert.That(result.Displayed, Is.True);
        }

        [Test]
        public void TestResourcesForLearning()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to "Resources for Learning" section
            IWebElement resourcesForLearning = driver.FindElement(By.XPath("//*[@id='resources']/li[2]/a/div[2]/p[2]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", resourcesForLearning);
            Thread.Sleep(1000);

            // Selection of resource : Coding Secret Code
            IWebElement resource2 = driver.FindElement(By.XPath("//*[@id='resources']/li[2]/a"));
            resource2.Click();
            Thread.Sleep(6000);

            // Navigated to resource page : TVO Kids
            IWebElement resourceTvoKids = driver.FindElement(By.XPath("//*[@id='logo-link']/img"));
            IWebElement resource = resourceTvoKids;
            Thread.Sleep(1000);

            // Assert TVO Kids details are displayed
            Assert.That(resource.Displayed, Is.True);

            // Validate that the URL contains coding/secret-code
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("coding/secret-code"), Is.True);
        }

        [Test]
        public void TestForChangingSubject()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to "Looking for a Different Subject" section
            IWebElement differentSubject = driver.FindElement(By.XPath("//*[@id='s-b58ad40a-8ef5-46be-ad12-d2d8edfc3de7']/div/h2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", differentSubject);
            Thread.Sleep(1000);

            // Selection of different subject
            IWebElement scienceAndTechnology = driver.FindElement(By.XPath("//*[@id='s-5cf1e8dd-c678-4464-8751-efe6407a10bb']/div[1]"));
            scienceAndTechnology.Click();
            Thread.Sleep(1000);

            // Navigated to subject page :  Science & Technology
            IWebElement scienceAndTechPage = driver.FindElement(By.XPath("//*[@id='s-e235c8ce-c10f-42b3-b324-32da5f7e97f5']/div/h2"));
            IWebElement subject = scienceAndTechPage;
            Thread.Sleep(1000);

            // Assert Grade 1 Science & Technology page is displayed
            Assert.That(subject.Displayed, Is.True);

            // Validate that the URL contains grade-1-science-and-technology
            string currentUrl = driver.Url;
            Assert.That(currentUrl.Contains("grade-1-science-and-technology"), Is.True);
        }

        [Test]
        public void TestForSubscriptionVerificationWithValidEmailId()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to Stay Connected section
            IWebElement stayConnected = driver.FindElement(By.XPath("//*[@id='mc_embed_signup']/div/div/h2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", stayConnected);
            Thread.Sleep(1000);

            // Enter valid email ID 
            IWebElement subscribe = driver.FindElement(By.XPath("//*[@id='mce-EMAIL']"));
            subscribe.SendKeys("tvolearning_test@gmail.com");
            subscribe.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            // Verify the Subscription response message for valid email id
            IWebElement subscriptionResponse = driver.FindElement(By.XPath("//*[@id='mce-success-response']"));
            IWebElement response = subscriptionResponse;
            Thread.Sleep(1000);

            // Assert Subscription response message is displayed
            Assert.That(response.Displayed, Is.True);
        }

        [Test]
        public void TestForSubscriptionVerificationWithInvalidEmailId()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to Stay Connected section
            IWebElement stayConnected = driver.FindElement(By.XPath("//*[@id='mc_embed_signup']/div/div/h2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", stayConnected);
            Thread.Sleep(1000);

            // Enter invalid email ID 
            IWebElement subscribe = driver.FindElement(By.XPath("//*[@id='mce-EMAIL']"));
            subscribe.SendKeys("tvolearning_test");
            subscribe.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            // Verify the Subscription response message for invalid email id
            IWebElement subscriptionResponse = driver.FindElement(By.XPath("//*[@id='mc_embed_signup_scroll']/div/div"));
            IWebElement response = subscriptionResponse;
            Thread.Sleep(1000);

            // Assert invalid email response message is displayed
            Assert.That(response.Displayed, Is.True);
        }

        [Test]
        public void TestForSubscriptionVerificationWithNoEmailId()
        {
            NavigateToMathematicsGrade1("Grade 1", "Mathematics");

            // Scroll to Stay Connected section
            IWebElement stayConnected = driver.FindElement(By.XPath("//*[@id='mc_embed_signup']/div/div/h2"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", stayConnected);
            Thread.Sleep(1000);

            // Do not enter the email id 
            IWebElement subscribe = driver.FindElement(By.XPath("//*[@id='mce-EMAIL']"));
            subscribe.SendKeys("");
            subscribe.SendKeys(Keys.Enter);
            Thread.Sleep(1000);

            // Verify the Subscription response message for no email id
            IWebElement subscriptionResponse = driver.FindElement(By.XPath("//*[@id='mc_embed_signup_scroll']/div/div"));
            IWebElement response = subscriptionResponse;
            Thread.Sleep(1000);

            // Assert email id required response message is displayed
            Assert.That(response.Displayed, Is.True);
        }

        [TearDown]
        public void Cleanup()
        {
            // Quit the driver and close the browser
            driver.Quit();
        }

        private void NavigateToMathematicsGrade1(string grade, string card)
        {

            // Click on Elementary (K-8) dropdown
            IWebElement elementaryDropdown = driver.FindElement(By.XPath("//*[@id='SiteNav']/li[1]/button"));
            elementaryDropdown.Click();
            Thread.Sleep(1000);

            // Select Grade 1 from the dropdown menu
            IWebElement gradeOption = driver.FindElement(By.XPath("//*[@id='SiteNavLabel-elementary-k-8']/ul/li[2]/a"));
            gradeOption.Click();
            Thread.Sleep(1000);

            // Scroll to "Learn Forward in the Curriculum" section
            IWebElement learnForwardSection = driver.FindElement(By.XPath("//*[@id='s-491edbc4-74e8-4f5d-98a0-eb3c84f985cc']/div"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", learnForwardSection);
            Thread.Sleep(1000);

            // Click on a card in the section
            IWebElement cardSelected = driver.FindElement(By.XPath("//*[@id='s-f9924085-cdf6-409f-b476-67d7c5a74702']/div[1]"));
            cardSelected.Click();
            Thread.Sleep(1000);
        }

    }
}
