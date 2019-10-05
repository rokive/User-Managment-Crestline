
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Base
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        [Key]
        public long Id { get; set; }
       
    }
}
