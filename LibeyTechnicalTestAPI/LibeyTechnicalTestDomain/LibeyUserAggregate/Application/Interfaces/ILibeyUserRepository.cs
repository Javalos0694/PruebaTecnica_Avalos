using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        LibeyUser FindUser(string documentNumber);
        List<LibeyUserResponse> FindAll(string filter);
        void Create(LibeyUser libeyUser);
        void Update();
    }
}
