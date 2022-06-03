using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOlssonGroup.Entities.DTOs
{
    public class EmailDto
    {
        public List<MovieCartDto>? EmailList { get; set; }
        public string EmailAddress { get; set; }
    }
}
