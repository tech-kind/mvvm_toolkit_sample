using System.Threading.Tasks;
using MvvmToolkitSample.Core.Models;
using Refit;

namespace MvvmToolkitSample.Core.Services
{
    public interface IContactsService
    {
        [Get("/api/?dataType=json&inc=name,email,picture")]
        Task<ContactsQueryResponse> GetContactsAsync([AliasAs("results")] int count);
    }
}
