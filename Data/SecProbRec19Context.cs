using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecProbRec19.Models;

namespace SecProbRec19.Data
{
    public class SecProbRec19Context : DbContext
    {
        public SecProbRec19Context (DbContextOptions<SecProbRec19Context> options)
            : base(options)
        {
        }

        public DbSet<SecProbRec19.Models.Receive> Receive { get; set; }
    }
}
