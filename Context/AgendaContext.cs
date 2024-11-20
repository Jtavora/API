using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fist_api.Models;
using Microsoft.EntityFrameworkCore;

namespace fist_api.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}