using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Core.DTO.Email
{
    public class EmailDTO
    {
        public EmailDTO(string tO, string from, string subject, string content)
        {
            TO = tO;
            From = from;
            Subject = subject;
            Content = content;
        }

        public string TO { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        

    }
}
