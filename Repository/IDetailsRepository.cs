using RotiMakan.Models;

namespace RotiMakan.Repository
{
    public interface IDetailsRepository
    {
        Task<List<DetailsModel>> ShowDetails();
    }
}