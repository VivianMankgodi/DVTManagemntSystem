using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
public     class Gender
    {
        public int GenderID { get; set; }
        [Required]
        public string GenderName { get; set; }

        public virtual Profile profile { get; set; }
    }
}
