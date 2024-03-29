﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BGSchools.Entities
{
    public class Student
    {
       
        public int Id { get; set; }
            public string Name { get; set; }

     
            public string Email { get; set; }

            public string RetypeEmail { get; set; }

            
            public string Phone { get; set; }

           
            public string Age { get; set; }
            public string Address { get; set; }
            public string City { get; set; }

           
            public DateTime? DateOfBirth { get; set; }

        }
}