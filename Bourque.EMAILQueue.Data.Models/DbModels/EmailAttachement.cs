using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bourque.EMAILQueue.Data.Models.DbModels
{
    public class EmailAttachement
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public EmailQueueRecord QueueRecord { get; set; }
    }
}
