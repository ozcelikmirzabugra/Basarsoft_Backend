using System.Collections.Generic;
using basarsoft.Controllers;
using basarsoft.Data;
using basarsoft.Interfaces;
// using basarsoft.Migrations;
using basarsoft.Models;
using basarsoft.Services;
using basarsoft.UnitOfWork;

namespace basarsoft.Models
{
    public class Coordinates
    {
        public int Id { get; set; } // public key
        public string WKT { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
