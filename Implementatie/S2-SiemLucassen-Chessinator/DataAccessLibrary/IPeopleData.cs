using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IPeopleData
    {
        public Task<List<PersonModel>> GetPeople();
        public Task InsertPerson(PersonModel person);
    }
}