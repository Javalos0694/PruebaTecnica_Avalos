using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        List<LibeyUserResponse> FindAll(string filter);
        void CreateOrUpdate(UserUpdateorCreateCommand command);
        void Delete(string documentNumber);
    }
}