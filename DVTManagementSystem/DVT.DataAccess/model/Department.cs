﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
  public   class Department
    {

        public int DepartmentID { get; set; }
        [Required]
        public String DepartmentName { get; set; }
        public String DepartmentDescription { get; set; }

        public virtual  ICollection <Profile> profile { get; set; }
        
    }
}