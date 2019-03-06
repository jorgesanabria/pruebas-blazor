using AppGorilla.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGorilla.ViewModel
{
    public class PersonViewModel
    {
        public Person CurrentPerson { get; set; }
        public PersonViewModel()
        {
            CurrentPerson = new Person
            {
                Name = "Emma Watson",
                Age = 27,
                Photo = "emma2.jpg"
            };
        }
    }
}
