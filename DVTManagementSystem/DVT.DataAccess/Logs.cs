using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DVT.DataAccess.model;

namespace DVT.DataAccess
{
 public    class Logs
    {

public Logs()
        {

        }

        [Key]
        public int LogID { get; set; }
        [Required ]
        [StringLength(maximumLength:255)]
        public string Message { get; set; }
        [Required]
        public DateTime LogDateTime { get; set; }

        public int UserProfileID { get; set; }

        public Profile profile { get; set; }
    }
}
