using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Person.WebApi.Controllers
{
    public class PersonController : ApiController
    {
        
        public static List<Person> persons = new List<Person>() { 
            new Person (Guid.NewGuid(), "Ivan", "Husnjak"),
            new Person (Guid.NewGuid(), "Pero", "Peric"), 
            new Person (Guid.NewGuid(), "Marko", "Maric")
        };

        
        public HttpResponseMessage GetAllPersons()
        {

           if(persons == null || persons.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty list!");
                 
            } else
            {
                return Request.CreateResponse(HttpStatusCode.OK, persons);   
            }
        }

        
        public HttpResponseMessage PostPerson(Person person)
        {
            var tempPerson = persons.Where(p => p.Id == person.Id).FirstOrDefault();
            if (tempPerson != null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, $"Person with id: {person.Id} allready exists!");
            } else
            {
                persons.Add(person);
                return Request.CreateResponse(HttpStatusCode.OK, person);    
            }
        }

        [Route("api/person/{guid}")]
        public HttpResponseMessage GetByGuid(Guid guid)
        {
            var person = persons.Where(p => p.Id == guid).FirstOrDefault();

            if(person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Cannot find id {guid}");
                
            } else
            {
                return Request.CreateResponse(HttpStatusCode.OK, person);
                
            }
        }



        [Route("api/person/{guid}")]
        public HttpResponseMessage PutByGuid([FromUri]Guid guid, Person personToPut)
        {
            var person = persons.Where(p => p.Id == guid).FirstOrDefault();
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Cannot find guid {guid}");      
            } else {
                person.Id = personToPut.Id;
                person.FirstName = personToPut.FirstName;
                person.LastName = personToPut.LastName;
                return Request.CreateResponse(HttpStatusCode.OK, person.FirstName + " edited!");
                
            }
        }

        [Route("api/person/{guid}")]
        public HttpResponseMessage DeletePerson(Guid guid)
        {
            var person = persons.Where(p => p.Id == guid).FirstOrDefault();

            if (person != null)
            {
                persons.Remove(person);
                return Request.CreateResponse(HttpStatusCode.OK, $"Person with name {person.FirstName} nad id {person.Id} removed!");
            }else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, person);
            }        

        }
    }

    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {
        }
    }
    
}
