using MIS4200_Team2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MIS4200_Team2.DAL
{
    public class MIS4200_Team2Context: DbContext
    {
        public MIS4200_Team2Context() : base ("name=DefaultConnection")
        {
         
        }

        public DbSet<employeeData> employeeData { get; set;}
    }
}