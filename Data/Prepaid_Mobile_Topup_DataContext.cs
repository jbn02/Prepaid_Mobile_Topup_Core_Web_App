using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Prepaid_Mobile_Topup_Core_Web_App.BusinessModel;

namespace Prepaid_Mobile_Topup_Core_Web_App.Models
{
    public class Prepaid_Mobile_Topup_DataContext : DbContext
    {
        public Prepaid_Mobile_Topup_DataContext (DbContextOptions<Prepaid_Mobile_Topup_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Prepaid_Mobile_Topup_Core_Web_App.BusinessModel.MobileAccount> MobileAccount { get; set; }

        public DbSet<Prepaid_Mobile_Topup_Core_Web_App.BusinessModel.PrepaidCustomer> PrepaidCustomer { get; set; }

        public DbSet<Prepaid_Mobile_Topup_Core_Web_App.BusinessModel.TopUpChannel> TopUpChannel { get; set; }

        public DbSet<Prepaid_Mobile_Topup_Core_Web_App.BusinessModel.TopUp> TopUp { get; set; }
    }
}
