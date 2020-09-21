using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prepaid_Mobile_Topup_Core_Web_App.BusinessModel
{
    //Account top up details
    public class TopUp
    {
        public int Id { get; set; }

        public int MobileAccountId { get; set; }

        public int TopUpChannelId { get; set; }

        public MobileAccount MobileAccount { get; set; }

        public TopUpChannel TopUpChannel { get; set; }

        public decimal TopUpAmount { get; set; }
    }
}
