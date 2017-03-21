using CarAdverts.Models;

namespace CarAdverts.Services.Contracts
{
    public interface IFileService
    {
        File GetById(int? id);
    }
}