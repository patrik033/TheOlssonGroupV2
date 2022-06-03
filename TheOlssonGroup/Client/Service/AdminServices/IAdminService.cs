

using TheOlssonGroup.Entities.DatabaseModels;

namespace TheOlssonGroup.Client.Service.AdminServices
{
    public interface IAdminService
    {
        Task Save(Movie movie);


        Task Edit(Movie movie);


        Task Delete(int id);

    }
}
