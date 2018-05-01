using System.Collections.Generic;
using System.Linq;
using HealthWebApp.Data.EntityModel;
using HealthWebApp.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthWebApp.Data.Services
{
    public class PersonService : IPerson
    {
        private ApplicationDbContext _context;
        public PersonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Person newPerson)
        {
            _context.Add(newPerson);
            _context.SaveChanges();
        }

        public IEnumerable<Person> Getall()
        {
            return _context.People
                .Include(hm => hm.HouseholdMember)
                .Include(hp => hp.HouseholdMember.HouseholdProfile)
                .Include(b => b.HouseholdMember.HouseholdProfile.Barangay)
                .ToList();
        }

        public Person Get(long Id)
        {
            return Getall().FirstOrDefault(p => p.Id == Id);
        }

        public void Update(Person UpdatedPerson)
        {
            _context.Entry(UpdatedPerson).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(long Id)
        {
            Person person = _context.People.FirstOrDefault(p => p.Id == Id);
            _context.People.Remove(person);
            _context.SaveChanges();
         }
    }
}