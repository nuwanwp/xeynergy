using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourque.EMAILQueue.Data.Models.DbModels
{
    public class EmailQueueRecord
    {
        public int Id { get; set; }

        public EmailServer FromEmail { get; set; }

        public string ToEmail { get; set; }

        public string Status { get; set; }

        public ICollection<EmailAttachement> Attachements { get; set; }

    }
}
