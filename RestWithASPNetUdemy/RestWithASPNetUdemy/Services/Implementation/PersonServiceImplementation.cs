using System;
using System.Collections.Generic;
using RestWithASPNetUdemy.Model;

namespace RestWithASPNetUdemy.Services.Implementation
{
    public class PersonServiceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Fabio",
                LastName = "Silva" + " " + i,
                Adress = "Selva",
                Gender = "M"
            };
        }

        public Person FindById(long id)
        {
            return new Person{
                Id = 1,
                FirstName = "Fabio",
                LastName = "Silva",
                Adress = "Selva",
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
