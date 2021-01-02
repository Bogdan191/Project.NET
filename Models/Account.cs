using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Project.NET.Models
{
    public class Account
    {
        [Key, Column("Account_id")]
        public int AccountId { get; set;}
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string userName { get; set;  }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool Admin { get; set; }
    }

    public class Dbaccounts : DbContext
    {
        public Dbaccounts() : base("DbConnectionString")
        {
            Database.SetInitializer<Dbaccounts>(new CustomInit());
            //Database.SetInitializer<Dbaccounts>(new CreateDatabaseIfNotExists<Dbaccounts>());
        }


        public class CustomInit : DropCreateDatabaseAlways<Dbaccounts>
        {
            protected override void Seed(Dbaccounts ctx)
            {
                ctx.Accounts.Add(new Account
                {
                    LastName = "Pintilie",
                    FirstName = "Bogdan-Ioan",
                    userName = "bogdan00",
                    Email = "bogdanpintilie00@yahoo.com",
                    PhoneNumber = "0727619445",
                    Password = "12345678",
                    Admin = true
                });
                ctx.SaveChanges();
                base.Seed(ctx);
            }
        }

        public DbSet<Account> Accounts { get; set; }

    }
}