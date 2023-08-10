using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSEARCHFUNC.Models.DDL
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<State> States { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}