using ObjectiveTestExercise.Models;

namespace ObjectiveTestExercise.Services.Interfaces
{
    public interface ISubscribeService
    {
        bool AddSubscribe(AddSubscribeModel model);
        Task<IEnumerable<ActualPriceModel>> GetPricesAndUrls();
    }
}
