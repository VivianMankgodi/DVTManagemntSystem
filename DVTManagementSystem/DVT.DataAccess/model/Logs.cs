using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVT.DataAccess
{
 public    class Logs
    {

public Logs()
        {

        }

        
        public int LogsID { get; set; }
        [Required ]
        [StringLength(maximumLength:255)]
        public string Message { get; set; }
        [Required]
        public DateTime LogDateTime { get; set; }

       //[ForeignKey("ProfileID")]
       //[Required ]
       // public int UserProfileID { get; set; }

        public virtual Profile profile { get; set; }
       
    }
}
