using ObjectiveTestExercise.Context;
using ObjectiveTestExercise.Context.Models;
using ObjectiveTestExercise.Models;
using ObjectiveTestExercise.Services.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ObjectiveTestExercise.Services
{
    /// <summary>
    /// Работа с подписками на рассылки
    /// </summary>
    public class SubscribeService : ISubscribeService
    {
        private readonly ObjectiveContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebDriver _driver;

        public SubscribeService(ObjectiveContext context, IConfiguration configuration)
        {
            _driver = new ChromeDriver();
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Добавление подписки на рассылку
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSubscribe(AddSubscribeModel model)
        {
            Subscribe subscribe = new Subscribe() { Url = model.Url, Email = model.Email, Visible = true};

            if (!ValidateSubscribeModel(subscribe))
            return false;

            _context.Add(subscribe); 

            return _context.SaveChanges() > 0;
        }

        public async Task<IEnumerable<ActualPriceModel>> GetPricesAndUrls()
        {
            string selector = _configuration.GetValue<string>("ClassNames:Price");

            List<ActualPriceModel> models = _context.Subscribes
                .Where(x => x.Visible == true)
                .Select(x => new ActualPriceModel { Url = x.Url })
                .ToList();

            foreach (ActualPriceModel model in models)
            {
                try
                {
                    _driver.Navigate().GoToUrl(model.Url);
                    IWebElement element = _driver.FindElement(By.Id(selector));
                    string price = element.GetAttribute("value");

                    model.Price = Convert.ToUInt32(price);
                }
                catch
                {
                    continue;
                }
            }

            _driver.Quit();
            return models;
        }

        /// <summary>
        /// Валидация модели SubscribeModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool ValidateSubscribeModel(Subscribe model)
        {
            if(model == null ||
                string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.Url))
                return false;

            return true;
        }
    }
}
