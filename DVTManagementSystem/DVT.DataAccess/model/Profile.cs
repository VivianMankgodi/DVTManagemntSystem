using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVT.DataAccess.model
{
   public class Profile
    {
        public int ProfileID { get; set; }
        [Required]
        public string FirstName { get; set; }

        public ICollection<Logs> logs { get; set; }
    }
}
