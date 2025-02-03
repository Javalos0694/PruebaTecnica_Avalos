using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void CreateOrUpdate(UserUpdateorCreateCommand command)
        {
            var user = _repository.FindUser(command.DocumentNumber);

            if (user is null)
            {
                user = new LibeyUser(command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password);

                _repository.Create(user);
            }
            else
            {
                user.DocumentNumber = command.DocumentNumber;
                user.DocumentTypeId = command.DocumentTypeId;
                user.Name = command.Name;
                user.FathersLastName = command.FathersLastName;
                user.MothersLastName = command.MothersLastName;
                user.Address = command.Address;
                user.UbigeoCode = command.UbigeoCode;
                user.Phone = command.Phone;
                user.Email = command.Email;
                user.Password = command.Password;

                _repository.Update();
            }
        }

        public void Delete(string documentNumber)
        {
            var user = _repository.FindUser(documentNumber);
            if (user is not null)
            {
                user.Active = false;
                _repository.Update();
            }
        }

        public List<LibeyUserResponse> FindAll(string filter)
        {
            var row = _repository.FindAll(filter);
            return row;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
    }
}