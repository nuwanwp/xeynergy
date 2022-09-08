using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourque.EMAILQueue.Data.Models.DbModels
{
    public class EmailServer
    {
        [Key]
        public string Email { get; set; }

        public string SmtpServerAddress { get; set; }

        public string SmtpServerUserName { get; set; }

    }
}
