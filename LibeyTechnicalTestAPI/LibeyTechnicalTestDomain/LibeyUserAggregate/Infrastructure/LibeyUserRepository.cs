using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public void Update()
        {
            _context.SaveChanges();
        }

        public List<LibeyUserResponse> FindAll(string filter)
        {
            var usersQuery = _context.LibeyUsers.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                usersQuery = usersQuery.Where(u => u.DocumentNumber.Contains(filter)
                || u.Name.Contains(filter)
                || u.FathersLastName.Contains(filter)
                || u.FathersLastName.Contains(filter));
            }


            var query = from user in usersQuery.Where(u => u.Active)
                        select new LibeyUserResponse()
                        {
                            DocumentNumber = user.DocumentNumber,
                            Active = user.Active,
                            Address = user.Address,
                            DocumentTypeId = user.DocumentTypeId,
                            Email = user.Email,
                            FathersLastName = user.FathersLastName,
                            MothersLastName = user.MothersLastName,
                            Name = user.Name,
                            Password = user.Password,
                            Phone = user.Phone
                        };
            var users = query.ToList();
            return users;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public LibeyUser FindUser(string documentNumber)
        {
            return _context.LibeyUsers.FirstOrDefault(u => u.DocumentNumber.Equals(documentNumber));
        }
    }
}