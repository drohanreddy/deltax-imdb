using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeltaX.Core.POCO
{
    public class ProducerPoco
    {
        [Key]
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
    }
}
