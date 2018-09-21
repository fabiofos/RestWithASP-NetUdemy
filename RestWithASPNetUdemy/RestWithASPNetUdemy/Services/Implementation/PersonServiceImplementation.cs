using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNetUdemy.Model;
using RestWithASPNetUdemy.Model.Context;

namespace RestWithASPNetUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySqlContext _context;
        //context dependency injection by constructor
        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id == id);

                if (result != null)
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            try
            {
                if (!Exist(person.Id)) return new Person();

                var result = _context.Persons.SingleOrDefault(p => p.Id == person.Id);

                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
